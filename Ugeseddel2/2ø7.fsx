//a)
type vec3 = float*float*float

//b)
let a: vec3 = (4.0,3.0,7.0)
printfn "%A" a

//c.i)
let squaredSum (tuple: vec3) = 
    match tuple with
        (x,y,z) -> x * x + y * y + z * z   

printfn "%A" (squaredSum a)

//c.ii)

let squaredSum2 (tuple: vec3) = 
    let (x,y,z) = tuple
    x * x + y * y + z * z

printfn "%A" (squaredSum2 a)

//c.iii)

let squaredSum3 (x,y,z) = 
    x * x + y * y + z * z

printfn "%A" (squaredSum3 a)