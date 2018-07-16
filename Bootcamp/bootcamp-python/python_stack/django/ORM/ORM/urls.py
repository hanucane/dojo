from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.user_login.urls')),
    url(r'^dojo', include('apps.dojo_ninjas.urls')),
    url(r'^library', include('apps.book_authors.urls')),
    url(r'^like', include('apps.like_books.urls')),
    url(r'^admin/', admin.site.urls),
]
