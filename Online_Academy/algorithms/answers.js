// Setting and Swapping
function setSwap(myNumber,myName){
    console.log(myNumber,myName)
    var temp = myNumber;
    var myNumber = myName;
    var myName = temp;
    console.log(myNumber,myName)
}
setSwap(42,'Eric')

// Print -52 to 1066
function print(){
    for (var i = -52; i <= 1066; i++){
        console.log(i);
    }
}
print()

// Don't Worry, Be Happy
function beCheerful(){
    for (var i = 1; i <= 98; i++){
        console.log('good morning!')
    }
}
beCheerful()

// Multiples of Three - but Not All
function multipleThree(){
    for (var i = -7; i >= -300; i--){
        if (i % 3 == 0){
            console.log(i)
        }
    }
}
multipleThree()

// Printing Integers with While
function integersWhile(){
    var i = 2000
    while (i <= 5280){
        console.log(i)
        i++
    }
}
integersWhile()

// You Say It's Your Birthday
function birthday(month, day){
    if (month = 'Jan'){
        if (day === 30){
            console.log('How did you know?')
        } 
        else {
            console.log('Just another day...')
        }
    }
    else {
        console.log('Just another day...')
    }
}
birthday('Jan', 30)
birthday('Feb', 1)

// Leap Year
function leapYear(year){
    if (year % 4 === 0){
        if (year % 100 === 0){
            if (year % 400 === 0){
                console.log('Its a leap year')
            }
            else {
                console.log('Its not a leap year')
            }
        } 
        else {
            console.log('Its a leap year')
        }
    }
}
leapYear(2100)
leapYear(2400)
leapYear(2020)

// Print and Count
function printCount(){
    var count = 0
    for(var i = 512; i <= 4096; i++){
        if (i % 5 === 0){
            console.log(i)
            count = count + 1
        }
    }
    console.log('count =', count)
}
printCount()

// Multiples of Six
function multiplesSix(){
    var i = 6
    while (i <= 6000){
        console.log(i)
        i = i + 6
    }
}
multiplesSix()

// Counting, the Dojo Way
function countDojo(){
    for (var i = 1; i <= 100; i++){
        if (i % 5 === 0){
            console.log('Coding')
            if (i % 10 === 0){
                console.log('Dojo')
            }
        }
        else {
            console.log(i)
        }
    }
}
countDojo()

// What Do You Know?
function wdyk(incoming){
    console.log(incoming)
}
wdyk('What do you know?')

// Whoa, That Sucker's Huge
function mathFun(){
    // For every negative odd integer, there will be a positive odd integer to offset it's value
    console.log(0)
}
mathFun()

// Countdown by Fours
function countdownFours(){
    var i = 2016
    while (i > 0){
        console.log(i)
        i = i - 4;
    }
}
countdownFours()

// Flexible Countdown
function flexibleCountdown(lowNum, highNum, mult){
    for (var i = lowNum; i <= highNum; i++){
        if (i % mult === 0){
            console.log(i)
        }
    }
}
flexibleCountdown(2,9,3)
flexibleCountdown(5,20,4)

// The Final Countdown
function finalCountdown(param1, param2, param3, param4){
    for (var i = param2; i <= param3; i++){
        if (i % param1 === 0){
            if (i !== param4){
                console.log(i)
            }
        }
    }
}
finalCountdown(5,4,17,10)

// Countdown
function countdown(num){
    arr = []
    var count = 0
    for (var i = num; i >= 0; i--){
        arr.push(i)
        count = count + 1
    }
    console.log(arr, count)

}
countdown(5)

// Print and Return
function printReturn(arr){
    console.log(arr[0])
    return console.log(arr[1])
}
printReturn([6, 8])

// First Plus Length
function firstLength(arr){
    if (isNaN(arr[0])){
        console.log('Sorry, only integers in first array position')
    }
    else {
        sum = arr[0] + arr.length;
        console.log(sum)
    }
}
firstLength([2,34,56,7])
firstLength('hello',1,23,45)

// Values Greater than Second
function greatSecond(arr){
    var count = 0
    for (var i = 0; i < arr.length; i++){
        if (arr[i] > arr[1]){
            console.log(arr[i])
            count = count + 1;
        }
    }
    console.log(count)
}
greatSecond([1,3,5,7,9,13])

// Values Greater than Second, Generalized
function greatSecondGen(arr){
    var count = 0
    if (arr.length === 1){
        console.log('Array is too short')
    } 
    else {
        for (var i = 0; i < arr.length; i++){
            if (arr[i] > arr[1]){
                console.log(arr[i])
                count = count + 1;
            }
        } 
        console.log(count)
    }
}
greatSecondGen([1])
greatSecondGen([1,3,5,7,9,13])

// This Length, That Value
function thisThat(num1, num2){
    arr = []
    if (num1 === num2){
        for (var i = 0; i < num1; i++){
            arr.push(num2)
        }
        console.log(arr, 'Jinx!')
    }
    else {
        for (var i = 0; i < num1; i++){
            arr.push(num2)
        }
        console.log(arr)
    }
}
thisThat(5,10)
thisThat(7,7)

