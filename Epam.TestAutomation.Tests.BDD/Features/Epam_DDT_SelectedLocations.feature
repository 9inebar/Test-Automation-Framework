Feature: Epam_DDT_SelectedLocations
As an automation engineer
I want to test Epam site for career opportunities
by selecting different locations
and verify that returned results match

    @automation @DDT
    Scenario Outline: Check that search results contain selected locations
        Given I navigate to Epam site
        Given I accept all cookies on Epam site
        And navigate to Careers page
        When I click on Location drop-down I select "<country>" and "<city>"
        And click Find button
        Then the "<search result>" contains keyword
	
        Examples: Job positions
          | country | city    | searchResult |
          | Belgium | Ghent   | Belgium      |
          | Canada  | Toronto | Canada       |