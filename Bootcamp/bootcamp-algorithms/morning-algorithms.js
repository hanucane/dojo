// Remove Duplicate
function removeDuplicate(arr){
    for (var i=0; i<arr.length; i++){
      for (var j=i+1; j<arr.length; j++){
        if (arr[i]===arr[j]){
          for (var x=j; x<arr.length-1; x++){
             arr[x] = arr[x+1];
          }
          i--;
          arr.pop();
          console.log(arr)
        }
      }
    }
    console.log(arr);
    return arr
  }
  removeDuplicate([1,1,1,2,3,4,4,4])