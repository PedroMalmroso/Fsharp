// Definerer rekursiv funktion
let rec readProgrammingLanguage () = 
    let userInput = System.Console.ReadLine ()
    // Bruger match-with funktion til at parre forskellige brugerinput 
    // til actions.
    // Sidste linje er et wildcard der fanger alle øvrige input fra 
    // brugeren.
    match userInput with 
        | "fsharp" -> 
            printfn "F# is cool"
            printfn "Please enter the name of a programming language:"
            readProgrammingLanguage () // Dette er et rekursivt element,
                                       // der sørger for at programmet kører 
                                       // indtil det termineres.
        | "quit" -> exit 0  // Når brugeren skriver "quit" termineres
                            // programmet.
        | _ -> 
            printfn "I don't know %s" userInput
            printfn "Please enter the name of a programming language:"
            readProgrammingLanguage ()

printfn "Please enter the name of a programming language:"
let functionOutput  = readProgrammingLanguage ()
printfn "%A" functionOutput



let b = 3

