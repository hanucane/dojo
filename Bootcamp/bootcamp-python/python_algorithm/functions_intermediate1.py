# Random Interval
import random

def randomInt():
    num = random.random()*100
    print(int(num))    
randomInt()

def randomInt2(limit):
    num = random.random()*limit
    print(int(num))
randomInt2(50)

def randomInt3(minlimit):
    num = random.random()*100
    if (num > minlimit):
        print(int(num))
    else:
        randomInt3(minlimit)
randomInt3(50)

def randomInt4(minlimit, maxlimit):
    num = random.random()*maxlimit
    if (num > minlimit):
        print(int(num))
    else:
        randomInt4(minlimit, maxlimit)
randomInt4(50, 500)