# 4 basic data types
# print "hello world" # Strings
# print 4 - 3 # Integers
# print True, False # Booleans
# print 4.2 # Floats

# print type("hello world") # Identify data type
# print type(1)
# print type(True)
# print type(4.2)

# Variables
name = "eric" 
# print name
myFavoriteInt = 8
myBool = True
myFloat = 4.2
# print myFavoriteInt
# print myBool
# print myFloat

# Objects
# list => array (referred to as list in Python)
# len() shows the length of the variable / object
myList = [
    name, 
    myFavoriteInt, 
    myBool, 
    myFloat, 
    [myBool, myFavoriteInt, myFloat]
    ]
print len(myList)

# Dictionary
myDictionary = {
    "name": "Eric",
    "title": "Entrepenuer",
    "hasCar": True,
    "favoriteNumber": 8
}
print myDictionary["name"]