# Final-Project

Space Invaders

Contents: 
- images:
    - alien
    - spaceship
    - city scape
- sound:
    - game on
    - game over
    - gun fire
    - music during game play

Gameplay:
- rows of aliens slowly approaching the city (coming from screen top to bottom)
- spaceship defends the city (moves sideways / shoots upward)

Limits:
- game over if any alien contacts a building
- spaceship cannot move outside the screen
- a designated number of rows of aliens per level (each level adds a/some row/s and/or increases falling speed)
- occasionally a UFO flies overhead across the screen (last priority)

Structure:
- Main
- Constants
- Game
    - Casting
        - Actors
        - Cast
    - Directing
        - Director
    - Scripting
        - Collisions
        - Drawings
    - Services
        - Audio
        - Video
- Assets
    - Data
    - Fonts
    - Images
    - Sounds