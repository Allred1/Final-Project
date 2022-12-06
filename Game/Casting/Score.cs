using System;


namespace FinalProject.Game.Casting
{
    public class Score: Actor{
        private int points = 0;

        public Score(){
            AddPoints(0);
        }

        // Adds points to score
        public void AddPoints(int points){
            this.points += points;
            Constants.SCORE = this.points;
        }
    }
}