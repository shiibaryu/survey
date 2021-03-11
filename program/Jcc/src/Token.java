enum TokenKind{
    Symbol,
    Number,
    EOF
}

public class Token{
    private TokenKind kind;
    private int val;
    private char tk;
    //private String tk;
    Token next;

    
    public Token(TokenKind kind){
        this.kind = kind;
    }

    public TokenKind getKind(){
        return kind;
    }

    public int getVal(){
        return val;
    }

    public char getChar(){
        return tk;
    }

    /*
    public String getString(){
        return tk;
    }
    */

    public Token getNext(){
        return next;
    }

    public void setKind(TokenKind kind){
        this.kind = kind;
    }

    public void setVal(int val){
        this.val = val;
    }

    public void setChar(char tk){
        this.tk = tk;
    }

    public void setNext(Token next){
        this.next = next;
    }
}
