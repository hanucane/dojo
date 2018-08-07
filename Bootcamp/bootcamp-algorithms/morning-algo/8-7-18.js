function rFib(num){
    if (num==0){
        return 0;
    }
    else if (num==1){
        return 1;
    }
    return rFib(num-1)+rFib(num-2)
}
console.log(rFib(12))