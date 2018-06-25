// Biggie Size - Given an array, write a function that changes all positive numbers in the array to "big".  Example: makeItBig([-1,3,5,-5]) returns that same array, changed to [-1, "big", "big", -5].
function makeItBig(arr){
    for (var i=0; i<arr.length; i++){
        if (arr[i] > 0){
            arr[i] = "big";
        }
    }
    console.log(arr);
    return arr
}
makeItBig([-1,3,5,-5])

// Print Low, Return High - Create a function that takes array of numbers.  The function should print the lowest value in the array, and return the highest value in the array.
function lowHigh(arr){
    var min = arr[0];
    var max = arr[0];
    for (var i=1; i<arr.length; i++){
        if (arr[i] > max){
            max = arr[i];
        }
        if (arr[i] < min){
            min = arr[i];
        }
    }
    console.log(min);
    return max
}
lowHigh([5,3,7,1,4])

// Print One, Return Another - Build a function that takes array of numbers.  The function should print second-to-last value in the array, and return first odd value in the array.
function printReturn(arr){
    console.log(arr[arr.length-2]);
    for (var i = 0; i<arr.length; i++){
        if (arr[i] % 2 != 0){
            return arr[i]
        }
    }
}
printReturn([4,2,7,5,3])

// Double Vision - Given array, create a function to return a new array where each value in the original has been doubled.  Calling double([1,2,3]) should return [2,4,6] without changing original.
function doubleVision(arr){
    for (var i = 0; i<arr.length; i++){
        arr[i] = arr[i] * 2;
    }
    console.log(arr);
    return arr
}
doubleVision([1,2,3])

// Count Positives - Given array of numbers, create function to replace last value with number of positive values.  Example, countPositives([-1,1,1,1]) changes array to [-1,1,1,3] and returns it.
function countPositives(arr){
    var count = 0;
    for (var i=0; i<arr.length; i++){
        if (arr[i]>0){
            count = count+1;
        }
        if (arr[i] === arr[arr.length-1]){
            arr.pop();
            arr.push(count);
        }
    }
    console.log(arr);
    return arr
}
countPositives([-1,1,1,1])

// Evens and Odds - Create a function that accepts an array.  Every time that array has three odd values in a row, print "That's odd!".  Every time the array has three evens in a row, print "Even more so!"
function evenOdd(arr){
    for (var i=0; i<arr.length; i++){
        if (arr[i] % 2 != 0){
            if (arr[i+1] % 2 != 0){
                if (arr[i+2] % 2 != 0){
                    console.log("That's odd!")
                }
            }
        }
        if (arr[i] % 2 == 0){
            if (arr[i+1] % 2 == 0){
                if (arr[i+2] % 2 == 0){
                    console.log("Even more so!")
                }
            }
        }
    }
}
evenOdd([1,7,5,2,4,6])

// Increment the Seconds - Given an array of numbers arr, add 1 to every second element, specifically those whose index is odd (arr[1], [3], [5], etc).  Afterward. console.log each array value and return arr.
function incrementSeconds(arr){
    for (var i=0; i<arr.length; i++){
        if (i % 2 != 0){
            arr[i] = arr[i] + 1;
        }
        console.log(arr[i])
    }
    console.log(arr);
    return arr
}
incrementSeconds([2,2,4,4,6,6])

// Previous Lengths - You are passed an array containing strings.  Working within that same array, replace each string with a number - the length of the string at previous array index - and return the array.  For example, previousLengths(["hello", "dojo", "awesome"]) should return ["hello", 5, 4].
function previousLengths(arr){
    var temp = arr[0];
    for (var i=1; i<arr.length; i++){
        var x = arr[i];
        arr[i] = temp.length;
        temp = x;
    }
    console.log(arr)
    return arr
}
previousLengths(["hello", "dojo", "awesome"])

// Add Seven to Most - Build function that accepts array. Return a new array with all values except first, adding 7 to each. Do not alter the original array.
function sevenMost(arr){
    var newarr = []
    for (var i=1; i<arr.length; i++){
        newarr.push(arr[i]+7)
    }
    console.log(arr, newarr)
    return newarr
}
sevenMost([2,6,3,1,4])

// Reverse Array - Given an array, write a function that reverses values, in-place.  Example: reverse([3,1,6,4,2]) return same array, containing [2,4,6,1,3].  Do this without creating an empty temporary array.  (Hint: you'll need to swap values).
function reverse(arr){
    for (var i=0; i<arr.length/2; i++){
        temp = arr[i];
        arr[i] = arr[arr.length-(i+1)];
        arr[arr.length-(i+1)] = temp;
    }
    console.log(arr)
}
reverse([3,1,6,4,2])

// Outlook: Negative - Given an array, create and return a new one containing all the values of the provided array, made negative (not simply multiplied by -1). Given [1,-3,5], return [-1,-3,-5].
function negative(arr){
    for (var i=0; i<arr.length; i++){
        if (arr[i]>0){
            arr[i] = -arr[i];
        }
    }
    console.log(arr);
}
negative([1,-3,5])

// Always Hungry - Create a function that accepts an array, and prints "yummy" each time one of the values is equal to "food".  If no array elements are "food", then print "I'm hungry" once.
function hungry(arr){
    var count = 0;
    for(var i=0; i<arr.length; i++){
        if (arr[i] == "food"){
            console.log("yummy");
            count = count + 1;
        }
    }
    if (count === 0){
        console.log("I'm hungry");
    }
}
hungry(['food', 1,2,4])
hungry([1,2,3,4])

// Swap Toward the Center - Given array, swap first and last, third and third-to-last, etc.  Input[true,42,"Ada",2,"pizza"] becomes ["pizza", 42, "Ada", 2, true].  Change [1,2,3,4,5,6] to [6,2,4,3,5,1].
function reverse(arr){
    for (var i=0; i<arr.length/2; i++){
        temp = arr[i];
        arr[i] = arr[arr.length-(i+1)];
        arr[arr.length-(i+1)] = temp;
    }
    console.log(arr)
}
reverse(["pizza",42,"Ada",2,true])
reverse([1,2,3,4,5,6])

// Scale the Array - Given an array arr and a number num, multiply all values in arr by num, and return the changed array arr.  For example, scaleArray([1,2,3],3) should return [3,6,9].
function scaleArray(arr, x){
    for (var i=0; i<arr.length; i++){
        arr[i] = arr[i] * x;
    }
    console.log(arr)
    return arr
}
scaleArray([1,2,3],3)