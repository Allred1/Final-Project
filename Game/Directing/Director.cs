using System.Collections.Generic;
using FinalProject.Game.Casting;
// using FinalProject.Game.Scripting;
using FinalProject.Game.Services;
using Raylib_cs;
using System.Numerics;




namespace FinalProject.Game.Directing
{
    public class Director{
        private VideoService videoService;

        public Director(VideoService videoService){
            this.videoService = videoService;
        }
        
        public void StartGame(){

            // Configure rows of Aliens
            var alienObjects = new List<Actor>();

            var allObjects = new List<Actor>();

            int rowOneCounter = 0;
            int rowTwoCounter = 0;
            int rowThreeCounter = 0;
            int rowFourCounter = 0;
            int rowOneXPosition = 30;
            int rowTwoXPosition = 30;
            int rowThreeXPosition = 30;
            int rowFourXPosition = 30;

            // configure buildings
            var buildingObjects = new List<Actor>();
            var buildingPosition = new Vector2(90, 525);
            var buildingCounter = 0;
            
            // configure Player's position
            var artilleryPosition = new Vector2(Constants.SCREEN_WIDTH / 2, Constants.SCREEN_HEIGHT - 45);
            var artillerySize = 40;
            // configure ammunition's position           
            var ammunitionPosition = artilleryPosition;
            var ammunitionObjects = new List<Actor>();

            

            videoService.OpenWindow();

            // while the window is open, do stuff
            while(videoService.IsWindowOpen()){

                // aliens start at top of screen
                var rowOneYPosition = Constants.SCREEN_HEIGHT - Constants.SCREEN_HEIGHT - 30;
                var rowTwoYPosition = Constants.SCREEN_HEIGHT - Constants.SCREEN_HEIGHT - 100;
                var rowThreeYPosition = Constants.SCREEN_HEIGHT - Constants.SCREEN_HEIGHT - 170;
                var rowFourYPosition = Constants.SCREEN_HEIGHT - Constants.SCREEN_HEIGHT - 240;
                    
                // their actual position for movement    
                var rowOnePosition = new Vector2(rowOneXPosition, rowOneYPosition);
                var rowTwoPosition = new Vector2(rowTwoXPosition, rowTwoYPosition);
                var rowThreePosition = new Vector2(rowThreeXPosition, rowThreeYPosition);
                var rowFourPosition = new Vector2(rowFourXPosition, rowFourYPosition);

            

                // create the aliens
                // first row              
                if (rowOneCounter < 12){
                    var alien = new Aliens(Color.PURPLE, 100, new Rectangle());
                    alien.Position = rowOnePosition;
                    // this increments each alien drawn on that one row
                    rowOneXPosition += 85;

                    alien.Velocity = new Vector2(0,0.2f);
                    // alienObjects.Add(alien);
                    allObjects.Add(alien);
                    rowOneCounter += 1;
                }
                // second row
                if (rowTwoCounter < 12){
                    var alien = new Aliens(Color.BLUE, 100, new Rectangle());
                    alien.Position = rowTwoPosition;
                    rowTwoXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    // alienObjects.Add(alien);
                    allObjects.Add(alien);
                    rowTwoCounter += 1;
                }
                // third row
                if (rowThreeCounter < 12){
                    var alien = new Aliens(Color.ORANGE, 100, new Rectangle());
                    alien.Position = rowThreePosition;
                    rowThreeXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    // alienObjects.Add(alien);
                    allObjects.Add(alien);
                    rowThreeCounter += 1;
                }
                // fourth row
                if (rowFourCounter < 12){
                    var alien = new Aliens(Color.WHITE, 100, new Rectangle());
                    alien.Position = rowFourPosition;
                    rowFourXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    // alienObjects.Add(alien);
                    allObjects.Add(alien);
                    rowFourCounter += 1;
                }


                // buildings
                if (buildingCounter < 5){
                    var building = new Building(Color.DARKGRAY, 90, new Rectangle(buildingPosition.X, buildingPosition.Y, 30, 30));
                    building.Position = buildingPosition;
                    buildingPosition.X += 200;
                    building.Velocity = new Vector2(0,0);
                    buildingObjects.Add(building);
                    allObjects.Add(building);
                    buildingCounter += 1;
                }


                
                // begin drawing
                videoService.ClearBuffer();

                
                
                // check for the user's artillery movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)){
                    artilleryPosition.X += Constants.ARTILLERY_VELOCITY;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)){
                    artilleryPosition.X -= Constants.ARTILLERY_VELOCITY;
                }


