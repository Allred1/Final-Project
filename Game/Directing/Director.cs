using System.Collections.Generic;
using FinalProject.Game.Casting;
// using FinalProject.Game.Scripting;
using FinalProject.Game.Services;
using Raylib_cs;
using System.Numerics;
using System.Threading;


namespace FinalProject.Game.Directing
{
    public class Director{
        private VideoService videoService;

        public Director(VideoService videoService){
            this.videoService = videoService;
        }
        
        public void StartGame(){

            // Configure rows of Aliens
            var rowOneObjects = new List<Actor>();
            var rowTwoObjects = new List<Actor>();
            var rowThreeObjects = new List<Actor>();
            var rowFourObjects = new List<Actor>();
            int rowOneCounter = 0;
            int rowTwoCounter = 0;
            int rowThreeCounter = 0;
            int rowFourCounter = 0;
            int rowOneXPosition = 30;
            int rowTwoXPosition = 30;
            int rowThreeXPosition = 30;
            int rowFourXPosition = 30;

            bool fired = false;

            
            // configure Player's position
            var artilleryPosition = new Vector2(Constants.SCREEN_WIDTH / 2, Constants.SCREEN_HEIGHT - 45);
            // configure ammunition's position
            // var ammunititionPosition = new Vector2(Constants.SCREEN_WIDTH / 2, Constants.SCREEN_HEIGHT - 45);
            // var ammunitionPosition = artilleryPosition;
            
            var ammunitionPosition = artilleryPosition;

            // var ammunitionPosition = new Vector2(artilleryPosition.X, (artilleryPosition.Y += 2));
            
            

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

                

                // create another list for every row of aliens
                // then draw each list after a delay so they'll come one after another


                // create the aliens
                // first row              
                if (rowOneCounter < 12){
                    var alien = new Aliens(Color.PURPLE, 100, new Rectangle());
                    alien.Position = rowOnePosition;
                    // this increments each alien drawn on that one row
                    rowOneXPosition += 85;

                    alien.Velocity = new Vector2(0,0.2f);
                    rowOneObjects.Add(alien);
                    rowOneCounter += 1;
                }
                // second row
                if (rowTwoCounter < 12){
                    var alien = new Aliens(Color.BLUE, 100, new Rectangle());
                    alien.Position = rowTwoPosition;
                    rowTwoXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    rowTwoObjects.Add(alien);
                    rowTwoCounter += 1;
                }
                // third row
                if (rowThreeCounter < 12){
                    var alien = new Aliens(Color.ORANGE, 100, new Rectangle());
                    alien.Position = rowThreePosition;
                    rowThreeXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    rowThreeObjects.Add(alien);
                    rowThreeCounter += 1;
                }
                // fourth row
                if (rowFourCounter < 12){
                    var alien = new Aliens(Color.WHITE, 100, new Rectangle());
                    alien.Position = rowFourPosition;
                    rowFourXPosition += 85;
                    alien.Velocity = new Vector2(0,0.2f);
                    rowFourObjects.Add(alien);
                    rowFourCounter += 1;
                }

                





                // begin drawing
                videoService.ClearBuffer();

                // draw the Score
                Raylib.DrawText(Constants.SCORE_TEXT, (int)Constants.SCORE_POSITION_X, (int)Constants.SCORE_POSITION_Y, Constants.SCORE_SIZE, Constants.SCORE_COLOR);

                
                // check for the user's artillery movement
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)){
                    artilleryPosition.X += Constants.ARTILLERY_VELOCITY;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)){
                    artilleryPosition.X -= Constants.ARTILLERY_VELOCITY;
                }

                void Missile(){
                    var ammunition = new Ammunition(Color.RED, 25, new Rectangle());
                    ammunition.Position = new Vector2(artilleryPosition.X, ammunitionPosition.Y);
                    rowOneObjects.Add(ammunition);
                }

                // check for ammunition movement (if the player shoots a laserbeam)
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE)){
                    Missile();
                    fired = true;
                    // ammunitionPosition.Y -= Constants.AMMUNITION_VELOCITY;
                }
                if (Raylib.IsKeyReleased(KeyboardKey.KEY_SPACE)){
                    fired = false;
                }

                
                    // ammunitionPosition.Y -= Constants.AMMUNITION_VELOCITY;
                    // Raylib.DrawText("I", (int)ammunitionPosition.X, (int)ammunitionPosition.Y, 20, Color.RED);
                    // var ammunition = new Ammunition(Color.RED, 30, new Rectangle());
                    // ammunitionPosition.Y -= 2;
                    // ammunitionPosition.Y -= Constants.AMMUNITION_VELOCITY;
                    // ammunitionPosition.Y -= 2;
                    // ammunition.Velocity = new Vector2(0,Constants.AMMUNITION_VELOCITY);
                    // rowOneObjects.Add(ammunition);
                    // ammunition.Position.Y += 2;
                    // Raylib.DrawText("I", (int)ammunitionPosition.X, (int)ammunitionPosition.Y, 20, Color.RED);
                
                

                
                // Draw the objects
                void DrawObjects(){
                    // draw the objects
                    foreach (var obj in rowOneObjects.ToList()) {
                        obj.Draw();
                    }
                    foreach (var obj in rowTwoObjects.ToList()) {
                        obj.Draw();
                    }
                    foreach (var obj in rowThreeObjects.ToList()) {
                        obj.Draw();
                    }
                    foreach (var obj in rowFourObjects.ToList()) {
                        obj.Draw();
                    }
                }
                DrawObjects();


                // end drawing
                videoService.FlushBuffer();


                // Move the objects
                void MoveObjects(){
                    // move positions of the objects
                    foreach (var obj in rowOneObjects) {
                        obj.Move();
                    }
                    // Thread.Sleep(300);
                    foreach (var obj in rowTwoObjects) {
                        obj.Move();
                    }
                    foreach (var obj in rowThreeObjects) {
                        obj.Move();
                    }
                    foreach (var obj in rowFourObjects) {
                        obj.Move();
                    }
                }
                MoveObjects();



                // Remove objects if they pass beyond a certain y-value
                void removeObjects(){
                    foreach (var obj in rowOneObjects.ToList()){
                        if (obj.Position.Y >= 620) {
                            rowOneObjects.Remove(obj);
                        }
                    }
                    foreach (var obj in rowTwoObjects.ToList()){
                        if (obj.Position.Y >= 620) {
                            rowTwoObjects.Remove(obj);
                        }
                    }
                    foreach (var obj in rowThreeObjects.ToList()){
                        if (obj.Position.Y >= 620) {
                            rowThreeObjects.Remove(obj);
                        }
                    }
                    foreach (var obj in rowFourObjects.ToList()){
                        if (obj.Position.Y >= 620) {
                            rowFourObjects.Remove(obj);
                        }
                    }
                }
                removeObjects();
                
  

                // Draw artillery (player)
                Raylib.DrawText("A", (int)artilleryPosition.X, (int)artilleryPosition.Y, 40, Color.GOLD);  
                // Raylib.DrawText("I", (int)ammunitionPosition.X, (int)ammunitionPosition.Y, 20, Color.RED);


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

Need: 
- ammunition & spacebar activation
- buildings --their position, no velocity
- collisions (aliens against buildings, ammunition against aliens) (remove the aliens or building upon collisions)



*/