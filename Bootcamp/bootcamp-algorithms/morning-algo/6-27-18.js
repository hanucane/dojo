// reverseString(str)
function reverseString(str){
    var newstr = "";
    for (var i=str.length-1; i>=0; i--){
        newstr = newstr + str[i]
    }
}

// reverseArray(arr){
function reverseArray(arr){    
    for (var i=0; i<arr.length/2; i++){
        var temp = arr[i];
        arr[i] = arr[arr.length-(i+1)];
        arr[arr.length-(i+1)] = temp;
    }
    return arr
}