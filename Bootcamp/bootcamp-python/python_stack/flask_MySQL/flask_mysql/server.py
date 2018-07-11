from flask import Flask, render_template, session, request, redirect, flash
# import the function connectToMySQL from the file mysqlconnection.py
from mysqlconnection import connectToMySQL
app = Flask(__name__)
app.secret_key = "secretSurvey"
# invoke the connectToMySQL function and pass it the name of the database we're using
# connectToMySQL returns an instance of MySQLConnection, which we will store in the variable 'mysql'
mysql = connectToMySQL('twitter')
# now, we may invoke the query_db method
print("all the users", mysql.query_db("SELECT * FROM users;"))

@app.route("/")
def survey():
    return render_template('index.html')

if __name__ == "__main__":
    app.run(debug=True)
