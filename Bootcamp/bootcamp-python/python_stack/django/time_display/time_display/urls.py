from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.time_clock.urls')),
    url(r'^time_display/', include('apps.time_clock.urls')),
    url(r'^admin/', admin.site.urls),
]
