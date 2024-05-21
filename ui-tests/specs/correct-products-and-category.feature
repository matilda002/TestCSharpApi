Feature: As a user, I want all products to be presented regardless of whether they are shown in a filtered category.
  
  Scenario Outline: When I choose the category "<category>", the product "<productName>" should be shown
    Given that I am on the product page
    When I choose the category "<category>"
    Then The product "<productName>" should be shown

    Examples:
      | category      | productName                    |
      | Alla          | Amazon milk frog               |
      | Alla          | Common spadefoot toad          |
      | Alla          | Axolotl                        |
      | Alla          | Poison dart frog               |
      | Alla          | Australian green tree frog     |
      | Alla          | Chinese giant salamander       |
      | Alla          | Common surinam toad            |
      | Alla          | Smooth-sided toad              |
      | Alla          | Olm                            |
      | Alla          | Fire bellied toad               |
      | Alla          | Suwannee cooter                |
      | Alla          | Indian flapshell turtle        |
      | Alla          | South American snapping turtle |
      | Alla          | Zarudny's worm lizard          |
      | Alla          | Red worm lizard                |
      | Alla          | Bipes                          |
      | Frogs         | Amazon milk frog               |
      | Frogs         | Common spadefoot toad          |
      | Salamanders   | Axolotl                        |
      | Frogs         | Poison dart frog               |
      | Frogs         | Australian green tree frog     |
      | Salamanders   | Chinese giant salamander       |
      | Toads         | Common surinam toad            |
      | Toads         | Smooth-sided toad              |
      | Salamanders   | Olm                            |
      | Toads         | Fire bellied toad               |
      | Turtles       | Suwannee cooter                |
      | Turtles       | Indian flapshell turtle        |
      | Turtles       | South American snapping turtle |
      | Worm lizards  | Zarudny's worm lizard          |
      | Worm lizards  | Red worm lizard                |
      | Worm lizards  | Bipes                          |