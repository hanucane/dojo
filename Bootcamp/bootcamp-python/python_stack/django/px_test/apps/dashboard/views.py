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
    return render(request, 'dashboard/admin/manage_users.html', {"users": User.objects.all()})

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
    return render(request, 'dashboard/user/users.html', {"users": User.objects.all()})

def edit(request, id):
    return render(request, 'dashboard/admin/edit_user.html', {'user': User.objects.get(id=id), 'range': [0,9]})

def update(request, id):
    # errors = User.objects.basic_validator(request.POST)
    # if len(errors):
    #     for tag, error in errors.items():
    #         messages.error(request, error, extra_tags=tag)
    #     return redirect('/users/edit'+id)
    # else:
    user = User.objects.get(id = id)
    user.first_name = request.POST['first_name']
    user.last_name = request.POST['last_name']
    user.email = request.POST['email']
    user.user_level = request.POST['user_level']
    user.save()
    messages.success(request, "User successfully updated")
    return redirect('/dashboard/admin')

def new(request):
    return render(request, 'dashboard/admin/add_user.html', {'range': [0,9]})

def create(request):
    errors = User.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/users/new')
    password = request.POST['password']
    hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
    User.objects.create(first_name=request.POST['first_name'], last_name=request.POST['last_name'], email=request.POST['email'], password=hashed, user_level=request.POST['user_level'])
    return redirect('/dashboard/admin')

def destroy(request, id):
    b = User.objects.get(id=id)
    b.delete()
    messages.success(request, "User successfully deleted")
    return redirect('/dashboard/admin')

def edit_self(request, id):
    return render(request, 'dashboard/user/edit_self.html', {'user': User.objects.get(id=id), 'range': [0,9]})

def update_self(request, id):
    user = User.objects.get(id = id)
    user.first_name = request.POST['first_name']
    user.last_name = request.POST['last_name']
    user.email = request.POST['email']
    user.user_level = request.POST['user_level']
    user.save()
    messages.success(request, "User successfully updated")
    return redirect('/dashboard')

def update_description(request):
    Description.objects.create(desc=request.POST['description'], user=User.objects.get(id=request.session['user_id']))
    return redirect('/edit_profile/'+str(request.session['user_id']))

def show(request, id):
    return render(request, 'dashboard/user/messenger.html', {'user': User.objects.get(id=id), 'messages': Message.objects.all(), 'responses': Response.objects.all(), 'description': Description.objects.all()})

def msg_submit(request):
    Message.objects.create(message=request.POST['message'], user=User.objects.get(id=request.session['user_id']), msg_receiver=User.objects.get(id=request.POST['user_id']))
    return redirect('/users/show/'+str(request.POST['user_id']))

def msg_destroy(request):
    b = Message.objects.get(id=request.POST['message_id'])
    b.delete()
    c = request.POST['user_id']
    messages.success(request, "Message successfully deleted")
    return redirect('/users/show/'+str(c))

def resp_submit(request):
    Response.objects.create(response=request.POST['response'], message=Message.objects.get(id=request.POST['message_id']), user=User.objects.get(id=request.session['user_id']))
    return redirect('/users/show/'+str(request.POST['user_id']))

def resp_destroy(request):
    b = Response.objects.get(id=request.POST['response_id'])
    b.delete()
    c = request.POST['user_id']
    messages.success(request, "Response successfully deleted")
    return redirect('/users/show/'+str(c))