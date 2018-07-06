name ="keyword operator from-rainbow">= "Joe Blue" # storing a string
age = 35 # storing an int
weight = 160.57 # storing a float
dead = False # storing a boolean
ninjas = ['Rozen', 'KB', 'Oliver']
new_person = {"name":"John","age":35,"weight":160.2,"dead":False} # storing dictionaries
# list
my_list = ['4', ['list', 'in', 'a', 'list'], 987]
empty_list = []
print(ninjas[0])
print(ninjas[1])
print(ninjas[2])
print(len(ninjas)) # prints the length of the ninjas list
ninjas.append("Michael") # adds Michael to the end of ninjas list
# ninjas.pop() # pops the last value from the list
# ninjas.pop(1) # pops index 1 from list
ninjas[2] = 'John'
# if statements
if age >= 18:
    print('Your age is above 18.')
elif age == 17:
    print('You are seventeen.')
else:
    print('You are so young!')
# for loops
for count in range(0,5):
    print("looping - ", count)
# looping through an array
for element in ninjas:
    print(element)
# define a function that returns the sum of two numbers
def sum(a,b):
    print("a:", a, "b:", b)
    return a+b
print(sum(3,5))
print(sum(2,4)+sum(1,5))
# define a function that says hello to the name provided
# this starts a new block
def say_hello(name=""):
    # these lines are indented and therefore part of the function
    if name:
        print('Hello, ' + name + ', from inside the function')
    else:
        print('No name')
# now we're unindented and have ended the previous block
print('outside of the function')