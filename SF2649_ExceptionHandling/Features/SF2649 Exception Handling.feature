Feature: SF2649 Exception Handling

These are scenarios that confirm exception handling behavior of SpecFlow


Scenario: Normal Exception in synchronous step definition
	Given A normal exception
	When thrown from a non-Async step definition
	Then stack trace and messages are properly preserved

Scenario: Normal Exception with an inner exception in synchronous step definition
	Given A normal exception with an inner exception
	When thrown from a non-Async step definition
	Then stack trace and messages are properly preserved

Scenario: Normal Exception in an asynchronous step definition
	Given A normal exception
	When thrown from an Async step definition
	Then stack trace and messages are properly preserved

Scenario: Normal Exception with an inner exception in an asynchronous step definition
	Given A normal exception with an inner exception
	When thrown from an Async step definition
	Then stack trace and messages are properly preserved

Scenario: Aggregrate Exception in synchronous step definition
	Given An aggregate exception
	When thrown from a non-Async step definition
	Then stack trace and messages are properly preserved

Scenario: Aggregate Exception in an asynchronous step definition
	Given An aggregate exception
	When thrown from an Async step definition
	Then stack trace and messages are properly preserved

Scenario: Aggregate Exception with no Inner Exception in an asynchronous step definition
	Given An aggregate exception with no Inner Exception
	When thrown from an Async step definition
	Then stack trace and messages are properly preserved
