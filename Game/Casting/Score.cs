using System;
using Raylib_cs;


namespace FinalProject.Game.Casting
{
    public class Score: ColoredObject {
        private int points = 0;
        public int Size { get; set; }

        public Score(Color color, int size): base(color){
            Size = size;
            AddPoints(0);
        }
        override public void Draw(){
            Raylib.DrawText(Constants.SCORE_TEXT, (int)Position.X, (int)Position.Y, Size, Color);
        }

        // Adds points to score
        public void AddPoints(int points){
            this.points += points;
            Constants.SCORE = this.points;
        }
    }
}