function Slist(val){
    this.head = null;
    this.add = Node(val);
    this.addFront = function(val){
        var nn = new Node(val);
        nn.next = this.head;
        this.head = nn;
    }
}
function Node(val){
    this.value = val;
    this.next = null;
}
this.addFront = function(val){
    var nn = new Node(val);
    nn.next = this.head;
    this.head = nn;
}
slist = Slist()
console.log(slist)