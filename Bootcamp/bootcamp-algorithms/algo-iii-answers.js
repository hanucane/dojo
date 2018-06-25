// Print Average
function printAverage(x){
    sum = 0;
    for (var i=0; i<arr.length; i++){
        sum = sum + arr[i];
    }
    var avg = sum / arr.length;
    return avg
}
 y = printAverage([1,2,3]);
 console.log(y); // should log 2
   
 y = printAverage([2,5,8]);
 console.log(y); // should log 5

// Return Odd Array
function returnOddArray(){
    var arr = []
    for (var i=1; i<=255; i+2){
        arr.push(i)
    }
    return arr
 }
 y = returnOddArray();
 console.log(y); // should log [1,3,5,...,253,255]

// Square Value
function squareValue(x){
    for (var i=0; i<x.length; i++) {
        x[i] = x[i] * x[i];
    }
    return x;
 }
 y = squareValue([1,2,3]);
 console.log(y); // should log [1,4,9]
   
 y = squareValue([2,5,8]);
 console.log(y); // should log [4,25,64]