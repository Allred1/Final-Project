using System.Collections.Generic;
using Raylib_cs;
using FinalProject.Game.Casting;


namespace FinalProject.Game.Services
{
    // Detect Player Input
    public class KeyboardService{
        private Dictionary<string, KeyboardKey> keys = new Dictionary<string, KeyboardKey>();

        // New Instance of KeyboardService
        public KeyboardService(){
            keys["left"] = KeyboardKey.KEY_LEFT;
            keys["right"] = KeyboardKey.KEY_RIGHT;
            keys["space"] = KeyboardKey.KEY_SPACE;
        }

        // Checks if the given key is down
        public bool IsKeyDown(string key){
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyDown(raylibKey);
        }

        // Checks if the given key is up
        public bool IsKeyUp(string key){
            KeyboardKey raylibKey = keys[key.ToLower()];
            return Raylib.IsKeyUp(raylibKey);
        }
    }
}