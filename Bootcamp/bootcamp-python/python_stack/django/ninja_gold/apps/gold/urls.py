from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^roll', views.roll),
    url(r'^reset', views.reset)
]