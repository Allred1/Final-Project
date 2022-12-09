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

                var rowOneAlienRectangle = new Rectangle(rowOnePosition.X, rowOnePosition.Y, 50, 50);
                var rowTwoAlienRectangle = new Rectangle(rowTwoPosition.X, rowTwoPosition.Y, 50, 50);
                var rowThreeAlienRectangle = new Rectangle(rowThreePosition.X, rowThreePosition.Y, 50, 50);
                var rowFourAlienRectangle = new Rectangle(rowFourPosition.X, rowFourPosition.Y, 50, 50);


                var ammunitionRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);


            

                // create the aliens
                // first row              
                if (rowOneCounter < 12){
                    var alien = new Aliens(Color.PURPLE, 100, new Rectangle());
                    alien.Position = rowOnePosition;
                    alien.Rectangle = rowOneAlienRectangle;
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
                    var alien = new Aliens(Color.BLUE, 100, new Rectangle());
                    alien.Position = rowTwoPosition;
                    alien.Rectangle = rowTwoAlienRectangle;
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
                    var alien = new Aliens(Color.ORANGE, 100, new Rectangle());
                    alien.Position = rowThreePosition;
                    alien.Rectangle = rowThreeAlienRectangle;
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
                    var alien = new Aliens(Color.WHITE, 100, new Rectangle());
                    alien.Position = rowFourPosition;
                    alien.Rectangle = rowFourAlienRectangle;
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
                    var building = new Building(Color.DARKGRAY, 90, new Rectangle(buildingPosition.X, buildingPosition.Y, 30, 30));
                    building.Position = buildingPosition;
                    building.Rectangle = buildingRectangle;
                    buildingPosition.X += 200;
                    building.Velocity = new Vector2(0,0);
                    // identify what it is and isn't
                    building.isBuilding = true;
                    building.isAlien = false;
                    building.isAmmunition = false;
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
                    // ammunition.newRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                    // var ammunitionNewRectangle = new Rectangle(())
                    // var ammunitionRectangle = new Rectangle(artilleryPosition.X, ammunitionPosition.Y, 10, 25);
                    ammunition.Rectangle = ammunitionRectangle;
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
                            if (obj.isAmmunition == true){
                                allObjects.Remove(obj);
                            }
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

                if (Raylib.CheckCollisionRecs(ammunitionRectangle, buildingRectangle)){
                    foreach (var obj in ammunitionObjects){
                        allObjects.Remove(obj);
                        ammunitionObjects.Remove(obj);
                    }
                }
                if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowOneAlienRectangle)){
                    ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                }
                if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowTwoAlienRectangle)){
                    ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                }
                if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowThreeAlienRectangle)){
                    ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                }
                if (Raylib.CheckCollisionRecs(ammunitionRectangle, rowFourAlienRectangle)){
                    ammoAndAlienCollisions(ammunitionObjects, alienObjects, allObjects);
                }

                void ammoAndAlienCollisions(List<Actor> ammunitionObjects, List<Actor> alienObjects, List<Actor>allObjects){
                    foreach (var obj in ammunitionObjects){
                        allObjects.Remove(obj);
                        ammunitionObjects.Remove(obj);
                    }
                    foreach (var obj in alienObjects){
                        allObjects.Remove(obj);
                        alienObjects.Remove(obj);
                    }
                }              


                
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