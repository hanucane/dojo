from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
import bcrypt

from .models import *

def index(request):
    if "logged_in" not in request.session:
        request.session['logged_in'] = False
        request.session['user_id'] = None
    return render(request, 'book_review/index.html')

def registration(request):
    errors = User.objects.basic_validator(request.POST)
    set_level = User.objects.all()
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/')
    else:
        password = request.POST['password']
        hashed = bcrypt.hashpw(password.encode('utf-8'), bcrypt.gensalt())
        request.session['logged_in'] = True
        User.objects.create(name=request.POST['name'], alias=request.POST['alias'], email=request.POST['email'], password=hashed)
        request.session['user_id'] = User.objects.get(email=request.POST['email']).id
        messages.success(request, "You successfully registered!")
        return redirect('/')
    
def login(request):
    password = request.POST['password']
    hashed = User.objects.get(email=request.POST['email']).password
    if User.objects.get(email=request.POST['email']):
        if bcrypt.checkpw(password.encode('utf-8'), hashed.encode('utf-8')):
            request.session['logged_in'] = True
            request.session['user_id'] = User.objects.get(email=request.POST['email']).id
            messages.success(request, "You are signed in")
            return redirect('/books')
    messages.error(request, "You could not be logged in")
    return redirect('/')

def logout(request):
    request.session.clear()
    return redirect('/')

def books(request):
    if request.session['logged_in'] == True:
        all_authors = Author.objects.all()
        all_books = Book.objects.all()
        all_reviews = Review.objects.all()
        objects = {
            'authors': all_authors,
            'books': all_books,
            'reviews': all_reviews
        }
        return render(request, "book_review/dashboard.html", objects)
    else:
        messages.error(request, "You need to be logged in to see that.")
        return redirect('/')

def book_review(request):
    all_authors = Author.objects.all()
    objects = {
        'authors': all_authors,
        'stars': [1,2,3,4,5]
    }
    return render(request, "book_review/book_review.html", objects)

def book_review_submit(request):
    if request.POST['enter_author'] != "":
        author_name = Author.objects.create(name=request.POST['enter_author'])
        book = Book.objects.create(title=request.POST['title'], author=author_name)
        Review.objects.create(comment=request.POST['review'], rating=request.POST['rating'], user=User.objects.get(id=request.session['user_id']), book=book)
        book_id = Book.objects.get(title=request.POST['title']).id
        return redirect('/books/'+str(book_id))
    else:
        author_name = Author.objects.get(name=request.POST['exist_author'])
        book = Book.objects.create(title=request.POST['title'], author=author_name)
        Review.objects.create(comment=request.POST['review'], rating=request.POST['rating'], user=User.objects.get(id=request.session['user_id']), book=book)
        
        return redirect('/books')

def book(request, id):
    book = Book.objects.get(id=id)
    objects = {
        'book': book,
        'stars': [1,2,3,4,5]
    }
    return render(request, "book_review/book.html", objects)

def add_review(request, id):
    Review.objects.create(comment=request.POST['review'], rating=request.POST['rating'], user=User.objects.get(id=request.session['user_id']), book=Book.objects.get(id=id))
    return redirect('/books/'+str(id))