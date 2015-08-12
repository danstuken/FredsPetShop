module PetShopTests

open Xunit

type LeggedBeastie = 
    {
        SalePrice: float
    }

type Beastie =
    | TwoLeggedBeastie of LeggedBeastie
    | FourLeggedBeastie of LeggedBeastie

let vatAt18Percent salePrice =
    salePrice * 0.18

let beastieVat (beastie:Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> vatAt18Percent b.SalePrice
    | FourLeggedBeastie b -> vatAt18Percent b.SalePrice

let beastieLegTax (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> b.SalePrice * 0.2
    | FourLeggedBeastie b -> b.SalePrice * 0.4

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
    Assert.Equal(2.5, (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_40Percent_Of_FourLeggedBeastieSalePrice() =
    let b = FourLeggedBeastie { SalePrice = 25.0 }
    Assert.Equal(5.0, (beastieLegTax b))

