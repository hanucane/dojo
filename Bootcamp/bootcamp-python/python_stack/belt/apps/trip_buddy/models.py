from __future__ import unicode_literals
from django.core.exceptions import ValidationError
from django.core.validators import validate_email
from django.db import models
from ..registration.models import User
from datetime import date
import datetime
import re

class TripManager(models.Manager):
    def basic_validator(self, postData):
        errors = {}
        if postData['from_date'] != "":
            year, month, day = postData['from_date'].split("-")
            from_date = date(int(year), int(month), int(day))
            year, month, day = postData['to_date'].split("-")
            to_date = date(int(year), int(month), int(day))
            if from_date < datetime.date.today():
                errors["from_date"] = "Trip start date must be in the future."
                print(errors['from_date'])
            if to_date < from_date:
                errors["to_date"] = "Trip end date must be after start date."
                print(errors['from_date'])
        else:
            errors['date'] = "Date cannot be empty."
        if len(postData['destination']) == 0:
            errors['destination'] = "Destination cannot be blank"
        if len(postData['destination']) < 2:
            errors["destination"] = "Destination should be 3 or more characters."
        if len(postData['description']) < 2:
            errors["description"] = "Description should be 3 or more characters."
        
        return errors

class Trip(models.Model):
    destination = models.CharField(max_length=255)
    description = models.TextField()
    start_date = models.DateField(auto_now=False, auto_now_add=False)
    end_date = models.DateField(auto_now=False, auto_now_add=False)
    planner = models.ForeignKey(User, related_name="trips_created")

    objects = TripManager()

class Trip_plan(models.Model):
    traveler = models.ForeignKey(User, related_name="trip_joined")
    trip = models.ForeignKey(Trip, related_name="trip_plans")