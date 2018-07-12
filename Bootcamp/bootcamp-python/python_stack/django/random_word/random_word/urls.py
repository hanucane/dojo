from django.conf.urls import url, include
from django.contrib import admin

urlpatterns = [
    url(r'^', include('apps.random_word_gen.urls')),
    url(r'^random_word/', include('apps.random_word_gen.urls')),
    url(r'^session_words/', include('apps.session_words.urls')),
    url(r'^admin/', admin.site.urls),
]
