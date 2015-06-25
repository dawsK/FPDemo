
(** Currying **)

// function with one parameter
let printParameter x =
    printfn "x=%i" x

let printTwoParameters x  =      // only one parameter
    let subFunction y =          // new inner function with one param
        printfn "x=%i y=%i" x y  
    subFunction                  // return the inner function

// curried function that takes 2 parameters (sort of)
let printTwoParametersCurried x y =
    printfn "x=%i y=%i" x y

printTwoParameters 1
printTwoParametersCurried 1

(** Partial Application **)

let add x y = x + y
let addOne = add 1
let twoPlusOne = addOne 2

// break it down:
let add x y = x + y

let add2 x =
    let addInner y =
        x + y
    addInner
// val add2 : x:int -> (int -> int)

let addOne = add 1

(** Recursion **)

let sum values =
    let rec calcSum total remainingValues = 
        match remainingValues with
        | [] -> total
        | x :: xs -> calcSum (total + x) xs
    calcSum 0 values

sum [1;2;3;4;5]

List.sum [1;2;3;4;5]