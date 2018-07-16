from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^create$', views.create),
    url(r'^comment/(?P<id>\d+)$', views.comment),
    url(r'^comment/create$', views.comment_create),
    url(r'^delete/(?P<id>\d+)$', views.delete),
    url(r'^destroy/(?P<id>\d+)$', views.destroy),
]