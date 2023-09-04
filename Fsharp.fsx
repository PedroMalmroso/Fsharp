let sum x y = x + y
printfn "Adding a and b"
printf "Enter a: "
let a = int (System.Console.ReadLine ())
printf "Enter b: "
let b = int (System.Console.ReadLine ())
let c = sum a b
do printfn "%A + %A = %A" a b c 