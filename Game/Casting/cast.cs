using Raylib_cs;
using System.Numerics;


namespace FinalProject.Game.Casting
{

    // Create Alien object
    class Aliens: ColoredObject {
        Texture2D texture;
        public int Size { get; set; }
        // public Rectangle Rectangle { get; set; }
        public Aliens(Color color, int size): base(color){
            Size = size;
            // Rectangle = rectangle;
            // var image = Raylib.LoadImage(Constants.ALIEN_IMAGE);
            // this.texture = Raylib.LoadTextureFromImage(image);
            // Raylib.UnloadImage(image);
        }
        
        override public void Draw(){
            // Raylib.DrawText(Constants.ALIEN_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
            // Raylib.DrawRectangle((int)Position.X, (int)Position.Y + 20, 50, 50, Color.BROWN);
            Raylib.DrawText("*", (int)Position.X, (int)Position.Y, Size, Color);
            
        }
    }


    // Create Artillery Object
    class Artillery: ColoredObject { 
        Texture2D texture;       
        public int Size { get; set; }
        // public Rectangle Rectangle { get; set; }
        public Artillery(Color color, int size): base(color){
            Size = size;
            // Rectangle = rectangle;
            // var image = Raylib.LoadImage(Constants.ARTILLERY_IMAGE);
            // this.texture = Raylib.LoadTextureFromImage(image);
            // Raylib.UnloadImage(image);
        }

        // override public void Move(){
        // }

        override public void Draw(){
            // Raylib.DrawText(Constants.ARTILLERY_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
            // Raylib.DrawTexture(this.texture, (int)Position.X, (int)Position.Y, Color);
            Raylib.DrawText("A", (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Ammunition Object
    class Ammunition: ColoredObject {
        public int Size { get; set; }
        // public Rectangle Rectangle { get; set; }
        public Ammunition(Color color, int size): base(color){
            Size = size;
            // Rectangle = rectangle;
        }
        
        override public void Draw(){
            // Raylib.DrawText(Constants.AMMUNITION_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
            // Raylib.DrawRectangle((int)Position.X + 1, (int)Position.Y + 2, 5, 20, Color.PURPLE);
            Raylib.DrawText("I", (int)Position.X, (int)Position.Y, Size, Color);
            
        }
    }


    // Create Building object
    class Building: ColoredObject {
        public int Size { get; set; }
        // public Rectangle Rectangle { get; set; }
        public Building(Color color, int size): base(color){
            Size = size;
            // Rectangle = rectangle;
        }
        
        override public void Draw(){
            // Raylib.DrawText(Constants.BUILDING_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
            // Raylib.DrawRectangle((int)Position.X, (int)Position.Y + 9, 63, 63, Color.GREEN);

            Raylib.DrawText("M", (int)Position.X, (int)Position.Y, Size, Color);
            Raylib.DrawText("/", (int)Position.X, (int)Position.Y, Size, Color);
            Raylib.DrawText("\\", (int)Position.X, (int)Position.Y, Size, Color);
            Raylib.DrawText("T", (int)Position.X, (int)Position.Y, Size, Color);
            
        }
    }


    // Create Flying Saucer object
    class flyingSaucer: ColoredObject {
        Texture2D texture;
        public int Size { get; set; }
        // public Rectangle Rectangle { get; set; }
        public flyingSaucer(Color color, int size): base(color){
            Size = size;
            // Rectangle = rectangle;
            // var image = Raylib.LoadImage(Constants.FLYING_SAUCER_IMAGE);
            // this.texture = Raylib.LoadTextureFromImage(image);
            // Raylib.UnloadImage(image);
        }
        override public void Draw(){
            // Raylib.DrawText(Constants.FLYING_SAUCER_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }
}
