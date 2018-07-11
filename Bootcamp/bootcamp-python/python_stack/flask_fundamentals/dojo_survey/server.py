from flask import Flask, render_template, session, request, redirect, flash
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app = Flask(__name__)
app.secret_key = "secretSurvey"

@app.route("/")
def survey():
    return render_template('survey.html')

@app.route("/survey", methods=['POST', 'GET'])
def create():
    print(request.form)
    print('Name', request.form['name'])
    print('E-mail', request.form['email'])
    print('Dojo Location', request.form['dojo_location'])
    print('Favorite Language', request.form['fav_language'])
    print('Comments', request.form['comments'])
    return render_template('submitted.html')

@app.route("/process", methods=['POST'])
def submit():
    if len(request.form['name']) < 1:
        flash("Name cannot be empty!")
    elif len(request.form['name']) < 3:
        flash("Name must be more than 3 or more characters.")
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    if len(request.form['comments']) > 120:
        flash("Comment is too long")
    elif len(request.form['comments']) < 1:
        flash("You need to make a comment")
    if '_flashes' in session.keys():
        return redirect("/")
    else:
        return create()


if __name__=="__main__":
    app.run(debug=True)