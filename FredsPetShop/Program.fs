// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open PetShop
open PetShopMenu

[<EntryPoint>]
let main argv = 
    printfn "%s" buildBeastieDisplayMenu
    let response = System.Console.ReadKey()
    printfn "%c" response.KeyChar
    let stringResponse = sprintf "%c" response.KeyChar
    let chosenBeastie = buildItemsForSale.[System.Int32.Parse stringResponse]
    printfn "Chosen: %s" (beastieDisplayString chosenBeastie)
    let quit = System.Console.ReadKey()
    0 // return an integer exit code    