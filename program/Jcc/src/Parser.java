public class Parser extends Node{
    /*
    expr       = equality
    equality   = relational ("==" relational | "!= relational")*
    relational = add ("<" add | "<=" add | ">" add | ">=" add)*
    add        = mul ("+" mul | "-" mul)
    mul        = unary ("*" unary | "/" unary)*
    unary      = ("+" | "-")? primary
    primary    = num | "(" expr ")"
    */

    int idx;
    Token token;

    public Parser(NodeKind kind,Token tk){
        super(kind);
        token = tk;
        idx = 1;
    }

    public Node expr(){
        Node node = mul();

        for(;;){
            if(token.getChar() == '+'){
                consume();
                node = newNodeOperator(NodeKind.ND_ADD,node,mul());
            }
            else if(token.getChar() == '-'){
                consume();
                node = newNodeOperator(NodeKind.ND_SUB,node,mul());
            }
            else{
                return node;
            }
        }
    }

    public Node mul(){
        Node node = unary();

        for(;;){
            if(token.getChar() == '*'){
                consume();
                node = newNodeOperator(NodeKind.ND_MUL,node,unary());
            }
            else if(token.getChar() == '/'){
                consume();
                node = newNodeOperator(NodeKind.ND_DIV,node,unary());
            }
            else{
                return node;
            }
        }
    }

    public Node unary(){
        if(token.getChar() == '+'){
            consume();
            return prim();
        }
        if(token.getChar() == '-'){
            consume();
            Node node = newNodeOperator(NodeKind.ND_SUB,newNodeNumber(NodeKind.ND_NUM, 0), prim());
            return node;
        }

        return prim();
    }

    public Node prim(){

        if(token.getChar() == '('){
            consume();
            Node node = expr();
            //consume();
            if(token.getChar() != ')'){
                System.out.println("error at prim");
            }
            consume();
            return node;
        }
        else if(token.getVal() >= 0){
            Node node = newNodeNumber(NodeKind.ND_NUM,token.getVal());
            consume();
            return node;
        }
        else{
            System.out.println("error at prim");
            return null;
        }
    }

    private void consume(){
        idx++;
        token = token.next;
    }

}