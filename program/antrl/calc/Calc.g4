grammar Calc;
lines:
     | equation
     | lines equation
     | EOF;
equation : expr CR
	 | expr EOF;
expr  : '(' expr ')'
      | expr '*' expr
      | expr '/' expr
      | expr '+' expr
      | expr '-' expr
      | N
      | '-' N
      | '-' '(' expr ')' ;
N     : [0-9]
      | [1-9][0-9]+;
CR  : [\n;];          
WS : [ \t]+ -> skip ;