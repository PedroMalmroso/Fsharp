type vec = float * float

// addition of vectors 

let add (v1: vec) (v2: vec) =
    let (x1, y1) = v1
    let (x2, y2) = v2
    (x1 + x2, y1 + y2)

let v1 : vec = (2,2)
let v2 : vec = (4,3)
printfn "%A" (add v1 v2)

// multiplication of vector and a constant

let mul (v1: vec) (a: float) = 
    let (x1, y1) = v1
    (a * x1, a * y1)

printfn "%A" (mul v2 3.0)

// rotation of vector

let rot (v1: vec) (a: float) = 
    let (x1, y1) = v1
    (x1 * cos a - y1 * cos a, x1 * sin a + y1 * cos a)

printfn "%A" (rot v2 4.0)