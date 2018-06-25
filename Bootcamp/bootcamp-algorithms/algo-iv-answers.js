// Given an array and a value Y, count and print the number of array values greater than Y.
function countPrint(arr, Y){
    var count = 0;
    for (var i=0; i<arr.length; i++){
        if (arr[i]>Y){
            count = count+1;
            console.log(arr[i])
        }
    }
    console.log(count);
    return count
}
countPrint([1,2,3,4,5], 2)

// Given an array, print the max, min and average values for that array.
function maxMinAvg(){
    var max = arr[0];
    var min = arr[0];
    var sum = arr[0];
    for (var i = 1; i < arr.length; i++){
        if (arr[i] > max){
            max = arr[i];
        }
        if (arr[i] < min){
            min = arr[i];
        }
        sum = sum + arr[i];
    }
    var avg = sum / arr.length;
    var arrnew = [max, min, avg];
    console.log(arrnew); 
    return arrnew
}
maxMinAvg([1,5,10,-2])

// Given an array of numbers, create a function that returns a new array where negative values were replaced with the string ‘Dojo’.   For example, replaceNegatives( [1,2,-3,-5,5]) should return [1,2, "Dojo", "Dojo", 5].
function dojoNegatives(arr){
    for (var i = 0; i < arr.length; i++){
        if (arr[i] < 0){
            arr[i] = "Dojo";
        }
    }
    console.log(arr);
    return arr
}
dojoNegatives([1,2,-3,-5,5])

// Given array, and indices start and end, remove vals in that index range, working in-place (hence shortening the array).  For example, removeVals([20,30,40,50,60,70],2,4) should return [20,30,70].
function removeAt(arr, idx){
    for(var i=idx; i<arr.length-1; i++){
        arr[x]=arr[x+1];
    }
    arr.pop();
    console.log(arr);
    return arr;
}
function removeVals(arr,start,end){
    for (var i=start; i<=end; i++){
        removeAt(arr, i);
    }
    console.log(arr);
    return arr
}
removeVals([20,30,40,50,60,70],2,4)