(* File RegEx/Absyn.fs
   Abstract syntax for the simple regular expression language 
 *)

module Absyn

type re = 
  | Char of char
  | Eps
  | Seq of re * re
  | Star of re
  | Choice of re * re