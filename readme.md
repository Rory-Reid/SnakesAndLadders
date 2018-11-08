# Snakes And Ladders

## Log

Solution started at 7:40
Stopped code at 9:12

## How to run

The solution is a class library with tests in mstest. There is presently no UI (as one was not necessary for this demonstration) and so the functionality of the application can be demonstrated by running the tests. The tests are written with MSTest, so require no additional packages to run.

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
- The feature tests will test all components integrated together. Individual tests will be added for classes to test their functions in isolation.
- Decided to start constructing the object graph from the Game class down.
- Didn't want to spend a mass amount of time branching and tidying due to time constraints. Decided to develop all in the master branch of the solution.

## Future evolution

- As the solution grows more complex and becomes runnable, will create a composition root class which will construct everything from the game class downwards.
- Will have some sort of player factory injected into the game so that on start it can construct the appropriate number of players on the fly.
  - Players might be modelled as classes called "Player", associated in some way with the token class, in order for the code to read more naturally? Though I don't see that much value from this, and it could juse lead to unnecessary layers?
- Will probably model squares, snakes and ladders as separate classes in the future.
  - As a result of this, the board should hold a representation of all its squares in memory rather than as it exists now, as effectively a class with an upper and lower boundary, with a method to check if your next move will be within the bounds.
- As I added more tests, they got a little harder to read. I didn't start tests with "Given/When/Then" which meant I had to alter the language of some steps slightly (as the original spec used the same phrases for different steps). Specflow might still be a neater way to go with this in the future, but the benefit now is that you can get all the context you need to understand these tests from one small file.
- Though a UI was not necessary, I would still have liked to have created some form of console app before moving onto the next part of the feature so that a human could drive the solution, in an effort to make it more demonstrable.
- Would like to tidy up the commits of this repository so they tell more of a story about implemented behaviours, versus a timeline of development (so that it would hopefully be more useful along the line, when reviewing).

## Assumptions

I assume that the person running this will be running it on an environment with the .net framework 4.6.1 or greater (I left the framework target as default for my environment).