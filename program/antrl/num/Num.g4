grammar Num;
expr  : N;
N     : [0-9]+;
WS : [ \t\r\n]+ -> skip ;
