import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Then('I should see the description {string} for the product {string}', (description, productName) => {
    cy.get('.product').contains('.product', productName).find('p.description').contains(description)
});