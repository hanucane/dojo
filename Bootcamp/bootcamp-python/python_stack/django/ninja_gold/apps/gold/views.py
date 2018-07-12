from django.shortcuts import render, HttpResponse, redirect
import random
import datetime

def index(request):
    request.session['ninja_places'] = (
       {'place': 'Farm', 'value': 'Earns 10 to 20 gold'},
       {'place': 'Cave', 'value': 'Earns 5 to 10 gold'},
       {'place': 'House', 'value': 'Earns 2 to 5 gold'},
       {'place': 'Casino', 'value': 'Lose or Earn 0 to 50 gold'}
    )
    if 'game' not in request.session:
        request.session['roll'] = None
        request.session['gold'] = 0
        request.session['game'] = False
        request.session['place'] = None   
        request.session['results'] = []
    return render(request, 'gold/index.html')

def roll(request):
    request.session['place'] = request.POST['place']
    time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    if request.session['place'] == "Farm":
        request.session['roll'] = random.randrange(10,21)
        request.session['gold'] += request.session['roll']
        currentRoll = "You earned "+str(request.session['roll'])+" gold from the "+str(request.session['place'])+"! ~~"+str(time)
    if request.session['place'] == "Cave":
        request.session['roll'] = random.randrange(5,11)
        request.session['gold'] += request.session['roll']
        currentRoll = "You earned "+str(request.session['roll'])+" gold from the "+str(request.session['place'])+"! ~~"+str(time)
    if request.session['place'] == "House":
        request.session['roll'] = random.randrange(2,6)
        request.session['gold'] += request.session['roll']
        currentRoll = "You earned "+str(request.session['roll'])+" gold from the "+str(request.session['place'])+"! ~~"+str(time)
    if request.session['place'] == "Casino":
        request.session['roll'] = random.randrange(-50,51)
        request.session['gold'] += request.session['roll']
        if request.session['roll'] < 0:
            if request.session['gold'] + request.session['roll'] <= 0:
                request.session['gold'] = 0
                currentRoll = "You lost it all at the casino! ~~"+str(time)
            else:
                currentRoll = "You lost "+str(request.session['roll'])+" gold at the "+str(request.session['place'])+"! ~~"+str(time)
        elif request.session['roll'] == 0:
            currentRoll = "You broke even at the "+str(request.session['place'])+"! ~~"+str(time)
        else:
            currentRoll = "You earned "+str(request.session['roll'])+" gold from the "+str(request.session['place'])+"! ~~"+str(time)   
    request.session['results'].insert(0, currentRoll)
    request.session['game'] = True
    return redirect("/")

def reset(request):
    request.session.clear()
    return redirect('/')
