@Browser:Chrome
Feature: Droppable
  As a user
  I want to be able to drag an element, so that I am able to move it on the page

  Scenario: Draggable box is able to be moved
    Given a user is on the "/droppable" page
    When the user drags the box to the drop zone
    Then a drop message is shown
