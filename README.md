# **ProjectNewHorizons2**

## About this project project
This is a project we made for our second group project of the first year of Saxion's Creative Media and Game Technologies study. 
We made this game with a team of 7 (2 engineers, 2 designers, 3 artists) over the span of 3 weeks.
Release page: https://shrimpcouncil.itch.io/ratrooms

[insert video here]

### Running the project
To run this project:
1. Download the project
2. Install Unity Hub and Unity 6000.0.66f2
3. Add the project to Unity Hub
4. Run the project

## Technical bits

- We created a resource manager using using the amount of characters and their statistics to calculate the speed of resource creation.
- We created character statistics that, by taking the average stat of each character in the room. Stats are generated using a stat plug system, with preset combinations of stats which are generated in layers to give more variety.
- We created a camera controller for mobile, including zooming and dragging borders.
- We created an additional camera controller that allows the user to move the camera during dragging of a character, by dragging the character to the edge of the screen.
- We created an additional camera controller that allows the player to zoom in and out by pinching the screen.
- We created a drag-and-drop system where the game reads location data and passes that through to a navmesh agent so it walks towards the room you dragged it into. It is also used to move the camera around the level.

### The critical error
During this project we had one critical error: the first repository stopped working, so we had to migrate all work to a new repository to restore functionality. To this day we still don't know what the error was about, after project migration all errors were resolved.



