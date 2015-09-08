

(*** Variables ***)

let name = "Dawson Kroeker"
let age = 32

// *** Collections ***

let kidsAgesInJune = [2; 5; 6] // list
let kidsAgesAsOfJuly = 0 :: kidsAgesInJune // create a new list that starts with a zero
let years = seq { 1983 .. 2064 }

kidsAgesInJune.[2]
kidsAgesAsOfJuly.[0]
years |> Seq.skip(32) |> Seq.take(3)


(*** Functions ***)

// define a function with two parameters
let fullname first last = sprintf "%s %s" first last

// call the function
fullname "Dawson" "Kroeker"

// multiline functions are indented
let evens values =
    let isEven x = x % 2 = 0 // nested function
    Seq.filter isEven values

// call the function
evens years

// "pipe" the output of one operation into another
let sumOfEvens values = 
    values |> evens |> Seq.sum

// without piping
let sumOfEvensWithoutPiping values = 
    Seq.sum (evens values)


sumOfEvens years
sumOfEvensWithoutPiping years

(*** Complex Types ***)

// tuples
let coord = 123,456
let threeTuple = "a",1,false

// record types with named fields
type Person = {Name : string; Age : int}

// type inference
let emma = {Name = "Emma"; Age = 7}

// union types
type FamilyMember =
    | Child of Person
    | Parent of Person

let dawson = Parent {Name = "Dawson"; Age = 32}
let jenni = Parent {Name = "Jenni"; Age = 32}
let emma = Child {Name = "Emma"; Age = 7}
let isaac = Child {Name = "Isaac"; Age = 5}
let jer = Child {Name = "Jeremiah"; Age = 3}
let silas = Child {Name = "Silas"; Age = 0}

let getRelationship person1 person2 =
    match (person1, person2) with
    | (Parent p1, Parent p2) -> "spouse"
    | (Parent p, Child c) -> "child"
    | (Child c, Parent p) -> "parent"
    | (Child c1, Child c2) -> "sibling"    

getRelationship dawson emma
getRelationship dawson jenni
getRelationship isaac emma
emma |> getRelationship isaac

(*** Concurrency ***)

let doSomething i = 
    printfn "Doing something #%i..." i
    System.Threading.Thread.Sleep(1000)
    printfn "Done #%i" i

doSomething 1

let task = async { doSomething 1 }
task |> Async.RunSynchronously

let tasks = 
    [ for i in 1 .. 40 -> async { doSomething i } ]
    |> Async.Parallel
    |> Async.RunSynchronously
