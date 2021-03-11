lexer grammar SLex;

N     : [0-9]
      | [1-9][0-9]+;
ADD   : '+'; 
SUB   : '-'; 
MUL   : '*'; 
DIV   : '/'; 
SB    : '=';
LBR   : '(';
RBR   : ')';
EL : [;];          
WS : [ \t\r\n]+ -> skip ; 
