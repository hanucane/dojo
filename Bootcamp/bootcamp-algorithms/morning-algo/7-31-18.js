function Node(val){
    this.value = val;
    this.next = null;
}
function SList(val){
    this.head = null;
    this.add = Node(val);
    this.addFront = function(val){
        var nn = new Node(val);
        nn.next = this.head;
        this.head = nn;
    }
    this.KthFromLast = function(k){
        var count = 0;
        var runner = this.head;
        while(runner){
            krunner = runner;
            while(krunner){
                count += 1;
                krunner = krunner.next;
            }
            if (count == k){
                return this.runner;
            }
            else if (count < k){
                return null;
            }
            else {
                count = 0;
                runner = runner.next
            }
        }
    }
    this.KthFromLast2 = function(k){
        var count = 0;
        var runner = this.head;
        var krunner = this.head;
        while(runner.next != null){
            runner = runner.next;
            count += 1;
            if (count > k){
                krunner = krunner.next;
            }
        }
        if (k > count){
            return null;
        }
        else {
            return krunner;
        }
    }
}
list = SList(6)
list.addFront(5)
list.addFront(4)
list.addFront(7)
list.addFront(9)
list.KthFromLast(2)