from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.core.validators import validate_email
from django.db import models
import re

class UserManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if len(postData['name']) < 2:
            errors["name"] = "Name should be 3 or more characters."
        try:
            validate_email(postData['email'])
        except ValidationError:
            errors["email"] = "Enter a valid email address."
        while True:
            password = postData['password']
            if len(postData['password']) < 8:
                errors["password"] = "Password must be at least 8 characters long."
            elif re.search('[0-9]',password) is None:
                errors["password"] = "Password must have a number in it."
            elif re.search('[A-Z]',password) is None:
                errors["password"] ="Password must have an uppercase letter in it."
            elif password != postData['pw_confirm']:
                errors["password"] = "Your password must match."
            break
        if len(postData['email']) == 0:
            errors['email'] = "Email cannot be empty"
        return errors

class User(models.Model):
    name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=256)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    
    objects = UserManager()