#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color

let w = 600
type ff = float * float

let rec generateTree (p0: ff) (angles: ff) (length: ff) (width: ff) (n: int) : PrimitiveTree = 
    if n < 1 then
        emptyTree
    else
        let x,y = p0 // origo for træ
        let a, da = angles
        let len, lenMul = length // lngd på linje, lngd på linje i rekursiv funktion
        let wth, wthMul = width // ditto for bredde
        let p1 = (x+len * sin a, y-len * cos a) // (x,y)-kordinater for slutpunkt af linje 
        let trunk = piecewiseAffine green wth [p0; p1]
        let leftBranches = generateTree p1 (a+a,da) (len*lenMul, lenMul) (wth*wthMul, wthMul) (n-1)
        let leftTree = onto trunk leftBranches
        let rightTree = rotate x y da leftTree
        onto leftTree rightTree

let draw = 
    generateTree (float w/2.0, float w/2.0) (-0.2,3.14/6.0) (40.0,0.8) (3.0,0.7) 20
    |> make

render "Tree" w w draw


