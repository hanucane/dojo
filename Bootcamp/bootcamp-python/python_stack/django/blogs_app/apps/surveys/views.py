from django.shortcuts import render, HttpResponse, redirect

def index(request):
    if request.session['login'] == True:
        request.session['locations'] = (
            {'location': 'Seattle'},
            {'location': 'San Jose'},
            {'location': 'Silicon Valley'},
            {'location': 'Tulsa'},
            {'location': 'Salt Lake City'},
            {'location': 'Dallas'},
            {'location': 'Chicago'},
            {'location': 'New York City'}
        )
        request.session['languages'] = (
            {'name': 'Python'},
            {'name': 'Django'},
            {'name': 'PHP'},
            {'name': 'Flask'},
            {'name': 'SQL'},
            {'name': 'HTML'},
            {'name': 'CSS'},
            {'name': 'Javascript'}
        )
        if 'counter' in request.session:
            return render(request, 'surveys/index.html')
        else:
            request.session['counter'] = 0
        return render(request, 'surveys/index.html')
    else:
        request.session['message'] = "You are not logged in!"
        return redirect('/')

def result(request):
    return render(request, 'surveys/submitted.html')

def submit(request):
    if request.method == "POST":
        request.session['name'] = request.POST['name']
        request.session['email'] = request.POST['email']
        request.session['location'] = request.POST['dojo_location']
        request.session['language'] = request.POST['fav_language']
        request.session['comment'] = request.POST['comments']
        request.session['counter'] += 1
        return redirect('/survey/result')

def reset(request):
    request.session.clear()
    return redirect('/survey')

