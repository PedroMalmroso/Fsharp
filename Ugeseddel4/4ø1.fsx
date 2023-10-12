let rec length lst =
    match lst with
    | [] -> 0
    | _ :: xs -> 1 + length xs

printfn "%A" (length [0;1;2])
