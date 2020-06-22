Feature: Create a Patient account
	As a Patient 16 or over
	I want to create an account on Summatix
	So that I can access the Summatix platform

@Regression

Scenario Outline: Login
Given I login to application using '<email>' and '<password>' 
Then I add new hcp using '<template>'

Examples:
| email                        | password   | template         |
| operations.five@summatix.com | 4uPp0rt#23 | Hcptestdata.xlsx |
