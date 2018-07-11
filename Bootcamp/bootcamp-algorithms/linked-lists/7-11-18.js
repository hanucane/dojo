// Check linked list length
function count(){
    var runner = this.head
    var count = 0
    while (runner){
        count += 1;
        runner = runner.next;
    }
    return count
}
// Contains
function contains(value){
    var runner = this.head
    while (runner){
        if (runner.val == value){
            return true;
        }
        else if (runner.next == null){
            return false;
        }
    }
}
