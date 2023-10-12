let divTwo (lst: int list) = 
    List.map (fun x ->  (float x) / 2.0) lst
    
printfn "%A" (divTwo [1;2;3])