                // TRYING TO GET LASERBEAM TO WORK
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    Missile();                    
                }

                void Missile(){
                    var ammunition = new Ammunition(Color.RED, 25, new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25));
                    ammunition.Position = new Vector2((artilleryPosition.X + (artillerySize / 4)), (ammunitionPosition.Y - (artillerySize / 2)));
                    // var ammunitionNewRectangle = new Rectangle(())
                    ammunition.Velocity = new Vector2(0,-Constants.AMMUNITION_VELOCITY);
                    ammunitionObjects.Add(ammunition);
                    allObjects.Add(ammunition);
                }

             

                
                // Draw the objects
                void DrawObjects(){
                    // draw the objects
                    // foreach (var obj in alienObjects.ToList()) {
                    //     obj.Draw();
                    // }
                    // foreach (var obj in buildingObjects.ToList()) {
                    //     obj.Draw();
                    // }
                    // foreach (var obj in ammunitionObjects.ToList()) {
                    //     obj.Draw();
                    // }

                    // all objects
                    foreach (var obj in allObjects.ToList()) {
                        obj.Draw();
                    }
                }
                DrawObjects();


                // end drawing
                videoService.FlushBuffer();


                // Move the objects
                void MoveObjects(){
                    // move positions of the objects
                    // foreach (var obj in alienObjects) {
                    //     obj.Move();
                    // }
                    // foreach (var obj in ammunitionObjects) {
                    //     obj.Move();
                    // }

                    // all objects
                    foreach (var obj in allObjects) {
                        obj.Move();
                    }
                }
                MoveObjects();


                // Remove objects if they pass beyond a certain y-value
                void removeObjects(){
                    // foreach (var obj in alienObjects.ToList()){
                    //     if (obj.Position.Y >= 620) {
                    //         alienObjects.Remove(obj);
                    //     }
                    //     if (obj.Position.Y <= -50) {
                    //         ammunitionObjects.Remove(obj);
                    //     }
                    // }
                    foreach (var obj in allObjects.ToList()) {
                        if (obj.Position.Y >= 620) {
                            allObjects.Remove(obj);
                        }
                        if (obj.Position.Y <= -300) {
                            allObjects.Remove(obj);
                            ammunitionObjects.Remove(obj);
                        }
                    }
                }
                removeObjects();


                // handle collisions
       

                // combine all lists of objects into a list
                // var allObjects = new List<List<List<Actor>>>();


                // var allAliensList = new List<List<Actor>>();
                // // add alien objects
                // allAliensList.Add(rowOneObjects);
                // allAliensList.Add(rowTwoObjects);
                // allAliensList.Add(rowThreeObjects);
                // allAliensList.Add(rowFourObjects);


                /*
                All lists:
                - aliens list
                - building list
                - ammunition list

                Need:
                - check collisions for:
                    - aliens & buildings
                    - aliens & ammunitions
                    - ammunitions & buildings

                
                I'll need to iterate through
                - aliens list
                - ammunitions (does ammunitions need to be a object list?)



                */
            

                /*
                foreach (var obj in list.ToList()){
                    var rectangle = new Rectangle(obj.Position.X, obj.Position.Y, width, height);
                    if (Raylib.CheckCollisionRecs(rectangles1, rectangles2)){
                        do something
                        [in general: remove the object, whatever it is]
                        (for aliens & buildings: destroy buildings & subtract 1 of 5 lives)
                        (for aliens & ammunitions: destroy aliens & add point to score)
                        (for buildings and ammunitions: subtract several points from score)
                    }
                }

                */
                foreach (var obj in allObjects.ToList()){
                    // var buildingRectangle = createRectangle((int)buildingPosition.X, (int)buildingPosition.Y, 100, 100);
                    // var ammunitionRectangle = createRectangle((int)artilleryPosition.X, (int)ammunitionPosition.Y, 10, 25);

                    // testing vector rectangle
                    // var ammunitionRectangle = createRectangle(ammunitionPosition, 25, Color.PURPLE);
                    // var ammunitionSize = new Vector2(25,25);
                    // Raylib.DrawRectangleV(ammunitionPosition, ammunitionSize, Color.PURPLE);
                    // Raylib.DrawRectangleV(buildingPosition, , Color.PURPLE);
                    // Raylib.DrawRectangle((int)buildingPosition.X, (int)buildingPosition.Y, 30, 30, Color.PURPLE);


                    
                    // if (Raylib.CheckCollisionRecs(buildingRectangle, ammunitionRectangle)){
                    //     foreach (var laser in ammunitionObjects){
                    //         ammunitionObjects.Remove(laser);
                    //         allObjects.Remove(laser);
                    //     }
                    // }
                }


                // function to create a rectangle/ parameters pass in the width and height
                // build all the rectangles in the "foreach" loop, and then check all the conditions
                // Rectangle createRectangle(int positionX, int positionY, int width, int height) {
                //     var rectangle = new Rectangle(positionX, positionY, width, height);
                //     Raylib.DrawRectangle(positionX, positionY, width, height, Color.PURPLE);
                //     return rectangle;
                // // }
                // void createRectangle(Vector2 vectorPosition, Vector2 size, Color color) {
                //     // var rectangle = new RectangleV(positionX, positionY, width, height);
                //     Raylib.DrawRectangleV(vectorPosition, size, color);
                //     // Raylib.DrawRectangleV(vectorPosition, size, Color.PURPLE);
                    
                // }



                // iterate through each list in the allAliensList

                // foreach (var lists in allObjects.ToList()){
                //     foreach (var list in allAliensList.ToList()){
                //     // build rectangles around aliens
                //         foreach (var obj in list.ToList()){
                //             var alienRectangles = new Rectangle(obj.Position.X, obj.Position.Y, 100, 100);
                //         }
                //     }

                //     // build rectangles around the ammunitions
                //     foreach (var obj in ammunitionObjects.ToList()){
                //         var ammunitionRectangle = new Rectangle(ammunitionPosition.X - 1, ammunitionPosition.Y + 1, 10, 25);
                //     }

                //     // build rectangles around the buildings
                //     foreach (var obj in buildingObjects.ToList()){
                //         var buildingRectangle = new Rectangle(buildingPosition.X - 1, buildingPosition.Y + 1, 45, 45);
                //     }

                //     foreach ()
                //     if (Raylib.CheckCollisionRecs(alienRectangles, ammunitionRectangle)){
                //         var fire = true;
                //     }


                    // foreach (var obj in allObjects.ToList()){
                    //     if (Raylib.CheckCollisionRecs(alienRectangles, ammunitionRectangle)){
                    //         var fire = true;
                    //     }
                    // }
                // }
                
                


  

                // Draw artillery (player)
                Raylib.DrawText("W", (int)artilleryPosition.X, (int)artilleryPosition.Y, artillerySize, Color.DARKBLUE);  
                Raylib.DrawText("V", (int)artilleryPosition.X, (int)artilleryPosition.Y, artillerySize, Color.GRAY);                 
                // Raylib.DrawText("I", (int)ammunitionPosition.X, (int)ammunitionPosition.Y, 20, Color.RED);
            
                // draw the Score
                Raylib.DrawRectangle(0,0,Constants.SCREEN_WIDTH, 30, Color.DARKGRAY);                 
                Raylib.DrawText(Constants.SCORE_TEXT, (int)Constants.SCORE_POSITION_X, (int)Constants.SCORE_POSITION_Y, Constants.SCORE_SIZE, Constants.SCORE_COLOR);  

            }
   
            // unload textures
            // videoService.UnloadImages();
            videoService.CloseWindow();
        }
    }
}


/*
Notes to self:

Aliens: check
Artillery: check
Buildings: check
Ammunition: check

Need: 

- collisions (aliens against buildings, ammunition against aliens) (remove the aliens or building upon collisions)


*/