Feature: Themes
	As a user
	I want to be able to list themes
	
Scenario: Admin user can create a theme
	Given Ion is an admin
	When Ion creates a theme
	Then the theme was created successfully

Scenario: Authenticated user can list themes
	Given Ion is an admin
	And Vasile is an authenticated user
	And Ion creates a theme
	When Vasile requests themes
	Then Vasile receives the theme
