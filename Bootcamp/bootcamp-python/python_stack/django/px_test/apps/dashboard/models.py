from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.core.validators import validate_email
from django.db import models
import re

class UserManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if len(postData['first_name']) < 2:
            errors["first_name"] = "First name should be 3 or more characters."
        if len(postData['last_name']) < 2:
            errors["last_name"] = "Last name should be 3 or more characters."
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
        return errors

class User(models.Model):
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=256)
    user_level = models.SmallIntegerField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    
    objects = UserManager()


class Message(models.Model):
    message = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    user = models.ForeignKey(User, related_name="messages")

class Response(models.Model):
    reponse = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    user = models.ForeignKey(User, related_name="responses")
    message = models.ForeignKey(Message, related_name="responses")