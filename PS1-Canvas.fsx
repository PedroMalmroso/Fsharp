#r "nuget:DIKU.Canvas, 2.0"
open Canvas
open Color
let w1,h1 = 400,600
let w2,h2 = 200,300
let tree = rectangle red 2 w1 h1
let square = translate ((float w2)/2.0) ((float h2)/2.0) (filledRectangle green w2 h2) 
let fig = onto tree square
let draw = make fig 
render "My first canvas" w1 h1 draw

