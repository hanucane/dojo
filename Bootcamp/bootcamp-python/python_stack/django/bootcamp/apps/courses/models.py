from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.db import models

class CourseManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if len(postData['name']) < 6:
            errors["name"] = "Course name should be more that 5 characters."
        return errors

class DescManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if len(postData['desc']) < 16:
            errors["desc"] = "Course description should be more that 15 characters."
        return errors

class Course(models.Model):
    name = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    objects = CourseManager()

class Description(models.Model):
    desc = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    course = models.OneToOneField(Course, on_delete=models.CASCADE, primary_key=True)

    objects = DescManager()

class Comment(models.Model):
    comment = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    course = models.ForeignKey(Course, related_name="comments")