@Browser:Chrome
@Browser:Firefox
Feature: Login
  As a person
  I want to be able to do something, so that I am able to see something

  Scenario: Correct login shows dashboard
    Given a user is on the 'x' page
    When the user logs in as username 'username' 
    And the user logs in with password 'password'
    And the user clicks the submit button
    Then the dashboard is shown

  Scenario Outline: Incorrect login shows error
    Given a user is on the "/login" page
    When the user logs in as username <username>
    And the user logs in with password <password>
    And the user clicks the submit button
    Then a login error is shown
    
    Examples:
    | username      | password    |
    | 'incorrect'   | 'incorrect' |
    | 'username'    | 'incorrect' |

