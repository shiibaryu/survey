enum NodeKind{
    ND_ADD,
    ND_SUB,
    ND_MUL,
    ND_DIV,
    ND_NUM
}

public class Node {
    private NodeKind kind;
    private Node lhs;
    private Node rhs;
    private int val;

    public Node(NodeKind kind){
        this.kind = kind;
    }

    public Node newNodeOperator(NodeKind nk,Node lhs,Node rhs){
        Node node = new Node(nk);
        node.lhs = lhs;
        node.rhs = rhs;

        return node;
    }

    public Node newNodeNumber(NodeKind nk,int val){
        Node node = new Node(nk);
        node.val = val;

        return node;
    }

    public void setKind(NodeKind kind){
        this.kind = kind;
    }

    public NodeKind getKind(){
        return kind;
    }

    public void setLeftNode(Node node){
        this.lhs = node;
    }

    public Node getLeftNode(){
        return lhs;
    }

    public void setRightNode(Node node){
        this.rhs = node;
    }

    public Node getRightNode(){
        return rhs;
    }

    public int getVal(){
        return val;
    }

    public void setVal(int val){
        this.val = val;
    }
}
