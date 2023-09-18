let a = 3.0
let b = 4.0
let f x = a * x + b
let x = 2.0
let y = f x
printfn "%A * %A + %A = %A" a 2.0 b y

// Trace-by-hand

(*

Step 0, Line -, E_0, ()
Step 1, Line 1, E_0, a = 3.0
Step 2, Line 2, E_0, b = 4.0
Step 3, Line 3, E_0, f =((x), 3.0*x + b, a=3,b=4)
Step 4, Line 4, E_0, x = 2.0
Step 5, Line 5, E_0, y = f x = ??
Step 6, Line 5, E_1, f = ((x=2, a*x+b, a=3,x=2,b=4))
Step 7, Line 5, E_1, a*x+b = 10
Step 8, Line 5, E_1, return 10
Step 9, Line 5, E_0, y = 10
Step 10, Line 6, E_0, output af print
Step 11, Line 6, E_0, return ()

*)