from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^register', views.register),
    url(r'^login', views.login),
    url(r'^logout', views.logout),
    url(r'^profile/(?P<id>\d+)', views.profile),
    url(r'^wall/(?P<id>\d+)', views.wall),
    url(r'^message_submit$', views.submit_msg),
    url(r'^message_destroy', views.destroy_msg),
    url(r'^comment_submit$', views.submit_comment),
    url(r'^comment_destroy', views.destroy_comment),
]