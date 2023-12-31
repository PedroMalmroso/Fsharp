#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color

type ff = float * float

// Import the given function which draws a tree generated by piecewiseAffine functions originating in p0.
let rec generateTree (p0: ff) (angles: ff) (length: ff) (width: ff) (n: int) : PrimitiveTree = 
    if n < 1 then
        emptyTree
    else
        let x,y = p0 // origin of tree.
        let a, da = angles
        let len, lenMul = length // length of line resp. length of line in recursive function. 
        let wth, wthMul = width // ditto for width.
        let p1 = (x+len * sin a, y-len * cos a) // (x,y)-coordinates for endpoint of line.
        let trunk = piecewiseAffine green wth [p0; p1]
        let leftBranches = generateTree p1 (a+a,da) (len*lenMul, lenMul) (wth*wthMul, wthMul) (n-1)
        let leftTree = onto trunk leftBranches
        let rightTree = rotate x y da leftTree
        onto leftTree rightTree

// Import the function made in 3i0.fsx. See 3i0.fsx for XML-documentation.
let makeRandomPositions (p: int*int) (dp: int*int) (n: int) : ff list =
    let rnd = System.Random()
    let pX, pY = p
    let dpX, dpY = dp
    let minX = float pX  - float dpX / 2.0
    let maxX = float pX  + float dpX / 2.0
    let minY = float pY  - float dpY / 2.0
    let maxY = float pY  + float dpY / 2.0
    let nullList = List.init n (fun i -> (0, 0))
    List.map ( fun(x,y) -> (float (rnd.Next(int minX,int maxX)), float (rnd.Next(int minY, int maxY)))) nullList

/// <summary> The function ofPositions generates one tree from generateTree in which it replicates
/// with different origins as generated by makeRandomPositions using List.Fold. List.Fold 
/// defines a random function fig which takes the lst generated by makeRandomPositions and uses
/// the onto function to recursively put the treeGenerator on fig. Fig starts as an emptyTree. </summary>
/// <param name = "lst"> a (float * float) list with n random origins for the tree. </param>
/// <param name = "angles"> a (float * float) vector of radians, which specifies the angle of the piecewiseAffine functions to generate the tree </param>
/// <param name = "length"> a (float * float ) vector, where the first coordinate specifies the length of the first line, and the second coordinate specifies the depreciation factor of each iterative line towards n. </param>
/// <param name = "width"> Ditto of length but for the width of the piecewiseAffine line. </param>
/// <param name = "n"> The number of branches in generateTree as an integer. </param>
/// <returns> the function returns a PrimitiveTree with n different trees generated by generateTree
///  with n different origins as generated by makeRandomPositions. </returns>
let ofPositions (lst: ff list)  (angles: ff) (length: ff) (width: ff) (n: int) : PrimitiveTree =
    let treeGenerator = generateTree (0.0,0.0) angles length width n
    List.fold (fun fig (x,y) -> onto fig (translate x y (treeGenerator))) emptyTree lst







let (w,h) = (800,800) // Defines the dimensions of the canvas to be used.

let listOfPositions = makeRandomPositions (w / 2, h / 2) (w / 2, h / 2) 20 // midpoint resp. size of box resp. number of points.

// Make picture to render
let draw = 
    ofPositions listOfPositions (-0.2,3.14/6.0) (40.0,0.8) (3.0,0.7) 5
    |> make

// Rendition of forest
render "Forest" w h draw







