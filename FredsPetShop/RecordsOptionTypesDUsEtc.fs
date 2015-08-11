#if INTERACTIVE
#else
module RecordsOptionTypesDUsEtc
#endif

//Records

type Person =
    {
        FirstName: string
        LastName: string
    }

let person = { FirstName = "Dan"; LastName = "SecondName" }

printfn "%s, %s" person.LastName person.FirstName

let person2 = { person with FirstName = "NewFirstName"}

printfn "%s, %s" person2.LastName person2.FirstName

let person3 = { FirstName = "Dan"; LastName = "SecondName" }
let equality = person = person3 //structural equality


//Option Type
type Company =
    {
        Name: string
        SalesTaxNumber: int option
    }

let company = { Name = "New Corp"; SalesTaxNumber = None}
let secondCompay = { Name = "Taxable Corp"; SalesTaxNumber = Some 1253}

let printCompany (company : Company) =
    let taxNumberString = 
        match company.SalesTaxNumber with
        | Some n -> sprintf " [%i]" n
        | None -> ""

    printfn "%s%s" company.Name taxNumberString


//Discriminated Unions (not class hierarchy)

type Shape =
    | Square of float
    | Rectangle of float * float
    | Circle of float

let s = Square 2.3
let r = Rectangle (3.2, 5.1)
let c = Circle 344.0

let drawing = [|s; r; c|]

let area (shape: Shape) =
    match shape with
    | Square x -> x * x
    | Rectangle(h, w) -> h * w
    | Circle r -> System.Math.PI * r * r

let drawingArea = drawing |> Array.sumBy (fun s -> area s)

let one = [|10|]
let two = [|10; 20|]
let many = [|1..99|]

let describe arr =
    match arr with 
    | [|x|] -> sprintf "One element: %i" x
    | [|x; y|] -> sprintf "Two elements: %i, %i" x y
    | _ -> sprintf "A longer array"

[|one; two; many|] |> Array.map (fun a -> describe a) |> Array.iter (fun s -> printfn "%s" s)