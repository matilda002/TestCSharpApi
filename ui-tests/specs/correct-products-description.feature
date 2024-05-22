Feature: As a user, I want all products to be presented regardless of whether they are shown in a filtered category with the correct description.
  
  Scenario Outline: When I choose the category "<category>" the product "<productName>", should be shown with the correct description "<description>"
    Given that I am on the product page
    When I choose the category "<category>"
    Then I should see the description "<description>" for the product "<productName>"

    Examples:
      | category      | productName                    | description                                                                                                                                            |
      | Alla          | Amazon milk frog               | The amazon milk frog is a bigger species (around 10cm in length) with stripes and blue blood!!                                                         |
      | Alla          | Common spadefoot toad          | The common spadefoot toad also known as the garlic toad is a type of frog, not toad.                                                                   |
      | Alla          | Axolotl                        | The famous axolotl, a specie with the ability to regrow its body parts :o                                                                              |
      | Alla          | Poison dart frog               | Don't let the poison in the poison dart frog's name fool you! It's perfectly safe to handle in captivity as long as you don't feed the wrong critters. |
      | Alla          | Australian green tree frog     | The australian green tree frog is the perfect beginner frog. Easy to take care of.                                                                     |
      | Alla          | Chinese giant salamander       | The chinese giant salamander is one of the largest salamanders in the world reaching 1.8m in length!                                                   |
      | Alla          | Common surinam toad            | This species of toad, the surinam toad lives exclusively in a aquatic environment. They also have an unique ability to become flat as a pancake!       |
      | Alla          | Smooth-sided toad              | A smooth-sided toad is a beautiful brown toad with a dark brown stripe on their side.                                                                  |
      | Alla          | Olm                            | The olm is a salamander that lives in the european caves. Their environment has given them a unique slender appearance.                                |
      | Alla          | Fire bellied toad              | The fire balled toad has a colorful pattern unlike most toad species.                                                                                  |
      | Alla          | Suwannee cooter                | Suwanne cooter is native to Florida and has striking yellow stripes.                                                                                   |
      | Alla          | Indian flapshell turtle        | The Indian flapshell turtle has nostrils with a similar appearance to a pig.                                                                           |
      | Alla          | South American snapping turtle | Like their name, snapping turtles has fast reflexes and powerful beak.                                                                                 |
      | Alla          | Zarudny's worm lizard          | A worm lizard from the Arabian peninsula with a love for sandy environments.                                                                           |
      | Alla          | Red worm lizard                | One of the bigger specie of worm lizards reaching lengths of 80 cm.                                                                                    |
      | Alla          | Bipes                          | Bipes or Mexican worm lizard has small forearms with five toes.                                                                                        |
      | Frogs         | Amazon milk frog               | The amazon milk frog is a bigger species (around 10cm in length) with stripes and blue blood!!                                                         |
      | Frogs         | Common spadefoot toad          | The common spadefoot toad also known as the garlic toad is a type of frog, not toad.                                                                   |
      | Salamanders   | Axolotl                        | The famous axolotl, a specie with the ability to regrow its body parts :o                                                                             |
      | Frogs         | Poison dart frog               | Don't let the poison in the poison dart frog's name fool you! It's perfectly safe to handle in captivity as long as you don't feed the wrong critters. |
      | Frogs         | Australian green tree frog     | The australian green tree frog is the perfect beginner frog. Easy to take care of.                                                                     |
      | Salamanders   | Chinese giant salamander       | The chinese giant salamander is one of the largest salamanders in the world reaching 1.8m in length!                                                   |
      | Toads         | Common surinam toad            | This species of toad, the surinam toad lives exclusively in a aquatic environment. They also have an unique ability to become flat as a pancake!       |
      | Toads         | Smooth-sided toad              | A smooth-sided toad is a beautiful brown toad with a dark brown stripe on their side.                                                                  |
      | Salamanders   | Olm                            | The olm is a salamander that lives in the european caves. Their environment has given them a unique slender appearance.                                |
      | Toads         | Fire bellied toad              | The fire balled toad has a colorful pattern unlike most toad species.                                                                                  |
      | Turtles       | Suwannee cooter                | Suwanne cooter is native to Florida and has striking yellow stripes.                                                                                   |
      | Turtles       | Indian flapshell turtle        | The Indian flapshell turtle has nostrils with a similar appearance to a pig.                                                                           |
      | Turtles       | South American snapping turtle | Like their name, snapping turtles has fast reflexes and powerful beak.                                                                                 |
      | Worm lizards  | Zarudny's worm lizard          | A worm lizard from the Arabian peninsula with a love for sandy environments.                                                                           |
      | Worm lizards  | Red worm lizard                | One of the bigger specie of worm lizards reaching lengths of 80 cm.                                                                                    |
      | Worm lizards  | Bipes                          | Bipes or Mexican worm lizard has small forearms with five toes.                                                                                        |