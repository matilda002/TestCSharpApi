import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I am on the startpage', () => {
  cy.visit("/");
});

Then('the heading 1 should say {string}', (headingContent) => {
  cy.get('h1').contains(headingContent);
});