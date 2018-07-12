from django.shortcuts import render, HttpResponse, redirect
import datetime

def index(request):
    request.session['word_colors'] = ['red', 'green', 'blue']
    if 'results' not in request.session:
        request.session['results'] = []
    return render(request, 'session_words/index.html')

def submit(request):
    request.session['time'] = datetime.datetime.now().strftime("%H:%M:%S %m-%d-%Y")
    request.session['word'] = request.POST['word']
    request.session['color'] = request.POST['color']
    request.session['font'] = request.POST['font']
    currentWord = {
        'color': request.session['color'],
        'word': request.session['word'],
        'font': request.session['font'],
        'created': request.session['time'],
        'string': " - added on "+str(request.session['time'])
        }

    request.session['results'].insert(0, currentWord)
    print(request.session['results'])

    return redirect('/session_words')

def reset(request):
    request.session.clear()
    return redirect('/session_words')

