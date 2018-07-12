from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register$', views.register),
    url(r'^registered$', views.success),
    url(r'^login$', views.login),
    url(r'^profile$', views.profile),
    url(r'^logout$', views.logout),
    url(r'^reset$', views.reset)
]