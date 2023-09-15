Feature: Epam_DDT_keywords
As an automation engineer
I want to test EPAM site for career opportunities
by entering multiple search criteria
and verify that returned results match

    @automation @DDT
    Scenario Outline: Check that search results contain keywords
        Given I navigate to Epam site
        Given I accept all cookies on Epam site
        And navigate to Careers page
        When enter a "<keyword>"
        And click Find button
        Then the "<search result>" contains keyword
	
        Examples: Job positions
          | keyword                       | searchResult                  |
          | Junior .NET Developer         | Junior .NET Developer         |
          | Scrum Master/Delivery Manager | Scrum Master/Delivery Manager |