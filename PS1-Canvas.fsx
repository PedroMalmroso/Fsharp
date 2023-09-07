#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
open System

//1ø8

(* let w1,h1 = 400,600
let w2,h2 = 200,300
let tree = rectangle red 2 w1 h1
let square = translate ((float w2)/2.0) ((float h2)/2.0) (filledRectangle green w2 h2) 
let fig = onto tree square
let draw = make fig 
render "My first canvas" w1 h1 draw *)


// 1ø9
(* let r =  100.0
let x0 = 200.0
let y0 = 200.0 *)



let xCoordinate x  = 200.0 + 100.0* cos x
let yCoordinate y = 200.0 +  100.0 * sin y 
let lst1 = [for i in 0.0..0.1..3.0*Math.PI -> (xCoordinate i, yCoordinate i)]

printfn "%A" lst1

let circ = piecewiseAffine blue 2.0 lst1
let draw = make circ 
render "AA" 400 400 draw

(* 
let lst1 = [(10.0,10.0); (60.0, 80.0); (10.0, 80.0); (10.0, 10.0)]
let lst2 = [(0.0,0.0); (40.0, 30.0); (0.0, 30.0); (0.0, 0.0)]
let tri1 = piecewiseAffine green 1.0 lst1
let tri2 = filledPolygon purple lst2
let ell = ellipse blue 4.0 20.0 25.0
let tree = translate 50.0 50.0 (alignV (alignH tri1 Center tri2) Center ell)
let fig = make tree
render "my first canvas" 200 200 fig *)



