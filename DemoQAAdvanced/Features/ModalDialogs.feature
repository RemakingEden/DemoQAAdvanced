@Browser:Chrome
Feature: Modal Dialogs
  As a user
  I want to be able to click elements, so that I am able to see a modal 

  Scenario: Small modal button shows modal
    Given a user is on the "/modal-dialogs" page
    When the user clicks on the small modal button
    Then a small modal is shown

    Scenario: Closing small modal returns back to past screen
    Given a user is on the "/modal-dialogs" page
    When the user clicks on the small modal button
    And clicks close on the small modal box
    Then a small modal is no longer showing



