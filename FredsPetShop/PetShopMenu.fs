namespace FredsPetShop

open PetShop

module PetShopMenu =

    let dailyBeasties = new System.Collections.Generic.List<AnimalForSale>()

    let buildItemsForSale =
        PetShopConfiguration.ListConfiguredAnimals()

    let beastieDisplayString (beastie: AnimalForSale) =
        sprintf "%s @ £%0.2f" beastie.Species (beastieSalePrice beastie)

    let buildBeastieDisplayMenu =
        buildItemsForSale
        |> Array.map (fun b -> beastieDisplayString b)
        |> Array.mapi (fun i s -> sprintf "%d. %s" i s)
        |> Array.reduce (fun a b -> sprintf "%s\r\n%s" a b)

    let beastieMenuDisplay displayFunc =
        displayFunc buildBeastieDisplayMenu

    let handleMenuResponse responseReader responseMap =
        responseReader
        |> responseMap 

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

    let openPetShop() =
        let inputSequence = Seq.initInfinite (fun x -> menuAction())
        Seq.pick inputSequenceProcessor inputSequence |> ignore
 