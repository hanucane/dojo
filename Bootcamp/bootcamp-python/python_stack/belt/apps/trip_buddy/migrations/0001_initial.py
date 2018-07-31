# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2018-07-20 21:07
from __future__ import unicode_literals

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    initial = True

    dependencies = [
        ('registration', '0001_initial'),
    ]

    operations = [
        migrations.CreateModel(
            name='Trip',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('destination', models.CharField(max_length=255)),
                ('description', models.TextField()),
                ('start_date', models.DateField()),
                ('end_date', models.DateField()),
                ('planner', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='trips_created', to='registration.User')),
            ],
        ),
        migrations.CreateModel(
            name='Trip_plan',
            fields=[
                ('id', models.AutoField(auto_created=True, primary_key=True, serialize=False, verbose_name='ID')),
                ('traveler', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='trip_joined', to='registration.User')),
                ('trip', models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='trip_plans', to='trip_buddy.Trip')),
            ],
        ),
    ]