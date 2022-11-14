Feature: HowDoesItWork
    Find the "Lees meer" button
    Read the steps on the "HowDoesItWork" page

Scenario: Check if i'm able to visit the how does it work page
    Given I navigate to "http://localhost:3000/how-does-it-work"
    Then the text "Stap 1: Plaats je transport" is visible
    Then the text "Stap 2: Je ontvangt het exacte tijdvak" is visible
    Then the text "Stap 3: De koerier komt in actie" is visible
    Then I have to wait for 3 seconds