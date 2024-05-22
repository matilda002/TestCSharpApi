Feature: As a user, I want all products to be presented regardless of whether they are shown in a filtered category with the correct price.
  
  Scenario Outline: When I choose the category "<category>" the product "<productName>", should be shown with the correct price "<price>"
    Given that I am on the product page
    When I choose the category "<category>"
    Then I should see the price "<price>" for the product "<productName>"

    Examples:
      | category      | productName                    | price  |
      | Alla          | Amazon milk frog               | 599    |
      | Alla          | Common spadefoot toad          | 399    |
      | Alla          | Axolotl                        | 1500   |
      | Alla          | Poison dart frog               | 349    |
      | Alla          | Australian green tree frog     | 449    |
      | Alla          | Chinese giant salamander       | 1999   |
      | Alla          | Common surinam toad            | 539    |
      | Alla          | Smooth-sided toad              | 269    |
      | Alla          | Olm                            | 699    |
      | Alla          | Fire bellied toad              | 469    |
      | Alla          | Suwannee cooter                | 300    |
      | Alla          | Indian flapshell turtle        | 400    |
      | Alla          | South American snapping turtle | 850    |
      | Alla          | Zarudny's worm lizard          | 399    |
      | Alla          | Red worm lizard                | 169    |
      | Alla          | Bipes                          | 60     |
      | Frogs         | Amazon milk frog               | 599    |
      | Frogs         | Common spadefoot toad          | 399    |
      | Salamanders   | Axolotl                        | 1500   |
      | Frogs         | Poison dart frog               | 349    |
      | Frogs         | Australian green tree frog     | 449    |
      | Salamanders   | Chinese giant salamander       | 1999   |
      | Toads         | Common surinam toad            | 539    |
      | Toads         | Smooth-sided toad              | 269    |
      | Salamanders   | Olm                            | 699    |
      | Toads         | Fire bellied toad              | 469    |
      | Turtles       | Suwannee cooter                | 300    |
      | Turtles       | Indian flapshell turtle        | 400    |
      | Turtles       | South American snapping turtle | 850    |
      | Worm lizards  | Zarudny's worm lizard          | 399    |
      | Worm lizards  | Red worm lizard                | 169    |
      | Worm lizards  | Bipes                          | 60     |