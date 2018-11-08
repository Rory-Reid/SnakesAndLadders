# Snakes And Ladders

## Log

Solution started at 7:40

## How to run

Currently, the solution is not runnable

## Approach to the problem

Since the problem is very well specified with features broken down into scenarios with user stories and behaviours specified with a Given/When/Then syntax, it should be very easy to write tests to demonstrate all functionality. Snakes and Ladders also has the benefit of being a very small domain with a clear language, so keeping my code as close as possible to the language of the challenge will aid in keeping it readable and understandable - a more accurate model. My approach is as follows:
- Start by modelling the domain objects with empty methods / basic properties setup to match the language of the spec.
- Build high-level feature test to automate validation of the spec.
- Implement work to pass the tests, writing tests for individual classes along the way.
- Reconsider design once we have some functionality.
- Move onto next scenario.

## Key decisions

Key decisions made for this challenge are as follows:

- UI Not necessary. Create a class library for now and worry about running it later. Potentially add a console app to drive it before the hour's done, but focus on running code via tests first.
- Debated using Specflow to specify and run high level tests (since it allows you to use a given/when/then syntax). In an effort to keep the solution simple at this point I'll just build the feature tests without a tool.

## Future evolution

## Assumptions made

No assumptions at present