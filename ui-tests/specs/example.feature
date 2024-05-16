Feature: As a user I want the startpage to have a heading 1 that says Welcome.

  Scenario: Check that the headline is correct
    Given that I am on the startpage
    Then the heading 1 should say "Welcome"
