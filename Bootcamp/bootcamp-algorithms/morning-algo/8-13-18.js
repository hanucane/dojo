function inOrderSubset(str, result='', arr=[], start=0){
    if(start==str.length){
        arr.push(result);
        return arr
    }
    inOrderSubset(str, result, arr, start)
    result = result + str[start];
    inOrderSubset(str, result, arr, start+1)
    return arr
}
inOrderSubset("Eric")