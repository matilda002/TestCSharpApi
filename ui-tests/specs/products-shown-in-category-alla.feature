Feature: As a user, I want all products to be presented if they are shown filtered on the "Alla" category.

  Scenario Outline: When I choose the category "Alla", the product "<productName>" should be shown
    Given that I am on the product page
    When I choose the category "Alla"
    Then The product "<productName>" should be shown

    Examples:
      | productName                    |
      | Amazon milk frog               |
      | Common spadefoot toad          |
      | Axolotl                        |
      | Poison dart frog               |
      | Australian green tree frog     |
      | Chinese giant salamander       |
      | Common surinam toad            |
      | Smooth-sided toad              |
      | Olm                            |
      | Fire balled toad               |
      | Suwannee cooter                |
      | Indian flapshell turtle        |
      | South American snapping turtle |
      | Zarudny's worm lizard          |
      | Red worm lizard                |
      | Bipes                          |