public class Tokenizer extends Source{

    private Token head;
    private int size;

    public Tokenizer(String str){
        super(str);
        //head = new Token(TokenKind.Number);
    }

    public Token tokenize(){
        size = 1;

        while(idx < str.length()){
            isspace();

            if(isSymbol()){
                Token tk = new Token(TokenKind.Symbol);
                tk.setChar(peek());
                newToken(tk);
                seek();
                continue;
            }
            if(Character.isDigit(peek())){
                Token tk = new Token(TokenKind.Number);
                tk.setVal(number());
                newToken(tk);
                continue;
            }

            System.out.println("error: tokenize");
        }

        Token tk = new Token(TokenKind.EOF);
        newToken(tk);

        return head;
    }
    
    private Token nth(int n){
        int i = 1;
        Token tk = head;
        while(tk != null){
            if(i == n){
                return tk;
            }
            i++;
            tk = tk.getNext();
        }
        return null;
    }

    public void newToken(Token tk){
        if(size == 1){
            head = tk;
            size++;
            return;
        }

        Token cur = nth(size-1);
        cur.setNext(tk);
        size++;
    }

    public void isspace(){
        while(peek() == ' '){
            seek();
        }
    }

    public boolean isSymbol(){
        if(peek() == '+' || peek() == '-' || peek() == '*' || peek() == '/' || peek() == '(' || peek() == ')'){
            return true;
        }
        return false;
    }

    public final int number(){
        int ch;
        StringBuilder sb = new StringBuilder();

        while((ch = peek()) >= 0 && Character.isDigit(ch)){
            sb.append((char)ch);
            seek();
        }

        return Integer.parseInt(sb.toString());
    }
}
