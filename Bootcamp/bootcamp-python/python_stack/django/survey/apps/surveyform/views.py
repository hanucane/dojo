from django.shortcuts import render, HttpResponse, redirect

def index(request):
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
        return render(request, 'surveyform/index.html')
    else:
        request.session['counter'] = 0
    return render(request, 'surveyform/index.html')

def result(request):
    return render(request, 'surveyform/submitted.html')

def submit(request):
    if request.method == "POST":
        request.session['name'] = request.POST['name']
        request.session['email'] = request.POST['email']
        request.session['location'] = request.POST['dojo_location']
        request.session['language'] = request.POST['fav_language']
        request.session['comment'] = request.POST['comments']
        request.session['counter'] += 1
        return redirect('/result')

def reset(request):
    request.session.clear()
    return redirect('/')

