namespace FredsPetShop

module PetShop =

    type AnimalForSale(species, numberOfLegs, netRetailPrice, grossWholesalePrice) =
        member a.Species: string = species
        member a.NumberOfLegs: int = numberOfLegs
        member a.NetRetailPrice = netRetailPrice
        member a.GrossWholesalePrice = grossWholesalePrice

    let vatRate =
        0.18

    let vatAt18Percent salePrice =
        salePrice * vatRate

    let netPriceFromGross grossPrice = 
        grossPrice / ((float 1) + vatRate)

    let baseLegTax =
        0.1

    let beastieVat (beastie:AnimalForSale) =
        vatAt18Percent beastie.NetRetailPrice

    let beastieSalePrice (beastie: AnimalForSale) =
        beastie.NetRetailPrice + beastieVat beastie

    let beastieSaleProfit (beastie: AnimalForSale) =
        beastie.NetRetailPrice - (netPriceFromGross beastie.GrossWholesalePrice)

    let beastieLegTax (beastie: AnimalForSale) =
        (beastieSaleProfit beastie) * baseLegTax * float beastie.NumberOfLegs

    let beastieAggregator (beasties: AnimalForSale[]) mapFunc =
        beasties
        |> Array.map(mapFunc)
        |> Array.sum

    let sumOfBeastieLegTax (beasties: AnimalForSale[]) =
        beastieAggregator beasties (fun b -> beastieLegTax b)

    let sumOfBeastieVat (beasties: AnimalForSale[]) =
        beastieAggregator beasties (fun b -> beastieVat b)

    let sumOfBeastieSalesPrice (beasties: AnimalForSale[]) =
        beasties
        |> Array.sumBy (fun b -> beastieSalePrice b)

    let beastieArrayFromList (beasties: System.Collections.Generic.List<AnimalForSale>) =
        [|
            for beastie in beasties do
                yield beastie
        |]
    
    type PetShopConfiguration =
        static member ListConfiguredAnimals() =
            [|
                yield new AnimalForSale("Kangaroo", 2, 67.80, 48.0)
                yield new AnimalForSale("Rabbit", 4, 21.19, 15.0)
                yield new AnimalForSale("Squirrel", 4, 8.474, 6.0)
                yield new AnimalForSale("Rat", 4, 12.71, 9.0)
                yield new AnimalForSale("Tarantula", 8, 63.56, 45.0)
            |]
