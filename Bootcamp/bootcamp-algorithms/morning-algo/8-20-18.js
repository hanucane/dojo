function Node(val){
    this.val = null;
    this.left = null;
    this.right = null;
}
// Binary Search Tree with add
function BST(){
    this.root = null;
    this.add(val) = function add(val){
        if (this.root == null){
            this.root= new Node(val);
        }
        else {
            runner = this.root;
            while(runner){
                if(val < runner.val){
                    if(runner.left == null){
                        runner.left = new Node(val);
                    }
                    runner = runner.left;
                }
                if(val >= runner.val){
                    if(runner.right == null){
                        runner.right = new Node(val);
                    }
                    runner = runner.right;
                }
            }
        }
        return this.root;
    }
}