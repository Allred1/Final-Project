using Raylib_cs;


namespace FinalProject.Game.Casting
{
    
    // Create Alien object
    class Aliens: coloredObject {

        public int Size { get; set; }
        public Aliens(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(constants.ALIEN_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Artillery Object
    class Artillery: coloredObject {        
        public int Size { get; set; }
        public Artillery(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(constants.ARTILLERY_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Ammunition Object
    class Ammunition: coloredObject {
        public int Size { get; set; }
        public Ammunition(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(constants.AMMUNITION_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Building object
    class Building: coloredObject {
        public int Size { get; set; }
        public Building(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(constants.BUILDING_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }


    // Create Flying Saucer object
    class flyingSaucer: coloredObject {
        public int Size { get; set; }
        public flyingSaucer(Color color, int size): base(color){
            Size = size;
        }
        override public void Draw(){
            Raylib.DrawText(constants.FLYING_SAUCER_IMAGE, (int)Position.X, (int)Position.Y, Size, Color);
        }
    }
}
