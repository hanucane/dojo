from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^travels', views.index),
    url(r'^view/(?P<id>\d+)', views.trip),
    url(r'^addtrip$', views.trip_add),
    url(r'^createtrip$', views.trip_create),
    url(r'^deletetrip/(?P<id>\d+)$', views.trip_delete),
    url(r'^join/(?P<id>\d+)', views.trip_join),
    url(r'^canceltrip/(?P<id>\d+)$', views.trip_remove),
]