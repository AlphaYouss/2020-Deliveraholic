Feature: Login
	Load Loginpage
	Fill the form
	Log in
	Wait until the login process finishes
    Find text Userhome

Scenario: Check if i'm able to login
	Given I navigate to "http://localhost:3000/login"
	Then the text "Inloggen" is visible
	Then I have to wait for 3 seconds
	Then I fill in the loginform 
	And press on login send
	Then I have to wait for 3 seconds
	Then the text "Userhome" will be visible