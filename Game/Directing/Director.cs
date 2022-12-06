using System.Collections.Generic;
using FinalProject.Game.Casting;
// using FinalProject.Game.Scripting;
using FinalProject.Game.Services;
using Raylib_cs;

namespace FinalProject.Game.Directing
{
    public class Director{
        private VideoService videoService;

        public Director(VideoService videoService){
            this.videoService = videoService;
        }
        
        public void StartGame(){
            videoService.OpenWindow();
            while(videoService.IsWindowOpen()){
                // videoService.DrawGrid();
                videoService.ClearBuffer();
                videoService.FlushBuffer();

                Raylib.DrawText(Constants.SCORE_TEXT, (int)Constants.SCORE_POSITION_X, (int)Constants.SCORE_POSITION_Y, Constants.SCORE_SIZE, Constants.SCORE_COLOR);
                


        //  override public void Draw(){
        //     Raylib.DrawText(Constants.SCORE_TEXT, (int)Position.X, (int)Position.Y, Size, Color);
        // }
            }
            videoService.CloseWindow();
        }


    }

 

}