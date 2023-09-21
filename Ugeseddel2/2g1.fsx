#r "nuget:DIKU.Canvas, 2.0"
#load "2g0.fsx"

open Canvas
open Color
open Arith 

type vec = float * float 
let w,h = 800.0,800.0

//----------------------------------------a---------------------------------------------
let toTree (c: color) (v: vec) =
    piecewiseAffine c 1 [(0.0,0.0);v]

 (* 
let vector  = translate (w/2.0) (h/2.0) (toTree blue (w/2.0,0.0))
let pict = make vector
render "box" (int w) (int h) pict
  *)

//---------------------------------------b--------------------------------------------
let a : float = 5.0 // angleIncrement in degrees, 1 degree = pi/180 radians
let angleIncrement : float = a * System.Math.PI / 180.0 // degrees to radians conversion.

let rec buildRadialPattern (n : int) (vi : float * float) (accumulate : PrimitiveTree) =
    match n with
    | 0 -> accumulate
    | _ ->
        let newAccumulate = onto (toTree blue vi) accumulate
        buildRadialPattern (n - 1) (rot vi angleIncrement) newAccumulate

//-----------------------------------------c---------------------------------------------
type state = float

let react (s: state) (ev: Event) : state option = 
    match ev with
        | LeftArrow -> Some (s-1.0)
        | RightArrow -> Some (s+1.0)
        | _ -> None

let draw (s: state): Picture = 
    //let rad = x * System.Math.PI / 180.0
    let firstVec = rot ((w/2.0), 0.0) s
    let radialPattern = translate (w/2.0) (h/2.0) (buildRadialPattern (int (360.0/a)) firstVec emptyTree)
    let fig = radialPattern
    make fig

let initialState = 0.0

interact "box" (int w) (int h) None draw react initialState

