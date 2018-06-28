function isSupervocalic(str){
    var count ={'a':0, 'e':0, 'i':0, 'o':0, 'u':0}
    for (var i=0; i<str.length; i++){
        if (str[i] == 'a' || str[i] == 'e' || str[i] == 'i' || str[i] == 'o' || str[i] == 'u'){
            count[str[i]] = count[str[i]] + 1;
        } 
    }
    console.log(count)
    for (j in count){
        if (count[j] != 1){
            return console.log(false)
        }
    }
    return console.log(true)
}
isSupervocalic('sequoia')
isSupervocalic('train')

function isSupervocalic(str){
    var count ={'a':0, 'e':0, 'i':0, 'o':0, 'u':0}
    for (var i=0; i<str.length; i++){
        if (str[i] in count){
            count[str[i]] = count[str[i]] + 1;
        } 
    }
    console.log(count)
    for (j in count){
        if (count[j] != 1){
            return console.log(false)
        }
    }
    return console.log(true)
}