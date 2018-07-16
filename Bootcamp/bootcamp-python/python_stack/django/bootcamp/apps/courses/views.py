from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages

from .models import *
def index(request):
    return render(request, 'courses/index.html', {'course': Course.objects.all(), 'comments': Comment.objects.first()})

def delete(request, id):
    return render(request, 'courses/delete.html', {'course': Course.objects.get(id=id)})

def destroy(request, id):
    b = Course.objects.get(id=id)
    b.delete()
    messages.success(request, "Course successfully deleted")
    return redirect('/')

def create(request):
    errors = Course.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
    desc_errors = Description.objects.basic_validator(request.POST)
    if len(desc_errors):
        for tag, error in desc_errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    Course.objects.create(name=request.POST['name'])
    c = Course.objects.get(name=request.POST['name'])
    Description.objects.create(desc=request.POST['desc'], course=c)
    print(c)
    return redirect('/')

def comment(request, id):
    return render(request, 'courses/comment.html', {'course': Course.objects.get(id=id)})

def comment_create(request):
    c = Course.objects.get(name=request.POST['name'])
    Comment.objects.create(comment=request.POST['comment'], course=c)
    print(Comment.objects.create(comment=request.POST['comment'], course=c))
    return redirect('/')
