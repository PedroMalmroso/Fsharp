#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
open System

type state = int*int
let delayTime = None

let w,h = 400,400

let draw ((x,y): state): Picture = 
    let fontName = "Microsoft Sans Serif"
    let font = makeFont fontName 24.0
    let white = yellow
    let tree = translate (float y) (float x) (text white font (string (x,y)))
    make tree

let react ((x,y): state) (ev: Event) : state option = 
    match ev with
        | UpArrow ->  Some (x-10,y)
        | DownArrow -> Some (x+10,y)
        | LeftArrow -> Some (x,y-10)
        | RightArrow -> Some (x,y+10)
        | _ -> None

let initialState : state = (370,0)

interact "Box" w h delayTime draw react initialState
