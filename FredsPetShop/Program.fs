// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open FredsPetShop.PetShop
open FredsPetShop.PetShopMenu

[<EntryPoint>]
let main argv = 
    openPetShop()

    let dailyBeastieArray = beastieArrayFromList dailyBeasties

    let dailyTotalSales = sumOfBeastieSalesPrice dailyBeastieArray
    let dailyTotalVat = sumOfBeastieVat dailyBeastieArray
    let dailyTotalLegTax = sumOfBeastieLegTax dailyBeastieArray

    printfn "Total Sales: £%0.2f Total VAT: £%0.2f Total Leg Tax £%0.2f" dailyTotalSales dailyTotalVat dailyTotalLegTax
    printfn "Good night"
    System.Console.ReadKey() |> ignore

    0