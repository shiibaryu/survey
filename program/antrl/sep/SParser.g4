parser grammar SParser;
options { tokenVocab=SLex; }

lines:
     | command
     | lines command
     | EOF;
command : expr EL;
expr  : LBR expr RBR 
      | expr MUL expr 
      | expr DIV expr
      | expr ADD expr 
      | expr SUB expr 
      | N 
      | SUB N 
      | SUB LBR expr RBR ;
