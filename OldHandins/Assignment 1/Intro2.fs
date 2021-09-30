(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

    let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)]

    let emptyenv = [] (* the empty environment *)

    let rec lookup env x =
        match env with 
        | []        -> failwith (x + " not found")
        | (y, v)::r -> if x=y then v else lookup r x
    
    let cvalue = lookup env "c"
    
    
    (* Object language expressions with variables *)
    
    type expr = 
      | CstI of int
      | Var of string
      | Prim of string * expr * expr
      (* 1.1 - (iv) *)
      | If of expr * expr * expr
    
    let e1 = CstI 17
    
    let e2 = Prim("+", CstI 3, Var "a")
    
    let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a")
    
    
    (* 1.1 - (ii) *)
    let e4 = Prim("Min", CstI 2, CstI 1)
    
    let e5 = Prim("Max", CstI 400, CstI 200)
    
    let e6 = Prim("==", CstI 5, CstI 5)
    
    let e7 = Prim("==", Prim("Min", CstI 9, CstI 5), Prim("Max", CstI 3, CstI 5))
    
    let e8 = If(Var "a", CstI 11, CstI 22)
    
    (* Evaluation within an environment *)
    
    let rec eval e (env : (string * int) list) : int =
        match e with
        | CstI i                -> i
        | Var x                 -> lookup env x 
        | Prim("Min", e1, e2)   -> 
                                    let left = eval e1 env
                                    let right = eval e2 env
                                    if left < right then
                                        left
                                    else 
                                        right
        | Prim("Max", e1, e2)   -> 
                                    let left = eval e1 env          (* This is almost the task of 1.1 (iii) The task is about limitting the major match param and only mattch on the operand
                                                                         since instead of having Prim("every possible operand", e1, e2) repeated. 
                                                                         Since you know it is a primitive that takes 2 Expr you can fetch the values of those first and then match on the operand*)
                                    let right = eval e2 env
                                    if left > right then
                                        left
                                    else
                                        right
        (* This was only for fun as with the others Min/Max the same procedure could have been applied*)
        | Prim("==", e1, e2)    -> if (eval (Prim("-", e1, e2)) env) = 0 then // Unnecessary extra step ? instead of an if this then that. and this works only for numbers.
                                    1
                                    else
                                    0
        | Prim("+", e1, e2)     -> eval e1 env + eval e2 env
        | Prim("*", e1, e2)     -> eval e1 env * eval e2 env
        | Prim("-", e1, e2)     -> eval e1 env - eval e2 env
        | Prim _                -> failwith "unknown primitive"
        (* 1.1 - (v) *)
        | If(e1, e2, e3)        -> if (eval e1 env) = 0 then eval e3 env else eval e2 env (* This can cause troubles *)
    
    
    (* 1.1 - (ii) *)
    (* let rec eval (env : (string * int) list) : int =
        match e with
        | CstI x -> x
        | Var v -> lookup env v)
        | Prim(ope,e1,e2) ->
            let i1 = eval e1 env
            let i2 = eval e2 env
            match ope with
            | "+"   -> i1 + i2
            | "*"   -> i1 * i2
            | "-"   -> i1 - i2
            | "Min" -> if i1 < i2 then i1 else i2
            | "Max" -> if i1 > i2 the i1 else i2
            | "=="  -> if i1 = i2 the CstI 1 else CstI 0
            | _     -> "Unknown primitive"
        | If(e1, e2, e3) -> if (eval e1 env) = 0 then eval e3 env else eval e2 env
        | _              -> "Unknown expr!"
    *)
    
    let e1v  = eval e1 env
    let e2v1 = eval e2 env
    let e2v2 = eval e2 [("a", 314)]
    let e3v  = eval e3 env
    
    (* 1.1 - (ii) *)
    let emin = eval e4 env
    let emax = eval e5 env
    let eeq = eval e6 env
    let abstraction = eval e7 env (*Should use emptyenv*)
    
    (* 1.1 - (v) *)
    let five = eval e8 env
    
    
    (* 1.2 *)
    
    (* 1.2 - (i) *)
    
    type aexpr =
        | CstI of int
        | Var of string
        | Add of aexpr * aexpr
        | Mul of aexpr * aexpr
        | Sub of aexpr * aexpr
    
    
    (* 1.2 - (ii) *)
    let rep1 = Sub(Var "v", Add(Var "w", Var "z"))
    let rep2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
    let rep3 = Add(Var "x", Add(Var "y", Add(Var "z", Var "v")))
    
    let sim = Add(Var "x", CstI 0)
    let sim2 = Add(Add(CstI 2, CstI 0), Mul(CstI 0, Var "f"))
    
    (* 1.2 - (iii) *)
    let rec fmt e =
        match e with
        | CstI i    -> string i 
        | Var c     -> c
        | Add(ae1, ae2) -> "(" + fmt ae1 + " + " + fmt ae2 + ")"
        | Mul(ae1, ae2) -> fmt ae1 + " * " + fmt ae2
        | Sub(ae1, ae2) -> "(" + fmt ae1 + " - " + fmt ae2 + ")"
    
    (* 1.2 - (iv) *)
    let rec simplify ae = 
        match ae with
        | CstI i -> CstI i
        | Var x -> Var x
        | Add(CstI 0, e) -> simplify e
        | Add(e, CstI 0) -> simplify e 
        | Mul(CstI 0, e) -> CstI 0
        | Mul(e, CstI 0) -> CstI 0
        | Sub(CstI 0, e) -> simplify e
        | Sub(e, CstI 0) -> simplify e
        | Sub(e, e1)      -> if e = e1 then CstI 0 else Sub(simplify e, simplify e1)
        | _              -> ae
    
        (* if e1 == CstI 0 then just use e2 *)
    
    (* 1.2 - (v) *) // Hmm might need to read up on differentiations.
    let rec diff aexpr y =
        match aexpr with
        | CstI i                -> CstI 0
        | Var c                 -> if c = y then CstI 1 else CstI 0
        | Add(ae1, ae2)         -> Add(diff ae1 y, diff ae2 y)
        | Mul(ae1, ae2)         -> Add(Mul(diff ae1 y, ae2), Mul(ae1 , diff ae2 y))
        | _                     -> failwith "malformed expression"

        //| Sub(ae1, ae2)			-> Sub(diff ae1	y, diff ae2 y)
        //| Var c 	when c = y -> CstI 1 // value or name ? --- if c=y then CstI 1 else CstI 0
        //| Var c 	when c != y -> CstI 0
    (* So: Mul(Div(aexpr, Mul(aexpr, Var "x")), CstI ?) = 0 *)
    
    (* Utillity *)
    let format1 = fmt rep1
    let simply1 = simplify sim
    let simply2 = simplify sim2
    
    