// PART ONE
// Sigma - Implement function sigma(num) that given a number, returns the sum of all positive integers up to number (inclusive).  Ex: sigma(3) = 6 (or 1+2+3); sigma(5) = 15 (or 1+2+3+4+5).
function sigma(num){
    var sum = 0;
    for (var i=num; i>0; i--){
        sum = sum + num;
    }
    return console.log(sum)
}
sigma(3)
sigma(5)

// Factorial - Write a function factorial(num) that, given a number, returns the product (multiplication) of all positive integers from 1 up to number (inclusive).  For example, factorial(3) = 6 (or 1*2*3); factorial(5) = 120 (or 1*2*3*4*5).
function factorial(num){
    var total = 0;
    for (var i=num; i>0; i--){
        total = total * num;
    }
    return console.log(total)
}
factorial(3)
factorial(5)

// Fibonacci - Create a function to generate Fibonacci numbers.  In this famous mathematical sequence, each number is the sum of the previous two, starting with values 0 and 1.  Your function should accept one argument, an index into the sequence (where 0 corresponds to the initial value, 4 corresponds to the value four later, etc).  Examples: fibonacci(0) = 0 (given), fibonacci(1) = 1 (given), fibonacci(2) = 1 (fib(0)+fib(1), or 0+1), fibonacci(3) = 2 (fib(1) + fib(2)3, or 1+1), fibonacci(4) = 3 (1+2), fibonacci(5) = 5 (2+3), fibonacci(6) = 8 (3+5), fibonacci(7) = 13 (5+8).  Do this without using recursion first.  If you don't know what a recursion is yet, don't worry as we'll be introducing this concept in Part 2 of this assignment.
function fibonacci(num){
    var fib = [0,1,1,2];
    var next = 0;
    if (num > 4){
        for (var i=4; i<=num; i++){
            next = fib[i-1] + fib[i-2];
            fib.push(next);
        }
    }
    else {
        return console.log(fib[num-1]);
    }
    return console.log(fib[fib.length-1])
}
fibonacci(5)

// Array: Second-to-Last: Return the second-to-last element of an array. Given [42, true, 4, "Liam", 7], return "Liam".  If array is too short, return null.
function secondToLast(arr){
    if (arr.length < 2){
        return null;
    }
    return console.log(arr[arr.length-2])
}
secondToLast([42, true, 4, "Liam", 7])

// Array: Nth-to-Last: Return the element that is N-from-array's-end.  Given ([5,2,3,6,4,9,7],3), return 4.  If the array is too short, return null.
function nthToLast(arr, x){
    if (arr.length < x){
        return null;
    }
    return console.log(arr[arr.length-(x)])
}
nthToLast([5,2,3,6,4,9,7],3)

// Array: Second-Largest: Return the second-largest element of an array. Given [42,1,4,3.14,7], return 7.  If the array is too short, return null.
function secondLargest(arr){
    var max = arr[0]
    var nextmax = arr[1]
    for (var i=1; i<arr.length; i++){
        if (arr[i] > max){
            nextmax = max;
            max = arr[i];
        } 
        else if (arr[i] < max){
            if (arr[i] > nextmax){
                nextmax = arr[i];
            }   
        }
    }
    console.log(max, nextmax)
    return nextmax
}
secondLargest([42,1,4,3.14,7])

// Double Trouble: Create a function that changes a given array to list each existing element twice, retaining original order.  Convert [4, "Ulysses", 42, false] to [4,4, "Ulysses", "Ulysses", 42, 42, false, false].
function repeatTwice(arr){
    for (var i=0; i<arr.length; i+=2){
        for (var x=arr.length-1; x>i-1; x--){
            arr[x+1] = arr[x];
        }
        arr[i+1] = arr[i];
    }
    console.log(arr);
}
repeatTwice([4,'Ulysses', 42, false])

// PART TWO
// Create a function Fib(n) where it returns the nth Fibonacci number.  Use recursion for this.
function fib(n){
    if (n==0 || n==1){
        return n;
    }
    else {
        var num1 = fib(n-2);
        var num2 = fib(n-1);
        var x = num1 + num2;
        return x;
    }
    return console.log(x);
}
fib(5)
fib(7)

