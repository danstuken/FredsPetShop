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

[<Fact>]
let vatAt18Percent_ShouldBe_18Percent_Of_SalePrice() =
    Assert.Equal(4.5, vatAt18Percent 25.0)

[<Fact>]
let beastieVat_ShouldBe_18Percent_Of_BeastieSalePrice() =
    let b = TwoLeggedBeastie { SalePrice = 25.0 }
    Assert.Equal(4.5, (beastieVat b))

[<Fact>]
let beastieLegTax_ShouldBe_20Percent_Of_TwoLeggedBeastieSalePrice() =
    let b = TwoLeggedBeastie { SalePrice = 25.0 }
    Assert.Equal(5.0, (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_40Percent_Of_FourLeggedBeastieSalePrice() =
    let b = FourLeggedBeastie { SalePrice = 25.0 }
    Assert.Equal(10.0, (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_80Percent_Of_EightLeggedBeastieSalePrice() =
    let b = EightLeggedBeastie { SalePrice = 25.0 }
    Assert.Equal(20.0, (beastieLegTax b))