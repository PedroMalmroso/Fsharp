#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
type state = int    // definerer state værdi som en integer, her fordi 
                    // staten er x-koordinaten i en boks.

let delayTime = None

let w,h = 600,600

// laver draw-funktion der tager state x fra react-funktion som input. 
// Line1 - Line4 definerer linjerne fra de fire hjørner i boksnen til de
// tilsv. hjørner af rektanglen via piecewiseAffine-funktionen fra Canvas. 
let draw (x: state): Picture = 
    let background = filledRectangle white w h 
    let Line1 = piecewiseAffine grey 1 [(0.0,0.0);(float x,float h/4.0)]
    let Line2 = piecewiseAffine grey 1 [(0.0,h);(float x,float h/(4.0/3.0))]
    let Line3 = piecewiseAffine grey 1 [(w,0.0);(float x + float w/2.0,float h/4.0)]
    let Line4 = piecewiseAffine grey 1 [(w,h);(float x + float w/2.0,float h/(4.0/3.0))]
    let tree = onto (translate (float x) (float h/4.0) (filledRectangle black (float w/2.0) (float h/2.0))) background
    let finalBox = onto Line4 (onto Line3 (onto Line2 (onto Line1 tree)))
    make finalBox

// Laver react funktion som matcher en event (her: tryk på piletaster) med en state x. Her sørger jeg for, at funktionen opdaterer min
//state med 10 enheder, sådan så boksen rykker +/- 10 enheder på x-aksen i min interaktion.
// 
let react (x: state) (ev: Event) : state option = 
    match ev with
        | LeftArrow -> Some (x-10)
        | RightArrow -> Some (x+10)
        | _ -> None

//Interagerer 
let initialState : state = w/4
interact "Box" w h delayTime draw react initialState













