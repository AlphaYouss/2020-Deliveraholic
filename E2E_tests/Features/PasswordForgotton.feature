Feature: PasswordForgotton
    Load ForgotPasswordpage
    Fill the form
    Change password
    Wait until the ForgotPassword process finishes
    Find text Inloggen

Scenario: Check if i'm able to change password
	Given I'm logged in, I need to logout
    Given I navigate to "http://localhost:3000/forgot-password"
    Then I have to wait for 3 seconds
    Then the text "Wachtwoord vergeten" is visible
    Then I fill in the forgotPasswordform 
    And press on forgotPassword send
    Then I have to wait for 3 seconds
    Then the text "Inloggen" is visible