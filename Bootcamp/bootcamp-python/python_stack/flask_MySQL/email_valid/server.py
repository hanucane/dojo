from flask import Flask, render_template, session, request, redirect, flash
from mysqlconnection import connectToMySQL
import re
import datetime

app = Flask(__name__)
app.secret_key = "email_valid" 
mysql = connectToMySQL('email_valid')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

@app.route("/")
def email():
    emails = mysql.query_db("SELECT * FROM emails;")

    return render_template('index.html', emails=emails)

@app.route("/submitted", methods=['POST'])
def add_email():
    query = "INSERT INTO emails (emails, created_at, updated_at) VALUES (%(emails)s, NOW(), NOW());"
    data = { 
        'emails': request.form['email'] 
    }
    mysql.query_db(query, data)
    emails = mysql.query_db("SELECT * FROM emails;")


    return render_template('emails.html', emails=emails)

@app.route("/submit", methods=['POST'])
def submit():
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    if '_flashes' in session.keys():
        return redirect("/")
    else:
        return add_email()

@app.route("/delete", methods=['POST'])
def delete():
    query = "DELETE FROM emails WHERE id=%(id)s"
    data = {
        'id': request.form['id']
    }
    mysql.query_db(query, data)
    return redirect("/")

if __name__=="__main__":
    app.run(debug=True)