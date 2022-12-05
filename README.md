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



More detailed outline: 

Main: begins the game. Using abstraction and encapsulation. 
Constants: stores the general data for video and audio output. Uses polymorphism. 
Game (folder)
    - Casting (folder)
        - Actors 
        - Cast: will contain all the actors. Will incorporate inheritance. 
            - Aliens: configure the alien objects. Has inheritance. 
            - Artillery: configure the artillery object. Has inheritance. 
            - Buildings: configure the building objects. Has inheritance. 
    - Directing (folder)
        - Director: directs the game classes. Uses encapsulation. 
    - Scripting (folder)
        - Draw: a basic draw class used for all objects. Will be inherited. 
        - DrawAliens: draws the aliens. Uses inheritance.
        - DrawArtillery: draws the artillery. Uses inheritance. 
        - Update: basic update class used for all moving objects. Will be inherited. 
        - UpdateAliens: updates the aliens movement. Uses inheritance. 
        - UpdateArtillery: updates the artillery’s movement. Uses inheritance. 
        - Collisions: basic collision class used for all moving objects. Will be inherited. 
        - CollisionBorders: detects collision against the screen window. Uses inheritance. 
        - CollisionBuildings: detects alien collision against the buildings. Uses inheritance. 
        - CollisionBullets: detects collision of bullets against aliens. Uses inheritance. 
    - Services (folder)
        - Keyboard: configures input. Uses abstraction. 
        - Audio: configures audio output. Uses polymorphism and abstraction. 
        - Video: configures visual output. Uses polymorphism and abstraction. 
Assets (folder)
- Fonts: configures the fonts. 
- Images: stores the images. 
- Sounds: stores the sounds. 
