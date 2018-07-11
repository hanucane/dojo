from flask import Flask, render_template, session, request, redirect

app = Flask(__name__)
app.secret_key = 'counter'

@app.route('/')
def index():
    session['counter'] = 1
    return render_template('index.html')

@app.route('/counting', methods=['POST'])
def counting():
    session['counter'] += 2
    return render_template('add.html')

if __name__=="__main__":
    app.run(debug=True)