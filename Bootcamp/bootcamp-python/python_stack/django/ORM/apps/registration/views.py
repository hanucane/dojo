from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
import bcrypt

from .models import *

def index(request):
    return render(request, 'registration/index.html')

def register(request):
    errors = User.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/registration')
    else:
        password = request.POST['password']
        hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
        User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed)

    id = User.objects.get(email=request.POST['email']).id
    messages.success(request, "You successfully registered!")
    return redirect('/registration/profile/'+str(id))

def login(request):
    password = request.POST['password']
    hashed = User.objects.get(email=request.POST['email']).password
    if User.objects.get(email=request.POST['email']):
        if bcrypt.checkpw(password.encode('utf-8'), hashed.encode('utf-8')):
            messages.success(request, "You successfully logged in!")
            id = User.objects.get(email=request.POST['email']).id
            return redirect('/registration/profile/'+str(id))
            
    messages.fail(request, "You could not be logged in")
    return redirect('/registration')

def profile(request, id):
    return render(request, 'registration/profile.html', {'user': User.objects.get(id=id)})