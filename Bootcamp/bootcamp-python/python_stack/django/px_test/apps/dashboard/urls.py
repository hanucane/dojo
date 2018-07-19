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
    url(r'^logout$', views.logout),
    url(r'^users/new$', views.new),
    url(r'^users/create$', views.create),
    url(r'^users/edit/(?P<id>\d+)$', views.edit),
    url(r'^users/update/(?P<id>\d+)$', views.update),
    url(r'^users/destroy/(?P<id>\d+)$', views.destroy),
    url(r'^edit_profile/(?P<id>\d+)$', views.edit_self),
    url(r'^update_profile/(?P<id>\d+)$', views.update_self),
    url(r'^update_description$', views.update_description),
    url(r'^users/show/(?P<id>\d+)$', views.show),
    url(r'^message_submit', views.msg_submit),
    url(r'^message_destroy', views.msg_destroy),
    url(r'^response_submit', views.resp_submit),
    url(r'^response_destroy', views.resp_destroy),
]