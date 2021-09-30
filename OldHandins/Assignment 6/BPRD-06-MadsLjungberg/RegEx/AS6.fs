open Parse;;


(* Assignment 6.1/Exercise 1.4 *)

let o1 = parse "'a' | 'b' *";;
// val it : Absyn.re = Choice (Char 'a',Star (Char 'b'))

let o2 = parse "'a'|'b'*";;
// val it : Absyn.re = Choice (Char 'a',Star (Char 'b'))

let o3 = parse "'a' * 'a' 'a'";;
// val it : Absyn.re = Seq (Star (Char 'a'),Seq (Char 'a',Char 'a'))

let o4 = parse "'a' 'b' * | 'c'";;
// val it : Absyn.re = Choice (Seq (Char 'a',Star (Char 'b')),Char 'c')

let o5 = parse "( 'a' ('b' *) ) | 'c'";;
// val it : Absyn.re = Choice (Seq (Char 'a',Star (Char 'b')),Char 'c')

let o6 = parse "( ('a' 'b') * | 'b') *";;
// val it : Absyn.re = Star (Choice (Star (Seq (Char 'a',Char 'b')),Char 'b'))

let o7 = parse "'a' 'b' eps";;
// val it : Absyn.re = Seq (Char 'a',Seq (Char 'b',Eps))

(* Assignment 6.2/Exercise 1.5 
The lexer has been implemented simply by using two rules. One for tokens and one specifically for characters.
Whitespaces are ignored by moving to the next token and newlines are implemented by moving to the first token
on the next line. 
Characters are matched by matching on an apostrophe followed by the character followed by another apostrophe. 
This is done through the second rule, which is reached when the first apostrophe is matched in the first rule. 
The second rule then checks using regex for one character between a-zA-Z-0-9 ending in another apostrophe. 
The other tokens such as "*" "|" and epsilon have been implemented by returning token identifiers for the parser to use,
i.e. TIMES and OR. 
In the parser, the various tokens are defined and their precedence. Using %left, we can define that "*" has higher precedence
than sequences of regular expressions (SEQ), which have higher precedence than "|". Since SEQ is not a terminal that can be matched
on in the grammar, a %prec directive has to be used in the specification for sequences (Re Re) so that the precedence can be defined. 
The rest of the grammar has been implemented normally by parsing the tokens into the defined abstract syntax in Absyn.fs. 

Specific troubles have been figuring out how the epsilon had to be implemented, since it is usually not a part of writing regexes. 
Another was figuring out how to match on apostrophe followed by a character followed by another apostrophe, and how the use of a seperate
rule solved that. *)

