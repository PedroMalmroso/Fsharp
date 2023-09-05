//1ø4
//printf "Hello, what is your name: "
//let a: string = string (System.Console.ReadLine())
//printfn "Hello %s"  a // %s = string, %A general 

//1ø5 Cannot mix different types. Either make both Integers or both floats.

//1ø6
//let mutable i = 1
//while i<=10 do 
 //   printfn "%d" i
 //   i <- i+1

//1ø7

let rec Counter n = 
    match n with
        | _ when n>10 -> ()
        | _ ->  printfn "%d" n
                Counter(n+1)
Counter 3










