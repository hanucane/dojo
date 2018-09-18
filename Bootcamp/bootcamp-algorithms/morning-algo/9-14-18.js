// HEAP Algorithm example
function parent(idx){
    return Math.floor((idx-1)/2);
}

function leftChild(idx){
    return (idx*2)+1
}

function rightChild(idx){
    return (idx*2)+2
}

function insert(arr, val){
    arr.push(val);
    var childidx = arr.length - 1;
    var parentidx = parent(childidx);
    while (arr[childidx] < arr[parentidx]){
        temp = arr[parentidx];
        arr[parentidx] = arr[childidx];
        arr[childidx] = temp;
        childidx = parentidx;
        parentidx = parent(childidx);
    }
    return arr;
}
insert([1,2,4,3,6], 10)