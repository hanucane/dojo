from django.shortcuts import render, HttpResponse, redirect
from django.utils.crypto import get_random_string
import random

def index(request):
    if 'counter' in request.session:
        return render(request, 'random_word_gen/index.html')
    else:
        request.session['counter'] = 0
    return render(request, 'random_word_gen/index.html')

def generate(request):    
    request.session['counter'] += 1
    request.session['random_word'] = get_random_string(length=random.randint(3,24), allowed_chars='abcdefghijklmnopqrstuvwxyz')
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')
