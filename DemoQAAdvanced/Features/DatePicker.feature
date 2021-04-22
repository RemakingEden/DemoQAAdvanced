@Browser:Chrome
Feature: Date Picker
  As a user
  I want to be able to change the date, so that I am able to set the correct date

  Scenario: New date can be set
    Given a user is on the "/date-picker" page
    When the user enters a new date
    Then the same date the user entered is displayed


