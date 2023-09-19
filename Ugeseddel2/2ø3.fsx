(*--------------------------------------a------------------------------------------*)

//1) The function should take two integer arguments and return x^n by recursion.


//8)


/// the power function takes in two integer values and returns x ** n for positive n.
/// <summary> Find x ** n when x, n are integers, and n positive. </summary>
/// <param name = "x"> The integer to be exponentiated. </param>
/// <param name = "n"> The exponent, n => 0. </param>
/// <returns> The solution to x ** n as an integer. </returns>
let rec power (x: int) (n: int) =
    match n with
    | 0 -> 1
    // | _ when n < 0 -> 1 / x * power x (n + 1)
    | _ -> x * power x (n - 1)

printfn "%A" (power 2 2) // 3) i princippet.

 
(*--------------------------------------b------------------------------------------*)
 
let powerTuple (tuple: int*int) = 
    match tuple with
        (x, n) -> power x n

printfn "%A" (powerTuple(2,2))

 