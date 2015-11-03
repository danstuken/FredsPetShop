namespace FredsPetShop

open PetShop

module PetShopMenu =

    let dailyBeasties = new System.Collections.Generic.List<AnimalForSale>()

    let buildItemsForSale =
        PetShopConfiguration.ListConfiguredAnimals()

    let beastieDisplayString (beastie: AnimalForSale) =
        sprintf "%s @ £%0.2f" beastie.Species (beastieSalePrice beastie)

    let buildBeastieDisplayMenu() =
        buildItemsForSale
        |> Array.map (fun b -> beastieDisplayString b)
        |> Array.mapi (fun i s -> sprintf "%d. %s" i s)
        |> Array.reduce (fun a b -> sprintf "%s\r\n%s" a b)

    let dailySummary() =
        let dailyBeastieArray = beastieArrayFromList dailyBeasties
        let dailyTotalSales = sumOfBeastieSalesPrice dailyBeastieArray
        let dailyTotalVat = sumOfBeastieVat dailyBeastieArray
        let dailyTotalLegTax = sumOfBeastieLegTax dailyBeastieArray

        sprintf "Current Sales: £%0.2f Total VAT: £%0.2f Total Leg Tax £%0.2f" dailyTotalSales dailyTotalVat dailyTotalLegTax

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
       
    let displayMainScreen menuFunction summaryFunction =
        System.Console.Clear()
        printfn "%s" (menuFunction())
        printfn ""
        printfn "%s" (summaryFunction())
        printfn ""
        printfn "Press X to quit"

    let menuAction idx =
        displayMainScreen buildBeastieDisplayMenu dailySummary
        string (System.Console.ReadKey().KeyChar)

    let openPetShop() =
        let inputSequence = Seq.initInfinite menuAction
        Seq.pick inputSequenceProcessor inputSequence |> ignore
 