// Fit the First Value
function fitFirst(arr){
    if (arr[0] > arr.length){
        console.log("Too Big!")
    }
    else if (arr[0] < arr.length){
        console.log("Too Small!")
    }
    else if (arr[0] === arr.length){
        console.log("Just Right!")
    }
}
fitFirst([4,3,3,2])
fitFirst([1,2,2,3])
fitFirst([5,1,2])

// Fahrenheit to Celsius
function fahrenheitCelsius(fDegrees){
    var cDegrees = 0
    cDegrees = (fDegrees - 32) * 5/9
    console.log(cDegrees)
}
fahrenheitCelsius(98)
fahrenheitCelsius(32)

// Celsius to Fahrenheit
function celsiusFahrenheit(cDegrees){
    var fDegrees = 0
    fDegrees = (9/5 * cDegrees) + 32
    console.log(fDegrees)
}
celsiusFahrenheit(1)
celsiusFahrenheit(23)

// Biggie Size
function makeItBig(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] > 0){
            arr[i] = 'big'
        }
    }
    console.log(arr)
}
makeItBig([1,-2,3,-5])

// Print Low, Return High
function lowHigh(arr){
    var high = arr[0]
    var low = arr[0]

    for (var i = 1; i < arr.length; i++){
        if (arr[i] < low){
            low = arr[i]
        }
        else if (arr[i] > high){
            high = arr[i]
        }
    }
    console.log(low)
    return console.log(high)
}
lowHigh([1,2,8,5,3,7])

// Print One, Return Another
function printOneReturn(arr){
    console.log(arr[arr.length-2])
    for (var i = 0; i < arr.length; i++){
        if (arr[i] % 2 != 0){
            return console.log(arr[i])
        }
    }
}
printOneReturn([2,4,3,6,5])

// Double Vision
function doubleVision(arr){
    arrnew = []
    for (var i = 0; i < arr.length; i++){
        arrnew.push(arr[i]*2)
    }
    console.log(arrnew)
}
doubleVision([1,2,3])

// Count Positives
function countPositives(arr){
    var count = 0

    for (var i = 0; i < arr.length; i++){
        if (arr[i] > 0){
            count = count + 1
        }
    }
    arr.pop()
    arr.push(count)
    return console.log(arr)
}
countPositives([-1,1,1,1])

// Evens and Odds
function evenOdd(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] % 2 != 0){
            if(arr[i+1] % 2 != 0){
                if (arr[i+2] % 2 != 0){
                    console.log('Thats odd!')
                }
            }
        }
        else if (arr[i] % 2 === 0){
            if(arr[i+1] % 2 === 0){
                if (arr[i+2] % 2 === 0){
                    console.log('Even more so!')
                }
            }
        }
    }
}
evenOdd([1,1,1,4,4,4])

// Increment the Seconds
function incrementSeconds(arr){
    for (var i = 0; i < arr.length; i++){
        if (i % 2 != 0){
            arr[i] = arr[i] + 1
        }
    }
    console.log(arr)
}
incrementSeconds([1,2,3,4,5])

// Previous Lengths
function prevLength(arr){
    arrnew = [0]
    for (var i = 1; i <= arr.length; i++){
        var temp = arr[i-1]
        arrnew.push(temp.length)
    }
    console.log(arrnew)
}
prevLength(['hello','world','coding','dojo'])

// Add Seven to Most
function addSeven(arr){
    newarr = []
    for (var i = 1; i < arr.length; i++){
        newarr.push(arr[i]+7)
    }
    console.log(arr)
    console.log(newarr)
}
addSeven([1,2,3,4,5])

// Reverse Array
function reverse(arr){
    arrnew = []
    for (var i = arr.length-1; i >= 0; i--){
        arrnew.push(arr[i])
    }
    console.log(arrnew)
}
reverse([3,1,6,4,2])

// Outlook: Negative
function negative(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] > 0){
            arr[i] = -Math.abs(arr[i])
        }
    }
    console.log(arr)
}
negative([1,-3,5])

// Always Hungry
function hungry(arr){
    var count = 0
    for (var i = 0; i < arr.length; i++){
        if (arr[i] === "food"){
            console.log('yummy')
            count = count + 1
        }
    }
    if (count === 0){
        console.log('Im hungry!')
    }
}
hungry(['food','food',2,4])
hungry([1,2,3])

// Swap Toward the Center
function swapCenter(arr){
    var temp = arr[arr.length-1]
    arr[arr.length-1] = arr[0]
    arr[0] = temp
    if (arr.length % 2 === 0){
        temp = arr[arr.length/2]
        arr[arr.length/2] = arr[(arr.length/2)-1]
        arr[(arr.length/2)-1] = temp
    }
    console.log(arr)
}
swapCenter([true,42,"Ada",2,"pizza"])
swapCenter([1,2,3,4,5,6])

// Scale the Array
function scale(arr, num){
    for (var i = 0; i < arr.length; i++){
        arr[i] = arr[i] * num
    }
    console.log(arr)
}
scale([1,2,3,4,5],4)