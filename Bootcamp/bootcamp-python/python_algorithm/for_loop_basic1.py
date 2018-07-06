# Basic - Print all the numbers/integers from 0 to 150.
def basic():
    for count in range(0,151):
        print('Counting -', count)
basic()

# Multiples of Five - Print all the multiples of 5 from 5 to 1,000,000.
def multiplesFives():
    for count in range(5,1000000):
        if (count % 5 == 0):
            print('Multiples of five -', count)
multiplesFives()

# Counting, the Dojo Way - Print integers 1 to 100.  If divisible by 5, print "Coding" instead. If by 10, also print " Dojo".
def countingDojo():
    for count in range(1,101):
        if (count % 5 == 0 and count % 10 != 0):
            print('Coding')
        elif (count % 10 == 0):
            print('Dojo')
        else:
            print('count -', count)
countingDojo()

# Whoa. That Sucker's Huge - Add odd integers from 0 to 500,000, and print the final sum.
def huge():
    sum = 0
    for count in range(0,500001):
        if (count % 2 != 0):
            sum=sum+count
    print(sum)
huge()

# Countdown by Fours - Print positive numbers starting at 2018, counting down by fours (exclude 0).
def countdown():
    for count in reversed(range(1,2018)):
        if (count % 4 == 0):
            print('Countdown - ', count)
countdown()

# Flexible Countdown - Based on earlier "Countdown by Fours", given lowNum, highNum, mult, print multiples of mult from lowNum to highNum, using a FOR loop.  For (2,9,3), print 3 6 9 (on successive lines)
def flexCountdown(lowNum, highNum, mult):
    for count in reversed(range(lowNum, highNum+1)):
        if (count % mult == 0):
            print('Flexible Countdown - ', count)
flexCountdown(2,9,3) 

# Predictions
# 1) 3, 5, 1, 2
# 2) 0, 1, 2, 3 - > List cannot be interpreted as an integer
# 3) 0, 1, 2, 3
