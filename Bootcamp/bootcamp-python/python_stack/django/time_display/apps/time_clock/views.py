from django.shortcuts import render, HttpResponse, redirect
from time import localtime, strftime


def index(request):
    context = {
        "date": strftime("%Y-%m-%d", localtime()),
        "time": strftime("%I:%M %p", localtime())
    }
    return render(request, 'time_clock/index.html', context)
