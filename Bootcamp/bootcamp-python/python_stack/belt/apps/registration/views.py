from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
import bcrypt

from .models import *

def index(request):
    if "logged_in" not in request.session:
        request.session['logged_in'] = False
        request.session['user_id'] = None
    return render(request, 'registration/index.html')

def registration(request):
    errors = User.objects.basic_validator(request.POST)
    set_level = User.objects.all()
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags='registration')
        return redirect('/')
    else:
        password = request.POST['password']
        hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
        request.session['logged_in'] = True
        User.objects.create(name=request.POST['name'], email=request.POST['email'], password=hashed)
        request.session['user_id'] = User.objects.get(email=request.POST['email']).id
        messages.success(request, "You successfully registered!", extra_tags='registration')
        return redirect('/')

def login(request):
    password = request.POST['password']
    if User.objects.filter(email=request.POST['email']):
        hashed = User.objects.get(email=request.POST['email']).password
        if bcrypt.checkpw(password.encode('utf-8'), hashed.encode('utf-8')):
            request.session['logged_in'] = True
            request.session['user_id'] = User.objects.get(email=request.POST['email']).id
            messages.success(request, "You are signed in", extra_tags="login")
            return redirect('/travels')
    messages.error(request, "You could not be logged in", extra_tags="login")
    return redirect('/')

def logout(request):
    request.session.clear()
    messages.success(request, "You have logged out", extra_tags="login")

    return redirect('/')