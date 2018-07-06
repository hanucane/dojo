# Biggie Size - Given an array, write a function that changes all positive numbers in the array to "big". Example: makeItBig([-1, 3, 5, -5]) returns that same array, changed to [-1, "big", "big", -5].
def biggieSize(arr):
    for count in range(len(arr)):
        if (arr[count] > 0):
            arr[count] = 'big'
    print(arr)
    return arr
biggieSize([-1,3,5,-5])

# Count Positives - Given an array of numbers, create a function to replace last value with number of positive values. Example, countPositives([-1,1,1,1]) changes array to [-1,1,1,3] and returns it.  (Note that zero is not considered to b a positive number).
def countPositives(arr):
    total = 0
    for count in range(len(arr)):
        if (arr[count] > 0):
            total = total + 1
    arr[len(arr)-1] = total
    print(arr)
    return arr
countPositives([-1,1,1,1])

# SumTotal - Create a function that takes an array as an argument and returns the sum of all the values in the array.  For example sumTotal([1,2,3,4]) should return 10
def sumTotal(arr):
    total = 0
    for count in range(len(arr)):
        total = total + arr[count]
    print(total)
    return total
sumTotal([1,2,3,4])

# Average - Create a function that takes an array as an argument and returns the average of all the values in the array.  For example multiples([1,2,3,4]) should return 2.5
def avg(arr):
    total = 0
    for count in range(len(arr)):
        total = total + arr[count]
    avg = total / len(arr)
    print(avg)
    return avg
avg([1,2,3,4])

# Length - Create a function that takes an array as an argument and returns the length of the array.  For example length([1,2,3,4]) should return 4
def length(arr):
    length = len(arr)
    print(length)
    return length
length([1,2,3,4])

# Minimum - Create a function that takes an array as an argument and returns the minimum value in the array.  If the passed array is empty, have the function return false.  For example minimum([1,2,3,4]) should return 1; minimum([-1,-2,-3]) should return -3.
def minimum(arr):
    mini = arr[0]
    for count in range(len(arr)):
        if (arr[count] < mini):
            mini = arr[count]
    print(mini)
    return mini
minimum([1,2,3,4])
minimum([-1,-2,-3])

# Maximum - Create a function that takes an array as an argument and returns the maximum value in the array.  If the passed array is empty, have the function return false.  For example maximum([1,2,3,4]) should return 4; maximum([-1,-2,-3]) should return -1.
def maximum(arr):
    maxi = arr[0]
    for count in range(len(arr)):
        if (arr[count] > maxi):
            maxi = arr[count]
    print(maxi)
    return maxi
maximum([1,2,3,4])
maximum([-1,-2,-3])

# UltimateAnalyze - Create a function that takes an array as an argument and returns a dictionary that has the sumTotal, average, minimum, maximum and length of the array.
def UltimateAnalyze(arr):
    ultimate = {}
    total = 0 
    average = 0 
    mini = arr[0] 
    maxi = arr[0]
    for count in range(len(arr)):
        total = total + arr[count]
    for count in range(len(arr)):
        total = total + arr[count]
    average = total / len(arr)
    for count in range(len(arr)):
        if (arr[count] < mini):
            mini = arr[count]
    for count in range(len(arr)):
        if (arr[count] > maxi):
            maxi = arr[count]
    ultimate['total'] = total
    ultimate['average'] = average
    ultimate['minimum'] = mini
    ultimate['maximum'] = maxi
    ultimate['length'] = len(arr)
    print(ultimate)
UltimateAnalyze([1,2,3,4,5,6,7,8])

# ReverseList - Create a function that takes an array as an argument and return an array in a reversed order.  Do this without creating an empty temporary array.  For example reverse([1,2,3,4]) should return [4,3,2,1]. This challenge is known to appear during basic technical interviews.
def reverseList(arr):
    for count in range(len(arr)//2):
        temp = arr[count]
        arr[count] = arr[len(arr)-(1+count)]
        arr[len(arr)-(1+count)] = temp
    print(arr)
    return arr
reverseList([1,2,3,4])