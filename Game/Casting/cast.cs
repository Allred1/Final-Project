using Raylib_cs;


namespace FinalProject.Game.Casting
{
    
    // Create Alien object
    class Aliens: ColoredObject {

        public int Size { get; set; }
        public Aliens(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(Constants.ALIEN_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Artillery Object
    class Artillery: ColoredObject {        
        public int Size { get; set; }
        public Artillery(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(Constants.ARTILLERY_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Ammunition Object
    class Ammunition: ColoredObject {
        public int Size { get; set; }
        public Ammunition(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(Constants.AMMUNITION_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Building object
    class Building: ColoredObject {
        public int Size { get; set; }
        public Building(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(Constants.BUILDING_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Flying Saucer object
    class flyingSaucer: ColoredObject {
        public int Size { get; set; }
        public flyingSaucer(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(Constants.FLYING_SAUCER_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }
}
