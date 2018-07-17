from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages

from .models import *

def index(request):
    return render(request, 'store/index.html', {'items': Inventory.objects.all(), 'range': range(11)})

def buy(request):
    request.session['current'] = float(request.POST['quantity']) * float(request.POST['price'])
    if 'total' not in request.session:
        request.session['total'] = float(request.session['current'])
    else:
        request.session['total'] = float(request.session['total']) + float(request.session['current'])
    if 'items_purchased' not in request.session:
        request.session['items_purchased'] = int(request.POST['quantity'])
    else:
        request.session['items_purchased'] = int(request.POST['quantity']) + int(request.session['items_purchased'])
    return redirect('/amadon/checkout')

def checkout(request):
    return render(request, 'store/checkout.html')
