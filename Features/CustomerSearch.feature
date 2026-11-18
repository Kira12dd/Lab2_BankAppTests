Feature: Bank Manager Search Customer
  As a Bank Manager
  I want to be able to search customers by their name
  So that I can quickly review customer details

  Background:
    Given I open the banking application
    And I log in as a Bank Manager
    And I navigate to the Customers tab

  Scenario Outline: Search for an existing customer
    When I search for customer "<name>"
    Then only customers matching "<name>" should be displayed

    Examples:
      | name     |
      | Harry    |
      | Albus    |

  Scenario: Search for a non-existing customer
    When I search for customer "Nobody"
    Then no customers should be displayed

