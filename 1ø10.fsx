#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
open System

type state = int
let delayTime = None

let w,h = 400,400
let w1, h1 = 20,20
let tree = translate ((float w) / 2.0) ((float h) / 2.0) (filledRectangle red w1 h1)
let draw (s: state) = make tree

let react (s: state) (ev: Event) : state option =  
    match ev with
        | LeftArrow ->
            printfn "Left arrow"
            None
        | RightArrow ->
            printfn "Right arrow"
            None
        | DownArrow ->
            printfn "Up arrow"
            None
        | UpArrow->
            printfn "Down arrow"
            None
        | _ -> None

let initialState : state = 20 / 2

interact "Box" w h delayTime draw react initialState

//interact "Moving box" w h delayTime draw react initialState


(* let w1,h1 = 400,600
let w2,h2 = 200,300
let tree = rectangle red 2 w1 h1
let square = translate ((float w2)/2.0) ((float h2)/2.0) (filledRectangle green w2 h2) 
let fig = onto tree square
let draw = make fig 
render "My first canvas" w1 h1 draw *)




(* 
type state = int * int  // x-pos and direction

// The size of the window and the edge-size of the box
let w,h,boxW = 1024,512,200

/// Update state function
let next (x, dir) =
    let dir = 
        if x + dir < 0 || x + dir > w - boxW then 
            -dir
        else
            dir
    (x + dir, dir)

/// Prepare a Picture by the present state whenever needed
let draw ((x, _):state): Picture =
    let boundingColor = red
    let color = fromRgb 0 0 (x * 255 / (w - boxW))
    onto (rectangle boundingColor 2.0 (float boxW) (float boxW))
        (filledRectangle color (float boxW) (float boxW))
    |> translate (float x) (float (h-boxW)/2.0)
    |> make

/// React to whenever an event happens
let react (s:state) (ev:Event) : state option =
    match ev with
        | Event.TimerTick ->
            s |> next |> Some
        | _ -> None

// Start interaction session
let initialState = (0, 5) // First state drawn by draw
let delayTime = (Some 16) // microseconds (as an option type)
interact "Moving box" w h delayTime draw react initialState *)

