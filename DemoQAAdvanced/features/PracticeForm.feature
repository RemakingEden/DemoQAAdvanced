﻿@Browser:Chrome
@Browser:Firefox
Feature: Practice Form
  As a user
  I want to be able to complete a form, so that I am able to send details to the site

  Scenario: All mandatory fields filled allows form to be submitted
    Given a user is on the "/automation-practice-form" page
    When the user enters info into all mandatory fields
    And the user clicks the submit button
    Then the details entered are reflected correctly

  Scenario: All mandatory fields not filled shows validation error
    Given a user is on the "/automation-practice-form" page
    When the user clicks the submit button
    Then all appropriate field validation messages are shown

    Scenario: email wrong format shows validation error
    Given a user is on the "/automation-practice-form" page
    When the user enters the email 'WrongFormat' 
    And the user clicks the submit button
    Then athe email field validation is shown

    Scenario: Letters in phone number shows validation error
    Given a user is on the "/automation-practice-form" page
    When the user enters the phone number 'WrongFormat' 
    And the user clicks the submit button
    Then the phone number fields validation is shpwn
    
    Scenario: All fields filled allows form to be submitted
    Given a user is on the "/automation-practice-form" page
    When the user enters info into all fields
    And the user clicks the submit button
    Then the details entered are reflected correctly

    Scenario: Uploading PNG is accepted
    Given a user is on the "/automation-practice-form" page
    When the user enters all mandatory fields
    And the user uploads a 'PNG' file to the picture field
    And the user clicks the submit button
    Then the details entered are reflected correctly

    Scenario: Uploading JPG is accepted
    Given a user is on the "/automation-practice-form" page
    When the user enters all mandatory fields
    And the user uploads a 'JPG' file to the picture field
    And the user clicks the submit button
    Then the details entered are reflected correctly

    Scenario: Uploading large picture is accepted
    Given a user is on the "/automation-practice-form" page
    When the user enters all mandatory fields
    And the user uploads a 5MB+ file to the picture field
    And the user clicks the submit button
    Then the details entered are reflected correctly

    Scenario: Can cancel picture upload and continue
    Given a user is on the "/automation-practice-form" page
    When the user enters all mandatory fields
    And the user clicks to upload a picture
    And the user clicks cancel on the picture upload modal
    And the user clicks the submit button
    Then the details entered are reflected correctly

    Scenario: Can remove subjects individually
    Given a user is on the "/automation-practice-form" page
    When the user enters five subjects
    And the user deletes two subjects individually
    Then three undeleted subjects remain

    Scenario: Can remove all subjects
    Given a user is on the "/automation-practice-form" page
    When the user enters five subjects
    And the user deletes all subjects with the remove all button
    Then all subjects are removed 