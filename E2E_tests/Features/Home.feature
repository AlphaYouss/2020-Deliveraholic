Feature: Home
    Load Homepage
    Find text Home

Scenario: Check if i'm able to visit the homepage
    Given I navigate to "http://localhost:3000"
    Then the text "Zo makkelijk werkt het" is visible
    Then I have to wait for 3 seconds