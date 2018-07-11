from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.random_word_gen.urls')),
    url(r'^random_word/', include('apps.random_word_gen.urls')),
    url(r'^admin/', admin.site.urls),
]
