Feature: Bank Manager Search Customer
  As a Bank Manager
  I want to be able to search customers by their name
  So that I can quickly review customer details

  Scenario: Successfully search for an existing customer
    Given I open the banking application
    When I log in as a Bank Manager
    And I navigate to the Customers tab
    And I search for customer "Harry"
    Then the customer list should display "Harry" in the search results