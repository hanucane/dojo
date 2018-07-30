from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^registration$', views.registration),
    url(r'^login$', views.login),
    url(r'^logout$', views.logout),
    url(r'^books$', views.books),
    url(r'^books/add$', views.book_review),
    url(r'^books/submit$', views.book_review_submit),
    url(r'^books/(?P<id>\d+)$', views.book),
    url(r'^book/(?P<id>\d+)/review$', views.add_review),
]