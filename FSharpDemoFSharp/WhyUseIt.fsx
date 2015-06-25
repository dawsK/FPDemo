
// one-liners
[1..100] |> List.sum |> printfn "sum=%d"

// no curly braces, semicolons or parentheses
let square x = x * x
let sq = square 42

// simple types in one line
type Person = {Name : string; Age : int}

// complex types in a few lines
type Employee = 
  | Worker of Person
  | Manager of Employee list

// type inference
let jdoe = {Name="John Doe"; Age = 35}
let worker = Worker jdoe

// Concurrency

let doSomething i = 
    printfn "Doing something #%i..." i
    System.Threading.Thread.Sleep(1000)
    printfn "Done #%i" i

let task = async { doSomething 1 }
task |> Async.RunSynchronously

let tasks = 
    [ for i in 1 .. 40 -> async { doSomething i } ]
    |> Async.Parallel
    |> Async.RunSynchronously
