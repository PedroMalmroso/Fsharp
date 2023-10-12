let dist (p1: int*int) (p2: int*int) = 
    let x1, y1 = p1
    let x2, y2 = p2
    (x2-x1)*(x2-x1) + (y2-y1)*(y2-y1)

//Example
printfn "%A" (dist (1,1) (3,3))