function censor(str, word){
    var newstr = ""
    for (var j=0; j<str.length; j++){
        if (str[j] == word[0]){
            for (var i=1; i<word.length; i++){
                if (word[i] != str[j+i]){
                    newstr += str[j];
                    break
                }
                else if (i == word.length-1){
                    for (var k=0; k<word.length; k++){
                        newstr += "x";
                    }
                    j += word.length-1;
                }
            }
        }
        else {
            newstr += str[j]
        }
    }
    console.log(newstr)
    return newstr
}
censor('Today is Tuesday', 'day')
censor('The warden is in the psych ward from the war', 'war')