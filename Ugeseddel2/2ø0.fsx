 
let firstName = "Jon"
let lastName = "Sporring"
let name = firstName + " " + lastName
printfn "Hello %s!" name

// Rewrite code in to a single line:

let name2 (firstName: string) (lastName: string) = firstName + " " + lastName 
printfn "Hello %s!" (name2 "Jon" "Sporring")

// or:

(fun (firstName: string) (lastName: string) -> printfn "Hello %s!" (firstName + " " + lastName)) "Jon" "Sporring"