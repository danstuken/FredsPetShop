namespace FredsPetShop.Tests

open Xunit

type PetShopTests() =

    let addToTakings takingsSoFar transactionCost =
        (takingsSoFar + transactionCost)

    [<Fact>]
    member this.testAddToDailyTakings() =
        let result = addToTakings 3 2
        Assert.Equal(5, result)