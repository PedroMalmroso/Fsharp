type weekday =
    Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday

let nextDay (w: weekday) = 
    match w with
        | Monday -> Tuesday
        | Tuesday -> Wednesday
        | Wednesday -> Thursday
        | Thursday -> Friday
        | Friday -> Saturday
        | Saturday -> Sunday
        | Sunday -> Monday


printfn "%A" (nextDay Sunday)
