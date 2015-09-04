// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open PetShop
open PetShopMenu

let dailyBeasties = new System.Collections.Generic.List<Beastie>()

let parseKey key =
    match key with
    |"0"|"1"|"2"|"3"|"4" -> 
        let beastie = buildItemsForSale.[System.Int32.Parse key]
        dailyBeasties.Add(beastie)
    | _ -> ()

let inputSequenceProcessor key = 
    match key with
    | "X" -> Some(key)
    | _ -> parseKey key; None

let menuAction = fun _ ->
    beastieMenuDisplay (fun s -> 
        System.Console.Clear()
        printfn "%s" s
    )
    System.Console.ReadLine()

[<EntryPoint>]
let main argv = 

    let inputSequence = Seq.initInfinite (fun x -> menuAction())
    Seq.pick inputSequenceProcessor inputSequence |> ignore

    let dailyBeastieList = beastieArrayFromList dailyBeasties

    let dailyTotalSales = sumOfBeastieSalesPrice dailyBeastieList
    let dailyTotalVat = sumOfBeastieVat dailyBeastieList
    let dailyTotalLegTax = sumOfBeastieLegTax dailyBeastieList

    printfn "Total Sales: £%0.2f Total VAT: £%0.2f Total Leg Tax £%0.2f" dailyTotalSales dailyTotalVat dailyTotalLegTax
    printfn "Good night"
    System.Console.ReadKey() |> ignore

    0