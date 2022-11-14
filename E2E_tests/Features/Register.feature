Feature: Register
	Load registerpage
	Fill the form
	Create account
	Wait until the register process finishes
    Find text Inloggen

Scenario: Check if i'm able to register
	Then I navigate to "http://localhost:3000/register"
	Then the text "Registeren" is visible
	Then I have to wait for 3 seconds
	Then I fill in the registerform 
	And press on register send
	Then I have to wait for 3 seconds
	Then the text "Inloggen" will be visible on the loginpage