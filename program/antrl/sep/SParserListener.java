// Generated from SParser.g4 by ANTLR 4.9
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link SParser}.
 */
public interface SParserListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link SParser#lines}.
	 * @param ctx the parse tree
	 */
	void enterLines(SParser.LinesContext ctx);
	/**
	 * Exit a parse tree produced by {@link SParser#lines}.
	 * @param ctx the parse tree
	 */
	void exitLines(SParser.LinesContext ctx);
	/**
	 * Enter a parse tree produced by {@link SParser#command}.
	 * @param ctx the parse tree
	 */
	void enterCommand(SParser.CommandContext ctx);
	/**
	 * Exit a parse tree produced by {@link SParser#command}.
	 * @param ctx the parse tree
	 */
	void exitCommand(SParser.CommandContext ctx);
	/**
	 * Enter a parse tree produced by {@link SParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(SParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link SParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(SParser.ExprContext ctx);
}