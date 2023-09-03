Feature: CalculatorOperations
	Simple calculator for adding two numbers

@msmoke
@learning
Scenario: Calculator Sum
	Given the first number is 2
	And the second number is 3
	When the two numbers are added
	And Sum operation is selected
	Then the result should be 5
	
	@msmoke
	@learning
	Scenario: Calculator Diff
	Given the first number is 6
	And the second number is 3
	When the two numbers are added
	And Sum operation is selected
	Then the result should be 2