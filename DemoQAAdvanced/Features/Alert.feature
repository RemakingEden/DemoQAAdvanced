@Browser:Chrome
Feature: Alert
  As a user
  I want to be able to click on a button, so that I am able to see an alert

  Scenario: After clicking button, alert is seen
    Given a user is on the "/alerts" page
    When the user clicks on the second button
    And waits for five seconds
    Then an alert is shown

    Scenario: Accepting alert dismisses it
    Given a user is on the "/alerts" page
    When the user clicks on the second button
    And waits for five seconds
    And dismisses the alert
    Then the alert is no longer shown