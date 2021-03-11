public class App {

    public static void printDbg(String args)
    {
        System.out.println("error: " + args);
    }

    public static void main(String[] args) throws Exception {
        Token s = new Tokenizer("100+(10+10)*10").tokenize();
        Token tk = new Tokenizer("-(10+10)+30").tokenize();
        Parser pr = new Parser(NodeKind.ND_ADD, tk);
        Node node = pr.expr();
        Gen gen = new Gen();
        gen.analysis(node);

        System.out.println(gen.popStack());
        

        return;
    }
}
