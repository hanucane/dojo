from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages

from .models import *

def index(request):
    return render(request, 'user_login/index.html', {'users': User.objects.all()})

def new(request):
    return render(request, 'user_login/new.html')

def show(request, id):
    return render(request, 'user_login/show.html', {'user': User.objects.get(id=id)})

def edit(request, id):
    return render(request, 'user_login/edit.html', {'user': User.objects.get(id=id)})

def update(request, id):
    errors = User.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/'+id+'/edit')
    else:
        user = User.objects.get(id = id)
        user.first_name = request.POST['first_name']
        user.last_name = request.POST['last_name']
        user.email_address = request.POST['email_address']
        user.age = request.POST['age']
        user.save()
        messages.success(request, "User successfully updated")
        return redirect('/users')

def destroy(request, id):
    b = User.objects.get(id=id)
    b.delete()
    messages.success(request, "User successfully deleted")
    return redirect('/users')

def create(request):
    errors = User.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/new')
    User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email_address=request.POST['email_address'], age=request.POST['age'])
    return redirect('/users')

