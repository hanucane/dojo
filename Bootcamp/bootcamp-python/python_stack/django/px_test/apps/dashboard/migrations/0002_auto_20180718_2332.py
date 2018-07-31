# -*- coding: utf-8 -*-
# Generated by Django 1.10 on 2018-07-18 23:32
from __future__ import unicode_literals

from django.db import migrations, models
import django.db.models.deletion


class Migration(migrations.Migration):

    dependencies = [
        ('dashboard', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='message',
            name='msg_receiver',
            field=models.ForeignKey(on_delete=django.db.models.deletion.CASCADE, related_name='rec_messages', to='dashboard.User'),
        ),
    ]