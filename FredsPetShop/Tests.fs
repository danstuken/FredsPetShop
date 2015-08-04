namespace FredsPetShop.Tests

open NUnit.Framework
open FsUnit


[<TestFixture>]
module PetShopTests =

    let addToTakings takingsSoFar transactionCost =
        (takingsSoFar + transactionCost)

    [<Test>]
    let testAddToDailyTakings =
        let result = addToTakings 3 2
        Assert.AreEqual(5, result)
