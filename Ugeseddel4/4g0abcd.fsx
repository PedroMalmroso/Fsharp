type pos = int * int // tuple of ints

//----------------------------------------------a--------------------------------------------

/// <summary> This function returns the squared distance between two positions each equipped with a coordinate pair. </summary>
/// <example> 
/// The following code: 
///     <code>
///         printfn "%A" (dist (1,1) (3,3))
///     </code>
/// </example>
/// <param name = "p1"> Starting point with (x,y)-coordinates as integers.</param>
/// <param name = "p2"> Ending point with (x,y)-coordinates as integers.</param>
/// <returns> integer of the squared distance beteen p1 and p2 </returns>
let dist (p1: pos) (p2: pos) : int = 
    let x1, y1 = p1
    let x2, y2 = p2
    (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)

//----------------------------------------------b---------------------------------------
/// <summary> This function takes the current position and finds the shortest path (given the robot only takes 90 degree turns) towards the target position. </summary>
/// <example> 
/// The following code: 
///     <code>
///         printfn "%A" (candidates (1,1) (3,3))
///     </code>
/// </example>
/// <param name = "src"> Starting point with (x,y)-coordinates as integers.</param>
/// <param name = "tg"> Target point with (x,y)-coordinates as integers.</param>
/// <returns> (int * int) list of paths that leads closer to the target position. </returns>
let candidates (src: pos) (tg: pos) : pos list =
    let x, y = src
    let possibleSteps = [(x + 1, y); (x - 1, y); (x, y + 1); (x, y - 1)]
    List.filter (fun (x, y) -> dist (x, y) tg < dist src tg) possibleSteps

//---------------------------------------------c-------------------------------------------
/// <summary> This function calculates the list of all the shortest routes from a source position to a target position.
/// It does so by recursively computing the shortest next step, and then concatenating each shortest route with the source position. </summary>
/// The following code: 
///     <code>
///         printfn "%A" (routes (3,3) (1,1))
///     </code>
/// </example>
/// <param name = "src"> Starting point with (x,y)-coordinates as integers.</param>
/// <param name = "tg"> Target point with (x,y)-coordinates as integers.</param>
/// <returns> list of (int * int) lists with the shortest complete route from src to tg given 90 degree movements. </returns>

let rec routes (src: pos) (tg: pos) : pos list list =
    if src = tg then
        [[tg]]  // Return the target if the search position is the same.
    else
        let nextStep = candidates src tg // if src > tg compute the next step.
        let nextRoutes = List.map (fun nextSrc -> routes nextSrc tg) nextStep // recursion step. Does this until src = tg.
        List.map (fun route -> src :: route)  (List.concat nextRoutes)

//---------------------------------------------d---------------------------------------------
/// <summary> This function takes the current position and finds the shortest path towards the target position. </summary>
/// <param name = "src"> Starting point with (x,y)-coordinates as integers.</param>
/// <param name = "tar"> Target point with (x,y)-coordinates as integers.</param>
/// <returns> (int * int) list of diagonal and Manhattan paths that leads closer to the target position. </returns>

let candidatesAlt (src: pos) (tg: pos) : pos list =
    let x, y = src
    let possibleSteps     = [(x + 1, y); (x - 1, y); (x, y + 1); (x, y - 1)]
    let possibleDiagSteps = [(x + 1, y + 1); (x + 1, y - 1); (x - 1, y + 1); (x - 1, y - 1)]
    List.filter (fun (x, y) -> dist (x, y) tg < dist src tg) (List.concat [possibleSteps; possibleDiagSteps])

/// <summary> This function calculates the list of all the shortest routes from a source position to a target position.
/// It does so by recursively computing the shortest next step, and then concatenating each shortest route with the source position. </summary>
/// The following code: 
///     <code>
///         printfn "%A" (routesAlt (5,4) (1,1))
///     </code>
/// </example>
/// <param name = "src"> Starting point with (x,y)-coordinates as integers.</param>
/// <param name = "tg"> Target point with (x,y)-coordinates as integers.</param>
/// <returns> list of (int * int) lists with the shortest complete route from src to tg given 90 degree movements. </returns>
let rec routesAlt (src: pos) (tg: pos) : pos list list =
    if src = tg then
        [[tg]]  // Return the target if the search position is the same.
    else
        let nextStep = candidatesAlt src tg
        let nextRoutes = List.map (fun nextSrc -> routesAlt nextSrc tg) nextStep // recursion step.
        let allRoutes = List.map (fun route -> src :: route)  (List.concat nextRoutes)
        let listLength = List.map (fun x -> List.length x) allRoutes // compute the length of each route.
        let listMin = List.min listLength // Takes the minimum value as an integer of the lists.
        List.filter (fun x -> List.length x = listMin) allRoutes // remove every list with length larger than listMin.

printfn "%A" (routesAlt (1,1) (9,8))







