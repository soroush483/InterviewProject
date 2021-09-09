Feature: Login and select a product
	Login to Tennis-Point Demo website for CGI Interview

@smoke
Scenario: Perform Login To Tennis-Point Demo website 
and then Check logged in details is correct or not,
then search for specific product(Wilson H2 Komfortschläger tennis racket) 
then add it with Grip Size 1 to the shopping cart, 
shopping cart should contains the product
	#Steps
	Given I open the login webpage
	Given click accept cookie button
	And I enter the following details
		| Username                    | Password    |
		| soroush.forouzani@gmail.com | soroush1234 |
	And I click Anmelden button
	Then I should see Soroush in Mein Konto as logedin customer
	And I enter Wilson H2 Komfortschläger in search box
	And click on product link
	And click on Size one button For Grip Strenght
	And click on the In Den Warenkorb button to add product to cart
	Then I should see Wilson H2 Komfortschläger in the cart