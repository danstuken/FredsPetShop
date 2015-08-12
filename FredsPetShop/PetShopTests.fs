module PetShopTests

open Xunit

type LeggedBeastie = 
    {
        SalePrice: float
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
    | TwoLeggedBeastie b -> vatAt18Percent b.SalePrice
    | FourLeggedBeastie b -> vatAt18Percent b.SalePrice
    | EightLeggedBeastie b -> vatAt18Percent b.SalePrice

let beastieLegTax (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> legTaxForTwoLegs b.SalePrice
    | FourLeggedBeastie b -> legTaxForFourLegs b.SalePrice
    | EightLeggedBeastie b -> legTaxForEightLegs b.SalePrice

let sumOfBeastieLegTax (beasties: Beastie[]) =
    beasties
    |> Array.map (fun b -> beastieLegTax b)
    |> Array.sum

let sumOfBeastieVat (beasties: Beastie[]) =
    beasties
    |> Array.map (fun b -> beastieVat b)
    |> Array.sum

let isInRange expectedFloat actualFloat =
    let maxAcceptableValue = expectedFloat + 0.0001
    let minAcceptableValue = expectedFloat - 0.0001
    actualFloat <= maxAcceptableValue && actualFloat >= minAcceptableValue

[<Fact>]
let vatAt18Percent_ShouldBe_18Percent_Of_SalePrice() =
    Assert.True(isInRange 4.5 (vatAt18Percent 25.0))

[<Fact>]
let beastieVat_ShouldBe_18Percent_Of_BeastieSalePrice() =
    let b = TwoLeggedBeastie { SalePrice = 25.0 }
    Assert.True(isInRange 4.5 (beastieVat b))

[<Fact>]
let beastieLegTax_ShouldBe_20Percent_Of_TwoLeggedBeastieSalePrice() =
    let b = TwoLeggedBeastie { SalePrice = 25.0 }
    Assert.True(isInRange 5.0 (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_40Percent_Of_FourLeggedBeastieSalePrice() =
    let b = FourLeggedBeastie { SalePrice = 25.0 }
    Assert.True(isInRange 10.0 (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_80Percent_Of_EightLeggedBeastieSalePrice() =
    let b = EightLeggedBeastie { SalePrice = 25.0 }
    Assert.True(isInRange 20.0 (beastieLegTax b))

[<Fact>]
let beastieCollectionLegTax_ShouldBe_SumOfAllLegTaxInCollection() =
    let collectionOfB = 
        [|
            EightLeggedBeastie { SalePrice = 20.0 }
            TwoLeggedBeastie { SalePrice = 20.0 }
            FourLeggedBeastie { SalePrice = 20.0 }
        |]
    Assert.True(isInRange 28.0 (sumOfBeastieLegTax collectionOfB))

[<Fact>]
let beastieCollectionVat_ShouldBe_SumOfAllVatInCollection() =
    let collectionOfB = 
        [|
            EightLeggedBeastie { SalePrice = 20.0 }
            TwoLeggedBeastie { SalePrice = 20.0 }
            FourLeggedBeastie { SalePrice = 20.0 }
        |]
    Assert.True(isInRange 10.8 (sumOfBeastieVat collectionOfB))
