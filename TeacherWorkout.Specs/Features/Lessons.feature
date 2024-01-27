Feature: Lessons
	As a user
	I want to be able to list lessons

Scenario: Admin user can save a lesson
	Given Ion is an admin
	When Ion saves a lesson
	Then the lesson was saved successfully
