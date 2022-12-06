using Raylib_cs;
using System.Numerics;


// Actor Class

/*
Actors attributes:
- position
- velocity (except buildings)
- color
- 

*/
namespace FinalProject.Game.Casting
{

    class Actor {
        public Vector2 Position { get; set; } = new Vector2(0,0);
        public Vector2 Velocity { get; set; } = new Vector2(0,0);

        virtual public void Draw(){
        }

        // Movement
        public void Move() {
            Vector2 NewPosition = this.Position;
            NewPosition.X += Velocity.X;
            NewPosition.Y += Velocity.Y;
            Position = NewPosition;
        }
    }



    class coloredObject: Actor {
        public Color Color { get; set; }

        public coloredObject(Color color){

            Color getRandomColor(){
                // make a list of colors
                var colorsList = new List<Raylib_cs.Color>();
                // add raylib colors individually
                colorsList.Add(Color.RED);
                colorsList.Add(Color.MAGENTA);
                colorsList.Add(Color.YELLOW);
                colorsList.Add(Color.GREEN);
                colorsList.Add(Color.LIME);
                colorsList.Add(Color.SKYBLUE);
                colorsList.Add(Color.BLUE);
                colorsList.Add(Color.VIOLET);
                colorsList.Add(Color.WHITE);

                var random = new Random();
                var randomColorIndex = random.Next(colorsList.Count);
                var randomColor = colorsList[randomColorIndex];
                return randomColor;
            } 

            Color = getRandomColor();
        }
    }
    
}