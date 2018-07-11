from flask import Flask, render_template, session, request, redirect, flash
from flask_bcrypt import Bcrypt
from mysqlconnection import connectToMySQL
import re
import datetime

app = Flask(__name__)
app.secret_key = "secretSurvey"
bcrypt = Bcrypt(app) 
mysql = connectToMySQL('registration')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route("/")
def registration():
    users = mysql.query_db("SELECT * FROM users;")
    print(users)
    return render_template('register.html')

@app.route("/registered", methods=['POST'])
def add_user():
    pw_hash = bcrypt.generate_password_hash(request.form['password']) 
    query = "INSERT INTO users (first_name, last_name, email, password_hash, created_at, updated_at) VALUES (%(first_name)s, %(last_name)s, %(email)s, %(password_hash)s, NOW(), NOW());"
    data = {
             'first_name': request.form['first_name'],
             'last_name':  request.form['last_name'],
             'email': request.form['email'],
             "password_hash" : pw_hash
           }
    mysql.query_db(query, data)

    return render_template('registered.html')

@app.route("/profile")
def profile():

    return render_template('login.html')

@app.route("/process", methods=['POST'])
def submit():
    if len(request.form['first_name']) < 1:
        flash("First name cannot be empty!")
    elif len(request.form['first_name']) < 3:
        flash("First name must be more than 3 or more characters.")
    if len(request.form['last_name']) < 1:
        flash("Last name cannot be empty!")
    elif len(request.form['last_name']) < 2:
        flash("Last name must be more than 2 or more characters.")
    while True:
        password = request.form['password']
        if len(request.form['password']) < 8:
            flash("Password must be at least 8 characters long.")
        elif re.search('[0-9]',password) is None:
            flash("Password must have a number in it.")
        elif re.search('[A-Z]',password) is None:
            flash("Password must have an uppercase letter in it.")
        elif password != request.form['pw_confirm']:
            flash("Your password must match.")
        break
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    if '_flashes' in session.keys():
        return redirect("/")
    else:
        return add_user()

@app.route('/login', methods=['POST'])
def login():
    query = "SELECT * FROM users WHERE email = %(email)s;"
    data = { "email" : request.form["email"] }
    result = mysql.query_db(query, data)
    print(result)
    if result:
        if bcrypt.check_password_hash(result[0]['password_hash'], request.form['password']):
            session['userid'] = result[0]['id']
            session['email'] = result[0]['email']
            session['first_name'] = result[0]['first_name']
            session['last_name'] = result[0]['last_name']
            return redirect('/profile')
    flash("You could not be logged in")
    return redirect("/")

@app.route('/logout', methods = ['POST'])
def logout():
    if session:
        session.clear()
    return redirect('/')



if __name__=="__main__":
    app.run(debug=True)