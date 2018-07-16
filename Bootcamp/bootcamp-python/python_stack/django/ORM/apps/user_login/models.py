from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.db import models

class UserManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if len(postData['first_name']) < 3:
            errors["first_name"] = "First name should be 3 or more characters."
        if len(postData['last_name']) < 3:
            errors["last_name"] = "Last name should be 3 or more characters."
        if len(postData['age']) < 2:
            errors["age"] = "Age should be double digits."
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email_address = models.CharField(max_length=255)
    age = models.IntegerField()
    created_at = models.DateTimeField(auto_now_add = True)
    updated_at = models.DateTimeField(auto_now = True)

    objects = UserManager()
