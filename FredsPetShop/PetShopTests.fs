module PetShopTests

open Xunit
open PetShop

let isInRange expectedFloat actualFloat =
    let maxAcceptableValue = expectedFloat + 0.0001
    let minAcceptableValue = expectedFloat - 0.0001
    actualFloat <= maxAcceptableValue && actualFloat >= minAcceptableValue

[<Fact>]
let vatAt18Percent_ShouldBe_18Percent_Of_SalePrice() =
    Assert.True(isInRange 4.5 (vatAt18Percent 25.0))

[<Fact>]
let beastieVat_ShouldBe_18Percent_Of_BeastieSalePrice() =
    let b = TwoLeggedBeastie { NetPrice = 25.0 }
    Assert.True(isInRange 4.5 (beastieVat b))

[<Fact>]
let beastieLegTax_ShouldBe_20Percent_Of_TwoLeggedBeastieSalePrice() =
    let b = TwoLeggedBeastie { NetPrice = 25.0 }
    Assert.True(isInRange 5.0 (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_40Percent_Of_FourLeggedBeastieSalePrice() =
    let b = FourLeggedBeastie { NetPrice = 25.0 }
    Assert.True(isInRange 10.0 (beastieLegTax b))

[<Fact>]
let beastieLegTax_ShouldBe_80Percent_Of_EightLeggedBeastieSalePrice() =
    let b = EightLeggedBeastie { NetPrice = 25.0 }
    Assert.True(isInRange 20.0 (beastieLegTax b))

[<Fact>]
let beastieCollectionLegTax_ShouldBe_SumOfAllLegTaxInCollection() =
    let collectionOfB = 
        [|
            EightLeggedBeastie { NetPrice = 20.0 }
            TwoLeggedBeastie { NetPrice = 20.0 }
            FourLeggedBeastie { NetPrice = 20.0 }
        |]
    Assert.True(isInRange 28.0 (sumOfBeastieLegTax collectionOfB))

[<Fact>]
let beastieCollectionVat_ShouldBe_SumOfAllVatInCollection() =
    let collectionOfB = 
        [|
            EightLeggedBeastie { NetPrice = 20.0 }
            TwoLeggedBeastie { NetPrice = 20.0 }
            FourLeggedBeastie { NetPrice = 20.0 }
        |]
    Assert.True(isInRange 10.8 (sumOfBeastieVat collectionOfB))

[<Fact>]
let beastieCollectionSalesPrice_ShouldBe_SumIfAllSalesPrices() =
    let collectionOfB = 
        [|
            EightLeggedBeastie { NetPrice = 20.0 }
            TwoLeggedBeastie { NetPrice = 20.0 }
            FourLeggedBeastie { NetPrice = 20.0 }
        |]
    Assert.True(isInRange 70.8 (sumOfBeastieSalesPrice collectionOfB))