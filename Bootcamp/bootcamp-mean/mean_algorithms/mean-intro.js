function maxMinAvg(arr){
    var max = arr[0]
    var min = arr[0]
    var sum = arr[0]
    for(var x = 1; x < arr.length; x++){
        if(arr[x] > max){
            max = arr[x]
        }
        else if (arr[x] < min){
            min = arr[x]
        }
        sum += arr[x]
    }
    var avg = sum / arr.length

    return console.log("The minimum is "+min+", the maximum is "+max+", and the average is "+avg+".")
}

function fizzbuzz(int){
    if (typeof int === 'string'){
        return console.log("Must enter a positive integer")
    }
    for (var x = 1; x <= int; x++)
    {
        if (x % 3 == 0 && x % 5 == 0){
            console.log("FizzBuzz")
        }
        else if (x % 3 == 0){
            console.log("Fizz")
        }
        else if (x % 5 == 0){
            console.log("Buzz")
        }
        else{
            console.log(x)
        }
    }
}
