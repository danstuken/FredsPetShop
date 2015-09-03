module PetShopMenu

open PetShop

let buildItemsForSale =
    [|
        yield TwoLeggedBeastie { Species = "Kangaroo"; NetPrice = 67.80 }
        yield FourLeggedBeastie { Species = "Rabbit"; NetPrice = 21.19 }
        yield FourLeggedBeastie { Species = "Squirrel"; NetPrice = 8.474 }
        yield FourLeggedBeastie { Species = "Rat"; NetPrice = 12.71 }
        yield EightLeggedBeastie { Species = "Tarantula"; NetPrice = 63.56 }
    |]

let beastieName (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> b.Species
    | FourLeggedBeastie b -> b.Species
    | EightLeggedBeastie b -> b.Species

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


 