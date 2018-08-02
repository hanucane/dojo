function has_loop(SLL){
    var current = this.next;
    while (current) {
        if(current.next = this.head){
            return true;
        }
        else {
            var node_arr = [];
            node_arr.push(current)
            for (var i = 0; i < node_arr; i++){
                if (arr[i] == current.next){
                    return true;
                }
            }
        }
    }
    return false;
}

function break_loop(SLL){
    var current = this.next;
    while (current) {
        if(current.next = this.head){
            current.next = null;
            return current;
        }
        else {
            var node_arr = [];
            node_arr.push(current)
            for (var i = 0; i < node_arr; i++){
                if (arr[i] == current.next){
                    current.next = null;
                    return current;
                }
            }
        }
    }
    return false;
}