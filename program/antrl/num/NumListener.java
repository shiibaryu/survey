// Generated from Num.g4 by ANTLR 4.9
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link NumParser}.
 */
public interface NumListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link NumParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(NumParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link NumParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(NumParser.ExprContext ctx);
}