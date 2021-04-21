@Browser:Chrome
Feature: Tool Tips
  As a user
  I want to be able to hover over elements, so that I am able to see a message

  Scenario: After hovering over button, message is shown
    Given a user is on the "/tool-tips" page
    When the user hovers over the button
    Then a button hover message is shown

  Scenario: After hovering over text field, message is shown
    Given a user is on the "/tool-tips" page
    When the user hovers over the text field
    Then a text hover message is shown

