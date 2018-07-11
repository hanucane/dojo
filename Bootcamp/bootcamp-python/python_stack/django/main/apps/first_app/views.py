from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    context = {
        "email" : "blog@gmail.com",
        "name" : "mike"
    }
    return render(request, 'first_app/index.html', context)

def http(request):
    response = "Http request successful!"
    return HttpResponse(response)