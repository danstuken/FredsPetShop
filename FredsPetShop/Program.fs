// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open PetShop
open PetShopMenu

let dailyBeasties = new System.Collections.Generic.List<Beastie>()

let parseKey key =
    match key with
    |"0"|"1"|"2"|"3"|"4" -> dailyBeasties.Add(buildItemsForSale.[System.Int32.Parse key])
    | _ -> ()

let inputSequenceProcessor key = 
    match key with
    | "X" -> Some(key)
    | _ -> ignore (fun _ -> parseKey key); None

let menuAction = fun _ ->
    beastieMenuDisplay (fun s -> printfn "%s" s)
    System.Console.ReadLine()

[<EntryPoint>]
let main argv = 

    let inputSequence = Seq.initInfinite (fun x -> menuAction())

    Seq.pick inputSequenceProcessor inputSequence |> ignore
    printf "Good night"
    System.Console.ReadKey() |> ignore
    //let chosenBeastie = buildItemsForSale.[System.Int32.Parse stringResponse]
    //printfn "Chosen: %s" (beastieDisplayString chosenBeastie)
    //let quit = System.Console.ReadKey()
    0 // return an integer exit code    