

(*** Variables ***)

let name = "Dawson Kroeker"
let age = 32

// *** Collections ***

let kidsAges = [2; 5; 6] // list
let kidsAgesInJuly = 0 :: kidsAges // create a new list that starts with a zero
let years = seq { 1983 .. 2064 }

kidsAges.[2]
kidsAgesInJuly.[0]
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
let emma = {Name = "Emma"; Age = 6}

// union types
type FamilyMember =
    | Child of Person
    | Parent of Person
    | Dog of string

let dawson = Parent {Name = "Dawson"; Age = 32}
let isaac = Child {Name = "Isaac"; Age = 5}

let getFamilyMemberWithAge age =
    if age = 32 then dawson
    else if age = 5 then isaac
    else Dog "Rover"

getFamilyMemberWithAge 6
