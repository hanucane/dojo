from flask import Flask, render_template, session, request, redirect
import random

app = Flask(__name__)
app.secret_key = 'hello'

@app.route('/')
def index():
    session['win'] = 0
    session['loss'] = 0
    session['tie'] = 0
    return render_template("index.html")

@app.route('/game', methods=['POST', 'GET'])
def runGame():
    gameArray = ['rock', 'paper', 'scissors']
    computer = random.choice(gameArray)
    winDict = {
        'rockpaper' : 'loss',
        'rockscissors' : 'win',
        'rockrock' : 'tie',
        'scissorspaper' : 'win',
        'scissorsscissors' : 'tie',
        'scissorsrock' : 'loss',
        'paperpaper' : 'tie',
        'paperscissors' : 'loss',
        'paperrock' : 'win',
    }
    print('User Choice', request.form['choice'])
    resString = request.form['choice'] + computer
    result = winDict[resString]
    session[result] = session[result] + 1
    game_message = ""
    if result == 'loss':
        game_message = "Sorry you lost. Try again!"
    elif result == 'win':
        game_message = "You won!"
    elif result == 'tie':
        game_message = "Looks like a tie. Nobody leaves until there is a winner!"
    return render_template('rps_result.html', message=game_message)

if __name__=="__main__":
    app.run(debug=True)