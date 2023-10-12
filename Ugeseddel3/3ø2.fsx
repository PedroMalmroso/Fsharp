let rec rev (lst: 'T list) =
    match lst with
    | [] -> []
    | head :: tail -> (rev tail) @ [head]

printfn "%A" (rev [1;2;3])