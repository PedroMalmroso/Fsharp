type vec = float*float
let origin = (0.0, 0.0)

let rot (v1: vec) (a: float) = 
    let (x1, y1) = v1
    (x1 * cos a - y1 * sin a, x1 * sin a + y1 * cos a)

let rec rotatePairs (v1: float * float) (angle: float) (numRotations: int) (acc: (float * float) list) =
    match numRotations with
    | 0 -> List.rev acc
    | _ ->
        let rotatedVector = rot v1 angle
        let newAcc = (origin, rotatedVector) :: acc // Fix: Append to the list
        let newAngle = angle + angleIncrement
        rotatePairs v1 newAngle (numRotations - 1) newAcc

// Example usage
let numRotations = 8  // Replace with the desired number of rotations
let angleIncrement = 45.0 * System.Math.PI / 180.0 // Replace with the desired angle increment in radians
let initialVector = (1.0, 0.0)  // Replace with your initial vector

let coordinatePairs = rotatePairs initialVector 0.0 numRotations []

// Print the list of coordinate pairs
coordinatePairs
|> List.iter (fun (startCoord, endCoord) ->
    printfn "Start: (%f, %f), End: (%f, %f)" (fst startCoord) (snd startCoord) (fst endCoord) (snd endCoord))




