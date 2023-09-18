#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
type state = int*int

let delayTime = None

let w,h = 800,400

let draw (x: state): Picture = 
    let background = filledRectangle white w h
    let Line1 = piecewiseAffine grey 1 [(0.0,0.0);(float x,float h/4.0)]
    let Line2 = piecewiseAffine grey 1 [(0.0,h);(float x,float h/(4.0/3.0))]
    let Line3 = piecewiseAffine grey 1 [(w,0.0);(float x+float w/2.0,float h/4.0)]
    let Line4 = piecewiseAffine grey 1 [(w,h);(float x+ float w/2.0,float h/(4.0/3.0))]
    let tree = onto (translate (float x) (float h/4.0) (filledRectangle black (float w/2.0) (float h/2.0))) background
    let finalBox = onto Line4 (onto Line3 (onto Line2 (onto Line1 tree)))
    make finalBox

let react (x: state) (ev: Event) : state option = 
    match ev with
        | LeftArrow -> Some (x-10)
        | RightArrow -> Some (x+10)
        | _ -> None

let initialState : state = w/2
interact "Box" w h delayTime draw react initialState
