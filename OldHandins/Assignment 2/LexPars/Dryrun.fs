module Dryrun

    open System;;
    open Parse;;
    
    printfn "Using fromString: on %s" "1+2*3."
    let ex = fromString "1 + 2*3"
    printfn "ex is: %A \n" ex
    
    printfn "Using fromString: on %s" "1-2-3."
    let ex1 = fromString "1-2-3"
    printfn "ex1 is: %A \n" ex1
    
    printfn "Using fromString: on %s" "1+-2."
    let ex2 = fromString "1 + -2"
    printfn "ex2 is: %A \n" ex2
    
    //let ex3 = fromString "x++";;
    
    //let ex4 = fromString "1 + 1.2";;
    
    //let ex5 = fromString "1 + ";;
    
    printfn "Using fromString: on %s" "let z = (17) in z + 2*3end"
    let ex6 = fromString "let z = (17) in z + 2*3end"
    printfn "ex6 is: %A \n" ex6
    
    //let ex7 = fromString "let z = 17) in z + 2*3end";;
    //let ex8 = fromString "let in = (17) in z + 2*3end";;
    
    printfn "Using fromString: on %s" "1 + let x=5 in let y=7+x in y+y end + x end"
    let ex9 = fromString "1 + let x=5 in let y=7+x in y+y end + x end"
    printfn "ex9 is: %A \n" ex9
    
    let ex10 = compString "1 + let x=5 in let y=7+x in y+y end + x end"
    printfn "ex10 is: %A \n" ex10