import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('that I am on the product page', () => {
  cy.visit("/products")
});

When('I choose the category "Alla"', () => {
    cy.get('#categories').select('Alla')
});

Then('The product {string} should be shown', (productName) => {
    cy.get('.products').contains('.name', productName).should('be.visible')
});
