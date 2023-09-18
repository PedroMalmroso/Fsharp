(* //a
let rec fac n: int = 
    match n with
        | 0 -> 1
        | _ when n > 0 ->   n*fac(n-1)
        | _ ->  printfn "N/A"; exit 0

//b
printfn "Calculating factorial of input integer"
printf "Enter n: "
let n = int(System.Console.ReadLine ())
let result = fac (n)
printfn "%d! = %A" n result
 *)


//c
let rec fac64 n: int64 = 
    match n with
        | 0L -> 1L
        | _ when n > 0L ->   n*fac64(n - 1L)
        | _ ->  printfn "N/A"; exit 0

printfn "Calculating factorial of input integer"
printf "Enter n: "
let n = int64(System.Console.ReadLine ())
let result = fac64 (n)
printfn "%d! = %A" n result







// int = 12!
// int64 = 20!



(* let mutable i = 1
while i>0 do
    printfn "%A=n, fac n = %A" i (fac i)
    i <-i+1
    if (fac i) = 0 then exit 0 


 *)


