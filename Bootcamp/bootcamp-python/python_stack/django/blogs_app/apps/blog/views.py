from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "Blog index page request succesful"
    return HttpResponse(response)

def new(request):
    response = "Insert new blog here"
    return HttpResponse(response)

def create(request):
    return redirect('/')

def show(request, number):
    print(number)
    return HttpResponse("Placeholder to display blog " + number)

def edit(request, number):
    print(number)
    return HttpResponse("Placeholder to edit blog " + number)

def delete(request, number):
    print("Delete -", number)
    return redirect('/')