Feature: Dobkin/PetersonTest
As a Tester I want to navigate to Epam site
to proceed to Leadership page and assert that
Dobkin and Peterson names are displayed

    @epam @bdt @dobkin
    Scenario: Epam site - Header - Check Epam Leadership page contains Dobkin
        Given I Navigate to landing page of Epam site
        And accept all cookies on Epam site
        When click About element
        And click Leadership element
        When I scroll to Dobkin element
        Then I assert Dobkin displayed
	
    @epam @bdt @peterson
    Scenario: Epam site - Header - Check Epam Leadership page contains Peterson
        Given I Navigate to landing page of Epam site
        And accept all cookies on Epam site
        When click About element
        And click Leadership element
        When I scroll to Peterson element
        Then I assert Peterson displayed