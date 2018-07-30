from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
import datetime
import bcrypt

from .models import *

def index(request):
    me = User.objects.get(id=request.session['user_id'])
    include = Trip_plan.objects.filter(traveler=me)
    objects = {
        'current_trips': Trip.objects.filter(trip_plans=Trip_plan.objects.filter(traveler=me)),
        'available_trips': Trip.objects.filter(trip_plans=Trip_plan.objects.exclude(traveler=me)),
        'user': me
    }
    if request.session['logged_in'] == False:
        messages.error(request, "You must be logged in to view that page", extra_tags="login")
        return redirect('/')
    else:
        return render(request, 'trip_buddy/dashboard.html', objects)

def trip(request, id):
    print(Trip_plan.objects.filter(trip=id))
    objects = {
        'trip': Trip.objects.get(id=id),
        'travelers': Trip_plan.objects.filter(trip=id)
    }
    return render(request, 'trip_buddy/trip_view.html', objects)

def trip_add(request):
    return render(request, 'trip_buddy/trip_create.html')

def trip_create(request):
    errors = Trip.objects.basic_validator(request.POST)
    if len(errors):
        for tag, error in errors.items():
            messages.error(request, error, extra_tags=tag)
        return redirect('/addtrip')
    else:
        trip = Trip.objects.create(destination=request.POST['destination'], description=request.POST['description'], start_date=request.POST['from_date'], end_date=request.POST['to_date'], planner=User.objects.get(id=request.session['user_id']))
        Trip_plan.objects.create(traveler=User.objects.get(id=request.session['user_id']), trip=trip)

        return redirect('/travels')

def trip_delete(request, id):
    trip = Trip.objects.get(id=id)
    trip.delete()
    return redirect('/travels')

def trip_join(request, id):
    traveler = User.objects.get(id=request.session['user_id'])
    trip_obj = Trip.objects.get(id=id)
    Trip_plan.objects.create(traveler=User.objects.get(id=request.session['user_id']), trip=trip_obj)
    return redirect('/view/'+str(id))

def trip_remove(request, id):
    trip = Trip.objects.get(id=id)
    traveler = User.objects.get(id=request.session['user_id'])
    trip_plan = Trip_plan.objects.get(trip=trip, traveler=traveler)
    trip_plan.delete()
    return redirect('/travels')
