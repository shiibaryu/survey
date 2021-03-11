// Generated from Calc.g4 by ANTLR 4.9
import org.antlr.v4.runtime.tree.ParseTreeListener;

/**
 * This interface defines a complete listener for a parse tree produced by
 * {@link CalcParser}.
 */
public interface CalcListener extends ParseTreeListener {
	/**
	 * Enter a parse tree produced by {@link CalcParser#lines}.
	 * @param ctx the parse tree
	 */
	void enterLines(CalcParser.LinesContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalcParser#lines}.
	 * @param ctx the parse tree
	 */
	void exitLines(CalcParser.LinesContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalcParser#equation}.
	 * @param ctx the parse tree
	 */
	void enterEquation(CalcParser.EquationContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalcParser#equation}.
	 * @param ctx the parse tree
	 */
	void exitEquation(CalcParser.EquationContext ctx);
	/**
	 * Enter a parse tree produced by {@link CalcParser#expr}.
	 * @param ctx the parse tree
	 */
	void enterExpr(CalcParser.ExprContext ctx);
	/**
	 * Exit a parse tree produced by {@link CalcParser#expr}.
	 * @param ctx the parse tree
	 */
	void exitExpr(CalcParser.ExprContext ctx);
}