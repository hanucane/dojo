from django.shortcuts import render, HttpResponse, redirect

def index(request):
    return render(request, 'login/index.html')

def register(request):
    request.session['first_name'] = request.POST['first_name']
    request.session['last_name'] = request.POST['last_name']
    request.session['email'] = request.POST['email']
    request.session['password'] = request.POST['password']
    return redirect('/registered')

def success(request):
    return render(request, 'login/registered.html')

def login(request):
    if request.POST['email'] == request.session['email']:
        if request.POST['password'] == request.session['password']:
            request.session['login'] = True
            return redirect('/profile')
        else: 
            request.session['message'] = "Your password is incorrect"
    else:
        request.session['message'] = "Your email is incorrect"
    return redirect('/')

def profile(request):
    if request.session['login'] == True:
        return render(request, 'login/profile.html')
    else:
        return redirect('/')

def logout(request):
    request.session['login'] = False
    request.session['message'] = "You have successfully logged out!"
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')