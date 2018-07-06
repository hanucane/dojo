function countChar(str){
    var char = {}
    for (var i=0; i<str.length; i++){
        if (char[str[i].toLowerCase()] == null){
            char[str[i].toLowerCase()] = 1;
        }
        else if (char[str[i].toLowerCase()] != null){
            char[str[i].toLowerCase()] += 1;
        }
    }
    return char
}
print(countChar('Welcome to the Coding Dojo'))