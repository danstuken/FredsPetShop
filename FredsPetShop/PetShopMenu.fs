module PetShopMenu

open PetShop

let dailyBeasties = new System.Collections.Generic.List<Beastie>()

let buildItemsForSale =
    [|
        yield TwoLeggedBeastie { Species = "Kangaroo"; NetPrice = 67.80 }
        yield FourLeggedBeastie { Species = "Rabbit"; NetPrice = 21.19 }
        yield FourLeggedBeastie { Species = "Squirrel"; NetPrice = 8.474 }
        yield FourLeggedBeastie { Species = "Rat"; NetPrice = 12.71 }
        yield EightLeggedBeastie { Species = "Tarantula"; NetPrice = 63.56 }
    |]

let beastieDisplayString (beastie: Beastie) =
    sprintf "%s @ £%0.2f" (beastieName beastie) (beastieSalePrice beastie)

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

let runMenu =
    let inputSequence = Seq.initInfinite (fun x -> menuAction())
    Seq.pick inputSequenceProcessor inputSequence |> ignore
 