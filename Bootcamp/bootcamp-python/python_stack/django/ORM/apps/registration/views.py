from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from django.utils.timezone import utc
import datetime
import bcrypt

from .models import *

def index(request):
    if "logged_in" not in request.session:
        request.session['logged_in'] = False
    return render(request, 'registration/index.html')

def register(request):
    errors = User.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags='registration')
        return redirect('/registration')
    else:
        password = request.POST['password']
        hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
        User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed)
    request.session['logged_in'] = True
    id = User.objects.get(email=request.POST['email']).id
    messages.success(request, "You successfully registered!")
    return redirect('/registration/profile/'+str(id))

def login(request):
    password = request.POST['password']    
    if User.objects.get(email=request.POST['email']):
        hashed = User.objects.get(email=request.POST['email']).password
        if bcrypt.checkpw(password.encode('utf-8'), hashed.encode('utf-8')):
            messages.success(request, "You successfully logged in!")
            id = User.objects.get(email=request.POST['email']).id
            request.session['logged_in'] = True
            request.session['user_id'] = id
            return redirect('/registration/wall/'+str(id))
            
    messages.error(request, "You could not be logged in", extra_tags='login')
    return redirect('/registration')

def logout(request):
    request.session.clear()
    messages.success(request, "You have been logged out")
    return redirect('/registration')

def profile(request, id):
    if request.session['logged_in'] == True:
        return render(request, 'registration/profile.html', {'user': User.objects.get(id=id)})
    else: 
        messages.success(request, "You need to be logged in")
        return redirect('/registration')

def wall(request, id):
    if request.session['logged_in'] == True:
        return render(request, 'registration/wall.html', {'user': User.objects.get(id=id), 'wall_messages': Message.objects.all(), 'comments': Comment.objects.all()})
        return redirect('/registration')
    else: 
        messages.success(request, "You need to be logged in")
        return redirect('/registration')

def submit_msg(request):
    Message.objects.create(message=request.POST['message'], user=User.objects.get(id=request.session['user_id']))
    return redirect('/registration/wall/'+str(request.session['user_id']))

def destroy_msg(request):
    b = Message.objects.get(id=request.POST['message_id'])
    now = datetime.datetime.utcnow().replace(tzinfo=utc)
    timediff = now - b.created_at
    print(b.created_at, now, timediff)
    if timediff.total_seconds() > 1800:
        messages.error(request, "It's too late to delete this message.")
        return redirect('/registration/wall/'+str(request.session['user_id']))
    else:
        b.delete()
        messages.success(request, "Message successfully deleted")
        return redirect('/registration/wall/'+str(request.session['user_id']))

def submit_comment(request):
    Comment.objects.create(comment=request.POST['comment'], user=User.objects.get(id=request.session['user_id']), message=Message.objects.get(id=request.POST['message_id']))
    return redirect('/registration/wall/'+str(request.session['user_id']))

def destroy_comment(request):
    b = Comment.objects.get(id=request.POST['comment_id'])
    b.delete()
    messages.success(request, "Comment successfully deleted")
    return redirect('/registration/wall/'+str(request.session['user_id']))