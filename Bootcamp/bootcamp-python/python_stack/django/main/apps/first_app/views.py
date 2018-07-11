from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    response = "Index page succesful"
    return HttpResponse(response)

def http(request):
    response = "Http request successful!"
    return HttpResponse(response)