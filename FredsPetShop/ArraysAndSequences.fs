#if INTERACTIVE
#else
module ArraysAndSequences
#endif

let arr = [|1;2;3;|]
let fruits =
    [|
        "apples"
        "pears"
    |]
let range = [|0..100|]
let steppedRange = [|0..5..100|]



let randomFruits count =
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    [|
        for i in 1..count do
            let index = r.Next(3)
            yield fruits.[index]
    |]

let randomFruits2 count =
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    Array.init count ( fun _ ->
        let index = r.Next(3)
        fruits.[index]
    )

let likeSomeFruit fruits =
    for fruit in fruits do
        printfn "I like %s" fruit

let squares = [| for i in 0..99 do yield i * i|]

let isEven n = 
    n % 2 = 0

let evenSquares = Array.filter (fun x -> isEven x) squares

let sortedFruit = Array.sort (randomFruits 10)

let verbosePrintLongWords (words : string[]) =
    let longWords : string [] = Array.filter (fun w -> w.Length > 8) words
    let sortedWords = Array.sort longWords
    Array.iter (fun w -> printfn "%s" w) sortedWords

let printLongWords (words : string[]) =
    words
    |> Array.filter (fun w -> w.Length > 8)
    |> Array.sort
    |> Array.iter (fun w -> printfn "%s" w)

let simplePrintSquares min max =
    let square n = 
        n * n
    for i in min..max do
        printfn "%i" (square i)

let printSquares min max =
    let square n = 
        n * n
    [|min..max|]
    |> Array.map (fun i -> square i)
    |> Array.iter (fun s -> printfn "%i" s)

//.net enumerables are F# sequences
let someFiles = System.IO.Directory.EnumerateFiles(@"C:\temp\*.txt")

let smallNumbers = Seq.init 100 (fun i -> i)

let moreNumbers = 
    seq {
        for i in 0..99 do
            yield i
    }

open System.IO
let someBigFiles =
    Directory.EnumerateFiles(@"C:\windows")
    |> Seq.map (fun f -> FileInfo f)
    |> Seq.filter (fun f -> f.Length > 1000000L)
    |> Seq.map (fun f -> f.Name)
