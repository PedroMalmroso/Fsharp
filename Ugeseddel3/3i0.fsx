type ff = float * float

/// <summary> This function returns a list of n random (x,y)-coordinates in a (float * float) list, 
/// with a center around the point p, contained in a box as specified by dp. </summary>
/// <example> 
/// The following code: 
///     <code>
///         let a = makeRandomPositions (200,100) (100,100) 10
///         printfn "%A" a
///     </code>
/// </example>
/// <param name = "p"> Center of random placements of (x,y)-coordinates. Int * int. </param>
/// <param name = "dp"> Size of the box in which the random points are to be contained. Int * int. </param>
/// <param name = "n"> Number of random (x,y)-coordinates generated in the box. Integer. </param>
/// <returns> (float * float) type list of n random coordinate pairs.  </returns>
let makeRandomPositions (p: int*int) (dp: int*int) (n: int) : ff list =
    let pX, pY = p // midpoint
    let dpX, dpY = dp // Size of box containing random roots to tree.
    let rnd = System.Random()
    let minX = float pX  - float dpX / 2.0 // Define the smallest value the x-coordinate can take. This entails a symmetrical box around p. 
    let maxX = float pX  + float dpX / 2.0
    let minY = float pY  - float dpY / 2.0
    let maxY = float pY  + float dpY / 2.0
    let nullList = List.init n (fun i -> (0, 0)) // Initiate a list of length n with (x,y)-coordinates.
    List.map ( fun(x,y) -> (float (rnd.Next(int minX,int maxX)), float (rnd.Next(int minY, int maxY)))) nullList // Use System.Random() to generate random x- and y coordinate pairs inside box.

// Example
let a = makeRandomPositions (200,100) (100,100) 10
printfn "%A" a






