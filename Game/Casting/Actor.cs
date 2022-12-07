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

        // add a rectangle (for collisions)
        public Rectangle Rect() {
            return new Rectangle(Position.X, Position.Y, 20, 20);
        }

        virtual public void Draw(){
        }

        // Movement
        virtual public void Move() {
            Vector2 NewPosition = this.Position;
            NewPosition.X += Velocity.X;
            NewPosition.Y += Velocity.Y;
            Position = NewPosition;
        }
    }



    class ColoredObject: Actor {

        public Color Color { get; set; }

        public ColoredObject(Color color){
            Color = color;
        }
    }
    
}