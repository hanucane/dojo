from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.blog.urls')),
    url(r'^blog/', include('apps.blog.urls')),
    url(r'^admin/', admin.site.urls),
]
