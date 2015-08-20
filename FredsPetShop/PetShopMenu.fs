module PetShopMenu

open PetShop

let beastieName (beastie: Beastie) =
    match beastie with
    | TwoLeggedBeastie b -> b.Species
    | FourLeggedBeastie b -> b.Species
    | EightLeggedBeastie b -> b.Species

let beastieDisplayString (beastie: Beastie) =
    sprintf "%s @ £%0.2f" (beastieName beastie) (beastieSalePrice beastie)

