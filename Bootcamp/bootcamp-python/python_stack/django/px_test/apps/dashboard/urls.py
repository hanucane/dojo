from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^signin$', views.signin),
    url(r'^register$', views.registration),
    url(r'^registration$', views.register),
    url(r'^dashboard/admin$', views.admin_dash),
    url(r'^dashboard$', views.dash),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout)
]