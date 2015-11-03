namespace FredsPetShop

open Xunit
open FredsPetShop.PetShop
open FredsPetShop.PetShopMenu

module PetShopTests =

    let AssertIsInRange expectedFloat actualFloat =
        let maxAcceptableValue = expectedFloat + 0.0001
        let minAcceptableValue = expectedFloat - 0.0001
        
        Assert.InRange(actualFloat, minAcceptableValue, maxAcceptableValue)

    let buildTestBeastie species legCount netRetailPrice grossWholesalePrice=
        new AnimalForSale(species, legCount, netRetailPrice, grossWholesalePrice)

    let buildTestTwoLeggedBeastie netPrice = 
        buildTestBeastie "TestBeast" 2 netPrice 1.0

    let buildTestFourLeggedBeastie netPrice =
        buildTestBeastie "TestBeast" 4 netPrice 1.0

    let buildTestEightLeggedBeastie netPrice =
        buildTestBeastie "TestBeast" 8 netPrice 1.0

    [<Fact>]
    let vatAt18Percent_ShouldBe_18Percent_Of_SalePrice() =
        AssertIsInRange 4.5 (vatAt18Percent 25.0)

    [<Fact>]
    let beastieVat_ShouldBe_18Percent_Of_BeastieSalePrice() =
        let b = buildTestTwoLeggedBeastie 25.0
        AssertIsInRange 4.5 (beastieVat b)

    [<Fact>]
    let beastieCollectionLegTax_ShouldBe_SumOfAllLegTaxInCollection() =
        let collectionOfB = 
            [|
                buildTestEightLeggedBeastie 20.0
                buildTestTwoLeggedBeastie 20.0
                buildTestFourLeggedBeastie 20.0
            |]
        AssertIsInRange 26.81 (sumOfBeastieLegTax collectionOfB)

    [<Fact>]
    let beastieCollectionVat_ShouldBe_SumOfAllVatInCollection() =
        let collectionOfB = 
            [|
                buildTestEightLeggedBeastie 20.0
                buildTestTwoLeggedBeastie 20.0
                buildTestFourLeggedBeastie 20.0
            |]
        AssertIsInRange 10.8 (sumOfBeastieVat collectionOfB)

    [<Fact>]
    let beastieCollectionSalesPrice_ShouldBe_SumOfAllSalesPrices() =
        let collectionOfB = 
            [|
                buildTestEightLeggedBeastie 20.0
                buildTestTwoLeggedBeastie 20.0
                buildTestFourLeggedBeastie 20.0
            |]
        AssertIsInRange 70.8 (sumOfBeastieSalesPrice collectionOfB)

    [<Fact>]
    let beastieCollectionProfit_ShouldBe_SumOfAllSalesProfit() =
        let collectionOfB =
            [|
                buildTestEightLeggedBeastie 20.0
                buildTestTwoLeggedBeastie 20.0
                buildTestFourLeggedBeastie 20.0
            |]
        AssertIsInRange 57.46 (sumOfBeastieSalesProfit collectionOfB)

    [<Fact>]
    let beastieDisplayString_ShouldBe_NameWithSalesPrice() =
        let beastieToDisplay = buildTestBeastie "Kangaroo" 2 67.80 0.0
        let expectedDisplayString = "Kangaroo @ £80.00"
        Assert.Equal(expectedDisplayString, (beastieDisplayString beastieToDisplay))

    [<Fact>]
    let beastieDisplayMenu_ShouldBe_NamesWithSalesPrice() =
        let beastieDisplayMenu = buildBeastieDisplayMenu
        let expectedDisplayMenu = @"0. Kangaroo @ £80.00
1. Rabbit @ £25.00
2. Squirrel @ £10.00
3. Rat @ £15.00
4. Tarantula @ £75.00"
        Assert.Equal(expectedDisplayMenu, beastieDisplayMenu())

    [<Fact>]
    let beastieSaleProfit_ShouldBe_DifferenceBetweenNetRetailAndNetWholesalePrices() =
        let beastieToSell = buildTestBeastie "Kangaroo" 2 25.0 11.8
        let profit = beastieSaleProfit beastieToSell

        AssertIsInRange 15.0 profit

    [<Fact>]
    let beastieSaleLegTaxForTwoLegs_ShouldBe_20PercentProfitOnSale() =
        let beastieToSell = buildTestBeastie "Kangaroo" 2 25.0 11.8
        let beastieLegTax = beastieLegTax beastieToSell

        AssertIsInRange 3.0 beastieLegTax

    [<Fact>]
    let beastieSaleLegTaxForFourLegs_ShouldBe_40PercentProfitOnSale() =
        let beastieToSell = buildTestBeastie "Rat" 4 25.0 11.8
        let beastieLegTax = beastieLegTax beastieToSell

        AssertIsInRange 6.0 beastieLegTax

    [<Fact>]
    let beastieSaleLegTaxForFourLegs_ShouldBe_80PercentProfitOnSale() =
        let beastieToSell = buildTestBeastie "Tarantula" 8 25.0 11.8
        let beastieLegTax = beastieLegTax beastieToSell

        AssertIsInRange 12.0 beastieLegTax