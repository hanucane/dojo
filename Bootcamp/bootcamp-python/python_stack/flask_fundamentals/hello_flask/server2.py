from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def index():
    return render_template('alchemist/pasture.html')

@app.route('/home')
def home():
    return render_template('alchemist/home.html')

@app.route('/village')
def village():
    return render_template('alchemist/village.html')

@app.route('/pasture')
def pasture():
    return render_template('alchemist/pasture2.html')

app.run(debug=True)