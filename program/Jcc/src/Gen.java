import java.util.Stack;

public class Gen {
    private int left;
    private int right;
    private int sum;

    private Stack<Integer> st;

    Gen(){
        st = new Stack<Integer>();
    }

    public void analysis(Node node){
        if(node.getKind() == NodeKind.ND_NUM){
            st.push(node.getVal());
            return;
        }

        analysis(node.getLeftNode());
        analysis(node.getRightNode());

        right = st.pop();
        left = st.pop();

        switch(node.getKind()){
            case ND_ADD:
                System.out.println("add  " + left + " " + right);
                sum = left + right;
                break;
            case ND_SUB:
                System.out.println("sub  " + left + " " + right);
                sum = left - right;
                break;
            case ND_MUL:
                System.out.println("mul  " + left + " " + right);
                sum = left * right;
                break;
            case ND_DIV:
                System.out.println("div  " + left + " " + right);
                sum = left / right; 
                break;
            default:
                System.out.println("error at gen()");
        }

        st.push(sum);
    }

    public int popStack(){
        return st.pop();
    }
}
