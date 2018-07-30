from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.registration.urls')),
    url(r'^', include('apps.trip_buddy.urls')),
    url(r'^admin/', admin.site.urls),
]
