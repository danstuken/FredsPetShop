module PetShop

type LeggedBeastie = 
    {
        Species: string
        NetPrice: float
    }

type Beastie =
    | TwoLeggedBeastie of LeggedBeastie
    | FourLeggedBeastie of LeggedBeastie
    | EightLeggedBeastie of LeggedBeastie

let vatAt18Percent salePrice =
    salePrice * 0.18

let baseLegTax =
    0.1

let legTaxForTwoLegs salePrice =
    salePrice * baseLegTax * float 2

let legTaxForFourLegs salePrice =
    salePrice * baseLegTax * float 4

let legTaxForEightLegs salePrice =
    salePrice * baseLegTax * float 8

let beastieVat (beastie:Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> vatAt18Percent b.NetPrice
    | FourLeggedBeastie b -> vatAt18Percent b.NetPrice
    | EightLeggedBeastie b -> vatAt18Percent b.NetPrice

let beastieLegTax (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> legTaxForTwoLegs b.NetPrice
    | FourLeggedBeastie b -> legTaxForFourLegs b.NetPrice
    | EightLeggedBeastie b -> legTaxForEightLegs b.NetPrice

let beastieSalePrice (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> b.NetPrice
    | FourLeggedBeastie b -> b.NetPrice
    | EightLeggedBeastie b -> b.NetPrice

let sumOfBeastieLegTax (beasties: Beastie[]) =
    beasties
    |> Array.map (fun b -> beastieLegTax b)
    |> Array.sum

let sumOfBeastieVat (beasties: Beastie[]) =
    beasties
    |> Array.map (fun b -> beastieVat b)
    |> Array.sum

let beastieGrossPrice (beastie: Beastie) =
    beastieSalePrice beastie + beastieVat beastie

let sumOfBeastieSalesPrice (beasties: Beastie[]) =
    beasties
    |> Array.sumBy (fun b -> beastieGrossPrice b)

