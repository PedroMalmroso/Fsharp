#r "nuget:DIKU.Canvas, 2.0"
#load "2g0.fsx"

open Canvas
open Color
open Arith 

type vec = float * float 
let w,h = 800.0,800.0

rot 


//----------------------------------------a---------------------------------------------
let toTree (c: color) (v: vec) =
    piecewiseAffine c 1 [(0.0,0.0);v]

 (* 
let vector  = translate (w/2.0) (h/2.0) (toTree blue (w/2.0,0.0))
let pict = make vector
render "box" (int w) (int h) pict
  *)

//---------------------------------------b--------------------------------------------
let rot (v1: vec) (a: float) = 
    let (x1, y1) = v1
    (x1 * cos a - y1 * sin a, x1 * sin a + y1 * cos a)



let a : float = 10.0 // angleIncrement in degrees
let angleIncrement : float = a * System.Math.PI / 180.0 // degrees to radians conversion.

let rec buildRadialPattern (n : int) (vi : float * float) (accumulate : PrimitiveTree) =
    match n with
    | 0 -> accumulate
    | _ ->
        let newAccumulate = onto (toTree blue vi) accumulate
        buildRadialPattern (n - 1) (rot vi angleIncrement) newAccumulate

(* let radialPattern = translate (w/2.0) (h/2.0) (buildRadialPattern (int (360.0/a)) (w / 2.0, 0.0) emptyTree)
let pict = make radialPattern
render "box" (int w) (int h) pict *)


//-----------------------------------------c---------------------------------------------
type state = float

let react (x: state) (ev: Event) : state option = 
    match ev with
        | LeftArrow -> Some (x-5.0)
        | RightArrow -> Some (x+5.0)
        | _ -> None

let draw (x: state): Picture = 
    //let rad = x * System.Math.PI / 180.0
    let radialPattern = translate (w/2.0) (h/2.0) (buildRadialPattern (int (360.0/a)) ((w / 2.0+x), 0.0+x) emptyTree)
    let fig = radialPattern
    make fig

let initialState = 0.0

interact "box" (int w) (int h) None draw react initialState




(* let draw (x: state): Picture = 
    let background = filledRectangle white w h 
    let Line1 = piecewiseAffine grey 1 [(0.0,0.0);(float x,float h/4.0)]
    let Line2 = piecewiseAffine grey 1 [(0.0,h);(float x,float h/(4.0/3.0))]
    let Line3 = piecewiseAffine grey 1 [(w,0.0);(float x + float w/2.0,float h/4.0)]
    let Line4 = piecewiseAffine grey 1 [(w,h);(float x + float w/2.0,float h/(4.0/3.0))]
    let tree = onto (translate (float x) (float h/4.0) (filledRectangle black (float w/2.0) (float h/2.0))) background
    let finalBox = onto Line4 (onto Line3 (onto Line2 (onto Line1 tree)))
    make finalBox *)














// 1 degree = pi/180 radians = a.


//b) legacy
(*let vii = (w/2.0,0.0)
let vector1  = translate (w/2.0) (h/2.0) (toTree blue vii)
let vector2 = translate (w/2.0) (h/2.0) (toTree blue (rot vii a))
let vector3 = translate (w/2.0) (h/2.0) (toTree blue (rot (rot vii a) a))
let vector4 = translate (w/2.0) (h/2.0) (toTree blue (rot (rot (rot vii a) a) a))
let radial = onto vector4 (onto vector3 (onto vector1 vector2))
let pict = make radial
render "box" (int w) (int h) pict *)