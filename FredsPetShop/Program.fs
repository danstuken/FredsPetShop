// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open PetShop
open PetShopMenu

let buildItemsForSale =
    [|
        yield TwoLeggedBeastie { Species = "Kangaroo"; NetPrice = 67.80 }
        yield FourLeggedBeastie { Species = "Rabbit"; NetPrice = 21.19 }
        yield FourLeggedBeastie { Species = "Squirrel"; NetPrice = 8.48 }
        yield FourLeggedBeastie { Species = "Rat"; NetPrice = 12.71 }
        yield EightLeggedBeastie { Species = "Tarantula"; NetPrice = 63.56 }
    |]

let listSaleItems =
    buildItemsForSale
    |> Array.map (fun b -> beastieDisplayString b)
    |> Array.iteri (fun i s -> printfn "%d. %s" i s)

[<EntryPoint>]
let main argv = 
    listSaleItems
    let response = System.Console.ReadKey()
    printfn "%c" response.KeyChar
    let stringResponse = sprintf "%c" response.KeyChar
    let chosenBeastie = buildItemsForSale.[System.Int32.Parse stringResponse]
    printfn "Chosen: %s" (beastieDisplayString chosenBeastie)
    let quit = System.Console.ReadKey()
    0 // return an integer exit code    