using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using FinalProject.Game.Casting;



namespace FinalProject.Game.Services
{
    public class VideoService{
        private bool debug = false;

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
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            // Image LoadImage(Constants.BACKGROUND_IMAGE);
            Image GenImageColor(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            if (debug) {
                DrawGrid();
            }
        }


        // Copies buffer contnets to the screen. 
        public void FlushBuffer(){
            Raylib.EndDrawing();
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