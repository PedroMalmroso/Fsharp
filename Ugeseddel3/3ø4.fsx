let avg (lst: float list) = 
    let addLst acc elm = acc + elm
    (List.fold addLst 0.0 lst) / (float (List.length lst))

printfn "%A" (avg [1.0;2.0;3.0;4.0])
