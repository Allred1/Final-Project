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

            var Objects = new List<Actor>();
            int alienCounter = 0;
            int objectXPosition = 30;
            var artilleryPosition = new Vector2(Constants.SCREEN_WIDTH / 2, Constants.SCREEN_HEIGHT - 45);


            videoService.OpenWindow();

            // while the window is open, do stuff
            while(videoService.IsWindowOpen()){

                // aliens start at top of screen
                var startAtTop = Constants.SCREEN_HEIGHT - Constants.SCREEN_HEIGHT - 30;
                
                var objectPosition = new Vector2(objectXPosition, startAtTop);
                


                // first row
                // create the aliens
                if (alienCounter < 12){
                    var alien = new Aliens(Color.PURPLE, 100);
                    alien.Position = objectPosition;
                    objectXPosition += 85;
                    alien.Velocity = new Vector2(0,0.3f);
                    Objects.Add(alien);
                    alienCounter += 1;
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

                

                // draw the objects
                foreach (var obj in Objects.ToList()) {
                    obj.Draw();
                }

                // end drawing
                videoService.FlushBuffer();

                // move positions of the objects
                foreach (var obj in Objects) {
                    obj.Move();
                }


                // Remove objects if they pass beyond a certain y-value
                foreach (var obj in Objects.ToList()){
                    if (obj.Position.Y >= 620) {
                        Objects.Remove(obj);
                    }
                }

  


                Raylib.DrawText("A", (int)artilleryPosition.X, (int)artilleryPosition.Y, 40, Color.GOLD);
                
        

            }
            // unload textures
            // videoService.UnloadImages();
            videoService.CloseWindow();
        }
    }
}