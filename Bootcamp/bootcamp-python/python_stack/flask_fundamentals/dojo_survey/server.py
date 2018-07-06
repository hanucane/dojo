from flask import Flask, render_template, session, request, redirect

app = Flask(__name__)

@app.route("/")
def survey():
    return render_template('survey.html')

@app.route("/survey", methods=['POST'])
def create():
    print(request.form)
    print('Name', request.form['name'])
    print('Dojo Location', request.form['dojo_location'])
    print('Favorite Language', request.form['fav_language'])
    print('Comments', request.form['comments'])
    return render_template('submitted.html')

if __name__=="__main__":
    app.run(debug=True)