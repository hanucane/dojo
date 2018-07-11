from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    context = {
        "email" : "blog@gmail.com",
        "name" : "mike"
    }
    return render(request, 'blog/index.html', context)

def new(request):
    response = "Insert new blog here"
    return HttpResponse(response)

def create(request):
    if request.method == "POST":
        print("*"*50)
        print(request.POST)
        print(request.POST['name'])
        print(request.POST['desc'])
        request.session['name'] = "test"  # more on session below
        print("*"*50)
        return redirect("/")
    else:
        return redirect("/")

def show(request, number):
    print(number)
    return HttpResponse("Placeholder to display blog " + number)

def edit(request, number):
    print(number)
    return HttpResponse("Placeholder to edit blog " + number)

def delete(request, number):
    print("Delete -", number)
    return redirect('/')