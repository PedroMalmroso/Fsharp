let allPairs lst1 lst2 =
    lst1
    |> List.map (fun x -> 
        lst2 
        |> List.map (fun y -> (x, y)))
    |> List.concat


printfn "%A" (allPairs [0;1;2] ['a';'b';'c'])