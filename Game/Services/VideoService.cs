using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using FinalProject.Game.Casting;
using System.Numerics;



namespace FinalProject.Game.Services
{
    public class VideoService{
        Texture2D background = Raylib.LoadTexture(Constants.BACKGROUND_IMAGE);

        
        
        private bool debug = false;

        public void createObjectList(){
            var Objects = new List<Actor>();


            var Artillery = new Artillery(Color.GOLD, 40);
            Artillery.Position = new Vector2(Constants.SCREEN_WIDTH / 2, Constants.SCREEN_HEIGHT - 45);

            Objects.Add(Artillery);

            foreach (var obj in Objects.ToList()){
                obj.Draw();
            }

            foreach (var obj in Objects) {
                obj.Move();
            }
        }

        // Constructs new instance of VideoService
        public VideoService(bool debug){
            this.debug = debug;
        }

        // Closes the window
        public void CloseWindow(){
            Raylib.CloseWindow();
        }


        // Clear buffer to prepare for next rendering
        public void ClearBuffer() {
            // Init 
            // Texture2D background = Raylib.LoadTexture(Constants.BACKGROUND_IMAGE);
            // Texture2D sprite = LoadTexture(Constants.ALIEN_IMAGE);

            Raylib.BeginDrawing();
            // find a way to insert "BACKGROUND_IMAGE" as a background png for the program
            Raylib.ClearBackground(Color.BLACK);


            // Draw 
            // Raylib.DrawTexture(background, 0, 0, Color.WHITE);
            // DrawTexture(sprite, 0, 0, WHITE);


            // var image = Raylib.LoadImage(Constants.BACKGROUND_IMAGE);
            // this.texture = Raylib.LoadTextureFromImage(image);
            // Raylib.UnloadImage(image);

            if (debug) {
                DrawGrid();
            }
        }


        // Copies buffer contnets to the screen. 
        public void FlushBuffer(){
            Raylib.EndDrawing();
        }

        public void UnloadImages(){
            Raylib.UnloadTexture(background);
        }

 

        // Whether or not the window is still open
        public bool IsWindowOpen(){
            return !Raylib.WindowShouldClose();
        }


        // Opens new window with the given title
        public void OpenWindow(){
            Raylib.InitWindow(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT, Constants.GAME_NAME);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        private void DrawGrid(){
            for (int x = 0; x < Constants.SCREEN_WIDTH; x += Constants.CELL_SIZE){
                Raylib.DrawLine(x, 0, x, Constants.SCREEN_HEIGHT, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.SCREEN_HEIGHT; y += Constants.CELL_SIZE){
                Raylib.DrawLine(0, y, Constants.SCREEN_WIDTH, y, Raylib_cs.Color.GRAY);
            }
        }


    }
}