from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('routing-px/index.html')

@app.route('/dojo')
def dojo():
    return render_template('routing-px/dojo.html')

@app.route('/say/<name>')
def say(name):
    return "Hi "+ name 

@app.route('/repeat/<int:value>/<str>')
def repeat(value, str):
    print(value)
    print(str)
    return str * value 

app.run(debug=True)