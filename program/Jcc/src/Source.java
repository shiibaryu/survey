public class Source{

    public int idx;
    public String str;

    public Source(String str){
        this.str = str;
    }

    public void seek(){
        idx++;
    }

    public char peek(){
        if(idx < str.length()){
            return str.charAt(idx);
        }
        System.out.println("error: peek() at idx " + idx);
        return (char)-1;
    }
}