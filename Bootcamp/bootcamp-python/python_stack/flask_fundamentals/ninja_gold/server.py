from flask import Flask, render_template, session, request, redirect, flash
import random
import datetime

app = Flask(__name__)
app.secret_key = 'ninjaGold'

@app.route('/')
def index():
    ninja_places = (
       {'place': 'Farm', 'value': 'Earns 10 to 20 gold'},
       {'place': 'Cave', 'value': 'Earns 5 to 10 gold'},
       {'place': 'House', 'value': 'Earns 2 to 5 gold'},
       {'place': 'Casino', 'value': 'Lose or Earn 0 to 50 gold'}
    )
    if 'game' not in session:
        session['roll'] = None
        session['gold'] = 0
        session['game'] = False
        session['place'] = None   
        session['results'] = []
    return render_template('index.html', places = ninja_places)

@app.route('/game', methods = ['POST'])
def roll():
    session['place'] = request.form['place']
    time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    if session['place'] == "Farm":
        session['roll'] = random.randrange(10,21)
        session['gold'] += session['roll']
        currentRoll = "You earned "+str(session['roll'])+" gold from the "+str(session['place'])+"! "+str(time)
    if session['place'] == "Cave":
        session['roll'] = random.randrange(5,11)
        session['gold'] += session['roll']
        currentRoll = "You earned "+str(session['roll'])+" gold from the "+str(session['place'])+"! "+str(time)
    if session['place'] == "House":
        session['roll'] = random.randrange(2,6)
        session['gold'] += session['roll']
        currentRoll = "You earned "+str(session['roll'])+" gold from the "+str(session['place'])+"! "+str(time)
    if session['place'] == "Casino":
        session['roll'] = random.randrange(-50,51)
        session['gold'] += session['roll']
        if session['roll'] < 0:
            if session['gold'] + session['roll'] <= 0:
                session['gold'] = 0
                currentRoll = "You lost it all at the casino! "+str(time)
            else:
                currentRoll = "You lost "+str(session['roll'])+" gold at the "+str(session['place'])+"! "+str(time)
        elif session['roll'] == 0:
            currentRoll = "You broke even at the "+str(session['place'])+"! "+str(time)
        else:
            currentRoll = "You earned "+str(session['roll'])+" gold from the "+str(session['place'])+"! "+str(time)   
    session['results'].append(currentRoll)
    session['game'] = True
    return redirect("/")

@app.route('/reset', methods = ['POST'])
def reset():
    if session:
        session.clear()
    return redirect('/')

if __name__=="__main__":
    app.run(debug=True)