# import the python testing framework
import unittest
# out "unit"
# this is what we are running our test on
def reverseArray(list):
    for i in range(int(len(list)/2)):
        list[i], list[len(list)-i-1] = list[len(list)-i-1], list[i]
    return list

def isPalindrome(str):
    for i in range(int(len(str)/2)):
        if str[i] != str[len(str)-i-1]:
            return False
    return True

def change(cents):
    change = {'quarters':0,'dimes':0,'nickels':0,'pennies':0}
    while cents > 0:
        if cents >= 25:
            change["quarters"] += 1
            cents -= 25
        elif cents >= 10:
            change["dimes"] += 1
            cents -= 10
        elif cents >= 5:
            change["nickels"] += 1
            cents -= 5
        elif cents >= 1:
            change["pennies"] += 1
            cents -= 1
    return change

# our "unit tests"
# initialized by creating a lass that inherits from unittest.TestCase
class reverseArrayTests(unittest.TestCase):
    # each method in this class is a test to be run
    def testOne(self):
        self.assertEqual(reverseArray([1,2,3]), [3,2,1])
    def testTwo(self):
        self.assertEqual(reverseArray([1,3,2,5]), [5,2,3,1])
    # any task you want to run before method above is executed
    def testThree(self):
        self.assertEqual(reverseArray([2,6,4,3,5]), [5,3,4,6,2])
    def setUp(self):
        # add the setUp tasks
        print("running setUp")
    # any task you want to run after the tests are executed
    def tearDown(self):
        print('running tearDown tasks')

class isPalindromeTests(unittest.TestCase):
    def test1(self):
        self.assertEqual(isPalindrome("racecar"), True)
    def test2(self):
        self.assertEqual(isPalindrome("fruit"), False)
    def test3(self):
        self.assertEqual(isPalindrome("malam"), True)
    def setUp(self):
        # add the setUp tasks
        print("running setUp")
    # any task you want to run after the tests are executed
    def tearDown(self):
        print('running tearDown tasks')

class changeTests(unittest.TestCase):
    def test1(self):
        self.assertEqual(change(89), {'quarters':3,'dimes':1,'nickels':0,'pennies':4})
    def test2(self):
        self.assertEqual(change(119), {'quarters':4,'dimes':1,'nickels':1,'pennies':4})
    def test3(self):
        self.assertEqual(change(43), {'quarters':1,'dimes':1,'nickels':1,'pennies':3})
    def setUp(self):
        # add the setUp tasks
        print("running setUp")
    # any task you want to run after the tests are executed
    def tearDown(self):
        print('running tearDown tasks')

if __name__ == '__main__':
    unittest.main()
