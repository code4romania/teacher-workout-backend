Feature: Themes
	As a user
	I want to be able to list themes
	
Scenario: Admin user can create a theme
	Given Ion is an admin
	When Ion creates a theme
	Then the theme was created successfully
