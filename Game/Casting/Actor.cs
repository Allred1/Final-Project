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

        // public Rectangle newRectangle { get; set; } = new Rectangle();

        public bool isBuilding;
        public bool isAmmunition;
        public bool isAlien;
    
        // add a rectangle (for collisions)
        // virtual public Rectangle Rect() {
        //     return new Rectangle(Position.X, Position.Y, 0, 0);
        // }
        public Rectangle Rectangle { get; set; } 
        // = new Rectangle(0,0,0,0);
        

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
        // public Rectangle Rectangle {get; set;}
        
        public ColoredObject(Color color){
            Color = color;
            // Rectangle = rectangle;
        }
        
    }
    
}