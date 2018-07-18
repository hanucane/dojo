from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
import bcrypt

from .models import *

def index(request):
    if "logged_in" not in request.session:
        request.session['logged_in'] = False
        request.session['user_id'] = None
    return render(request, 'dashboard/index.html')

def signin(request):
    return render(request, 'dashboard/login.html')

def registration(request):
    return render(request, 'dashboard/register.html')

def register(request):
    errors = User.objects.basic_validator(request.POST)
    set_level = User.objects.all()
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/register')
    else:
        password = request.POST['password']
        hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
        if not set_level:
            level = 9
            request.session['logged_in'] = True
            User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed, user_level=level)
            request.session['user_id'] = User.objects.get(email=request.POST['email']).id
            return redirect('/dashboard/admin')
        else:
            level = 0
        User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed, user_level=level)
    request.session['logged_in'] = True
    messages.success(request, "You successfully registered!")
    return redirect('/dashboard')

def admin_dash(request):
    return render(request, 'dashboard/admin/manage_users.html')

def login(request):
    password = request.POST['password']
    hashed = User.objects.get(email=request.POST['email']).password
    if User.objects.get(email=request.POST['email']):
        if bcrypt.checkpw(password.encode('utf-8'), hashed.encode('utf-8')):
            if User.objects.get(email=request.POST['email']).user_level == 9:
                request.session['logged_in'] = True
                request.session['user_level'] = 9
                request.session['user_id'] = User.objects.get(email=request.POST['email']).id
                return redirect('/dashboard/admin')
            else:
                request.session['logged_in'] = True
                request.session['user_level'] = 0
                request.session['user_id'] = User.objects.get(email=request.POST['email']).id
                return redirect('/dashboard')
    messages.success(request, "You could not be logged in")
    return redirect('/signin')

def logout(request):
    request.session.clear()
    return redirect('/')

def dash(request):
    return render(request, 'dashboard/user/users.html')