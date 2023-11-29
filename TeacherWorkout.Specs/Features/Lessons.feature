Feature: Lessons
    As a user
    I want to be able to list lessons

Scenario: User can list lessons
    Given Daniel is a user
    When Daniel requests lessons 
    Then Daniel receives the lessons

Scenario: User searches for a lesson by title
    Given Daniel is a user
    When Daniel searches a lesson
    Then Daniel receives the searched lesson
