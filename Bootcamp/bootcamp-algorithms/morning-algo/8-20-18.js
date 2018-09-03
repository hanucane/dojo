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
            return this.root;
        }
        else {
            runner = this.root;
            while(runner){
                if(val < runner.val){
                    if(runner.left == null){
                        runner.left = new Node(val);
                        return this.root;
                    }
                    runner = runner.left;
                }
                if(val >= runner.val){
                    if(runner.right == null){
                        runner.right = new Node(val);
                        return this.root;
                    }
                    runner = runner.right;
                }
            }
        }
    }
}