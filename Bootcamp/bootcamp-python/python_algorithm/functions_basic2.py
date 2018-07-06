# Countdown - Create a function that accepts a number as an input.  Return a new array that counts down by one, from the number (as arrays 'zero'th element) down to 0 (as the last element).  For example countDown(5) should return [5,4,3,2,1,0].
def countdown(num):
    arr = []
    for count in reversed(range(num+1)):
        arr.append(count)
    print(arr)
countdown(5)

# Print and Return - Your function will receive an array with two numbers. Print the first value, and return the second.
def printReturn(p,r):
    print(p)
    return r
printReturn(1561,2412)

# First Plus Length - Given an array, return the sum of the first value in the array, plus the array's length.
def firstLength(arr):
    sum = arr[0] + len(arr)
    print(sum)
firstLength([4,3,2,6])

# Values Greater than Second - Write a function that accepts any array, and returns a new array with the array values that are greater than its 2nd value.  Print how many values this is.  If the array is only element long, have the function return False
def valsGreater(arr):
    arr2 = []
    for count in range(len(arr)):
        if (arr[count]>arr[1]):
            arr2.append(arr[count])
    print('Original array -', arr, 'New array -', arr2)
valsGreater([1,5,7,3,6,9])

# This Length, That Value - Write a function called lengthAndValue which accepts two parameters, size and value. This function should take two numbers and return a list of length size containing only the number in value. For example, lengthAndValue(4,7) should return [7,7,7,7].
def lengthAndValue(length, value):
    arr = []
    for count in range(length):
        arr.append(value)
    print(arr)
lengthAndValue(5,3)