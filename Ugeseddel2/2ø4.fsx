type weekday =
    Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let dayToNumber (w: weekday) =
    match w with
        | Monday -> 1
        | Tuesday -> 2
        | Wednesday -> 3
        | Thursday -> 4
        | Friday -> 5
        | Saturday -> 6
        | Sunday -> 7

printfn "%A" (dayToNumber Tuesday)
