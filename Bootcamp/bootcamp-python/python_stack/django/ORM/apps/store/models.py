from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.db import models

class Inventory(models.Model):
    item_name = models.CharField(max_length=255)
    item_desc = models.TextField()
    price = models.FloatField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)