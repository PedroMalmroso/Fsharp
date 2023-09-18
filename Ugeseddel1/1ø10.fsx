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
        |LeftArrow ->
            printfn "Left arrow"
            None
        |RightArrow ->
            printfn "Right arrow"
            None
        |DownArrow ->
            printfn "Up arrow"
            None
        |UpArrow->
            printfn "Down arrow"
            None
        Console.ReadKey(ConsoleKey.Spacebar)
            printfn "Spacebar"
        | _ -> None

let initialState : state = 20 / 2

interact "Box" w h delayTime draw react initialState