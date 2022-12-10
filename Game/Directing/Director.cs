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
        
        public void StartGame()
        {

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
            var buildingRectangle = new Rectangle((int)buildingPosition.X, (int)buildingPosition.Y, 63, 63);
            // var buildingRectangle = new Rectangle();
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

                // var rowOneAlienRectangle = new Rectangle(rowOnePosition.X, rowOnePosition.Y, 50, 50);
                // var rowTwoAlienRectangle = new Rectangle(rowTwoPosition.X, rowTwoPosition.Y, 50, 50);
                // var rowThreeAlienRectangle = new Rectangle(rowThreePosition.X, rowThreePosition.Y, 50, 50);
                // var rowFourAlienRectangle = new Rectangle(rowFourPosition.X, rowFourPosition.Y, 50, 50);


                var ammunitionRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                // var ammunitionRectangle = new Rectangle();


            

                // create the aliens
                // first row              
                if (rowOneCounter < 12){
                    var alien = new Aliens(Color.PURPLE, 100);
                    alien.Position = rowOnePosition;
                    // alien.Rectangle = rowOneAlienRectangle;
                    // this increments each alien drawn on that one row
                    rowOneXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    alienObjects.Add(alien);
                    alien.isBuilding = false;
                    alien.isAlien = true;
                    alien.isAmmunition = false;
                    allObjects.Add(alien);
                    rowOneCounter += 1;
                }
                // second row
                if (rowTwoCounter < 12){
                    var alien = new Aliens(Color.BLUE, 100);
                    alien.Position = rowTwoPosition;
                    // alien.Rectangle = rowTwoAlienRectangle;
                    rowTwoXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    alienObjects.Add(alien);
                    alien.isBuilding = false;
                    alien.isAlien = true;
                    alien.isAmmunition = false;
                    allObjects.Add(alien);
                    rowTwoCounter += 1;
                }
                // third row
                if (rowThreeCounter < 12){
                    var alien = new Aliens(Color.ORANGE, 100);
                    alien.Position = rowThreePosition;
                    // alien.Rectangle = rowThreeAlienRectangle;
                    rowThreeXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    alienObjects.Add(alien);
                    alien.isBuilding = false;
                    alien.isAlien = true;
                    alien.isAmmunition = false;
                    allObjects.Add(alien);
                    rowThreeCounter += 1;
                }
                // fourth row
                if (rowFourCounter < 12){
                    var alien = new Aliens(Color.WHITE, 100);
                    alien.Position = rowFourPosition;
                    // alien.Rectangle = rowFourAlienRectangle;
                    rowFourXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    alienObjects.Add(alien);
                    alien.isBuilding = false;
                    alien.isAlien = true;
                    alien.isAmmunition = false;
                    allObjects.Add(alien);
                    rowFourCounter += 1;
                }


                // buildings
                if (buildingCounter < 5){
                    var building = new Building(Color.DARKGRAY, 90);
                    building.Position = buildingPosition;
                    // building.Rectangle = buildingRectangle;
                    // building.Rectangle = new Rectangle((int)buildingPosition.X, (int)buildingPosition.Y, 63, 63);
                    building.Rectangle = buildingRectangle;
                    
                    buildingPosition.X += 200;
                    building.Velocity = new Vector2(0,0);
                    // identify what it is and isn't
                    building.isBuilding = true;
                    building.isAlien = false;
                    building.isAmmunition = true;
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
                    var ammunition = new Ammunition(Color.RED, 25);
                    ammunition.Position = new Vector2((artilleryPosition.X + (artillerySize / 4)), (ammunitionPosition.Y - (artillerySize / 2)));
                    // ammunition.newRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                    // var ammunitionNewRectangle = new Rectangle(())
                    // var ammunitionRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                    ammunition.Rectangle = ammunitionRectangle;
                    // ammunition.Rectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                    // ammunitionRectangle = ammunition.Rectangle;
                    ammunition.Velocity = new Vector2(0,-Constants.AMMUNITION_VELOCITY);
                    ammunition.isBuilding = false;
                    ammunition.isAlien = false;
                    ammunition.isAmmunition = true;
                    ammunitionObjects.Add(ammunition);
                    allObjects.Add(ammunition);
                }
                

             

                
                // Draw the objects
                void DrawObjects(){
                    // draw the objects
                    foreach (var obj in alienObjects.ToList()) {
                        obj.Draw();
                    }
                    foreach (var obj in buildingObjects.ToList()) {
                        obj.Draw();
                    }
                    foreach (var obj in ammunitionObjects.ToList()) {
                        obj.Draw();
                    }

                    // // all objects
                    // foreach (var obj in allObjects.ToList()) {
                    //     obj.Draw();
                    // }
                }
                DrawObjects();
                


                // end drawing
                videoService.FlushBuffer();


                // Move the objects
                void MoveObjects(){
                    // move positions of the objects
                    foreach (var obj in alienObjects.ToList()) {
                        obj.Move();
                    }
                    foreach (var obj in ammunitionObjects.ToList()) {
                        obj.Move();
                    }

                    // // all objects
                    // foreach (var obj in allObjects) {
                    //     obj.Move();
                    // }
                }
                MoveObjects();

                void removeAmmunition(){
                    foreach (var obj in ammunitionObjects.ToList()){
                        if (obj.Position == buildingPosition){
                            ammunitionObjects.Remove(obj);
                        }
                    }
                }


                // Remove objects if they pass beyond a certain y-value
                void removeObjects(){
                    foreach (var obj in alienObjects.ToList()){
                        if (obj.Position.Y >= 620) {
                            alienObjects.Remove(obj);
                        }
                    }
                    foreach (var laser in ammunitionObjects.ToList()){
                        if (laser.Position.Y <= 100){
                            ammunitionObjects.Remove(laser);
                        }
                    }
                        // if (obj.Position.Y <= -50) {
                        //     ammunitionObjects.Remove(obj);
                        // }

                    // foreach (var obj in allObjects.ToList()) {
                    //     if (obj.Position.Y >= 620) {
                    //         allObjects.Remove(obj);
                    //     }
                    //     if (obj.Position.Y <= -300) {
                    //         // allObjects.Remove(obj);
                    //         if (obj.isAmmunition == true){
                    //             allObjects.Remove(obj);
                    //         }
                    //     }
                    // }
                }
                removeObjects();
                // foreach (var laser in ammunitionObjects.ToList()){
                //     if (laser.Position.Y <= 400 && (laser.Position.X == buildingPosition.X)){
                //         ammunitionObjects.Remove(laser);
                //     }
                // }

                // if (ammunitionPosition == buildingPosition){
                //     foreach (var bullet in ammunitionObjects.ToList()){
                //         ammunitionObjects.Remove(bullet);
                //     }
                // }

                


                // handle collisions
       

                // combine all lists of objects into a list
                // var allObjects = new List<List<List<Actor>>>();


                // var allAliensList = new List<List<Actor>>();
                // // add alien objects
                // allAliensList.Add(rowOneObjects);
                // allAliensList.Add(rowTwoObjects);
                // allAliensList.Add(rowThreeObjects);
                // allAliensList.Add(rowFourObjects);

                // if (Raylib.CheckCollisionRecs(ammunitionRectangle, buildingRectangle)){
                //     foreach (var obj in ammunitionObjects){
                //         allObjects.Remove(obj);
                //         ammunitionObjects.Remove(obj);
                //     }
                // }
                
// ****************************Best Collision Handler I Got So Far--Still Doesn't Work Though******************************
                // foreach (var obj in allObjects.ToList()){
                //     var ammoRectangle = new Rectangle();
                //     var buildyRectangle = new Rectangle();
                //     var alienyRectangle = new Rectangle();

                //     bool startCheckingCollisions = false;

                //     if (obj.isAmmunition){
                //         ammoRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 10, 25);
                //         startCheckingCollisions = true;
                //     }
                //     if (obj.isBuilding){
                //         buildyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 63, 63);
                //         startCheckingCollisions = true;
                //     }
                //     if (obj.isAlien){
                //         alienyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 50, 50);
                //         startCheckingCollisions = true;
                //     }

                //     if (startCheckingCollisions == true){
                //         if (Raylib.CheckCollisionRecs(ammoRectangle, buildyRectangle)){
                //         ammunitionObjects.Remove(obj);
                //         }
                //         if (Raylib.CheckCollisionRecs(ammoRectangle, alienyRectangle)){
                //         ammunitionObjects.Remove(obj);
                //         alienObjects.Remove(obj);
                //         }
                //     }
                // }
//*****************************************************************************************************************
/*
best bet: create a function that takes the x & y coordinates of one object, then compare if that's equal to the x & y coordinates of the other object. If they're equal, then do whatever the collision is supposed to do. (Side note: may need to implement the area of each position in order to cover the whole object)

*/
                removeAmmunition();

                // bool compareCoordinates(float firstX, float firstY, float secondX, float secondY){
                //     bool result = false;
                //     if (firstX == secondX & firstY == secondY){
                //         result = true;
                //     }
                //     return result;
                // }
                // bool compareCoordinates(Vector2 firstObject, Vector2 secondObject){
                //     bool result = false;
                //     if (firstObject == secondObject){
                //         result = true;
                //     }
                //     return result;
                // }
                // if (compareCoordinates(ammunitionPosition, buildingPosition)){
                //     foreach (var bullet in ammunitionObjects.ToList()){
                //         ammunitionObjects.Remove(bullet);
                //     }
                // }
                // else {
                // }


                if (Raylib.CheckCollisionRecs(ammunitionRectangle, buildingRectangle)){
                    foreach (var obj in ammunitionObjects.ToList()){
                        ammunitionObjects.Remove(obj);
                    }
                }





                // funtion compares 2 objects' x & y coordinates, returns true if they're the same
                // now: pass the stuff into it
                // if (compareCoordinates((ammunitionPosition.X + 10), (ammunitionPosition.Y + 25), (buildingPosition.X + 63), (buildingPosition.Y + 63))){
                //     foreach (var bullet in ammunitionObjects.ToList()){
                //         ammunitionObjects.Remove(bullet);
                //     }
                //     // foreach (var building in buildingObjects)
                // };

                // foreach (var obj in allObjects.ToList()){
                //     // var ammoRectangle = new Rectangle();
                //     // var buildyRectangle = new Rectangle();
                //     // var alienyRectangle = new Rectangle();

                //     // bool startCheckingCollisions = false;

                //     // if ammunition or building (both objects marked "true" for isAmmunition)
                //     if (obj.isAmmunition){
                //         // create ammo rectangle
                //         var ammoRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 10, 25);
                //         // if building (only building marked "true" for this)
                //         if (obj.isBuilding){
                //             // create building rectangle
                //             var buildyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 63, 63);
                //             // check collisions between ammo & buildings
                //             if (Raylib.CheckCollisionRecs(ammoRectangle, buildyRectangle)){
                //                 // remove ammo
                //                 ammunitionObjects.Remove(obj);
                //             }
                //             // if (obj.isAlien){
                //             //     var alienyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 50, 50);
                //             //     if (Raylib.CheckCollisionRecs(ammoRectangle, alienyRectangle)){
                //             //         ammunitionObjects.Remove(obj);
                //             //         alienObjects.Remove(obj);
                //             //     }
                //             // }  
                //         }
                //         // startCheckingCollisions = true;
                //     }
                //     // if (obj.isBuilding){
                //     //     buildyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 63, 63);
                //     //     startCheckingCollisions = true;
                //     // }
                //     // if (obj.isAlien){
                //     //     alienyRectangle = new Rectangle(obj.Position.X, obj.Position.Y, 50, 50);
                //     //     startCheckingCollisions = true;
                //     // }

                //     // if (startCheckingCollisions == true){
                //     //     if (Raylib.CheckCollisionRecs(ammoRectangle, buildyRectangle)){
                //     //     ammunitionObjects.Remove(obj);
                //     //     }
                //     //     if (Raylib.CheckCollisionRecs(ammoRectangle, alienyRectangle)){
                //     //     ammunitionObjects.Remove(obj);
                //     //     alienObjects.Remove(obj);
                //     //     }
                //     // }
                // }
                    
                    

                //     if (obj.isAmmunition){
                //         if (Raylib.CheckCollisionRecs(rectangle, ammunitionRectangleTrying)){
                //             // allObjects.Remove(obj);
                //         }
                //     }
                //     if (Raylib.CheckCollisionRecs(rectangle, rectangle)){
                //         if (obj.isAmmunition){
                //             // allObjects.Remove(obj);
                //         }
                        
                        
                //     }              
                // }


                // foreach (var obj in allObjects.ToList()){
                //     if (Raylib.CheckCollisionRecs(ammunitionRectangle, buildingRectangle)){
                //         allObjects.Remove(obj);
                //     }
                


                // if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowOneAlienRectangle)){
                //     ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                // }
                // if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowTwoAlienRectangle)){
                //     ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                // }
                // if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowThreeAlienRectangle)){
                //     ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                // }
                // if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowFourAlienRectangle)){
                //     ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                // }

                // void ammoAndAlienCollisions(List<Actor> ammunitionObjects, List<Actor> alienObjects, List<Actor>allObjects){
                //     foreach (var obj in ammunitionObjects){
                //         allObjects.Remove(obj);
                //         ammunitionObjects.Remove(obj);
                //     }
                //     foreach (var obj in alienObjects){
                //         allObjects.Remove(obj);
                //         alienObjects.Remove(obj);
                //     }
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