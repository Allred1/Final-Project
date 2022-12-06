using Raylib_cs;


namespace FinalProject.Game
{

    public class Constants {

        // GENERAL GAME CONSTANTS

        // Game
        public static string GAME_NAME = "Space Invaders";
        public static int FRAME_RATE = 60;
        public static int CELL_SIZE = 15;

        
        // Screen
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;


        // Field
        public static int FIELD_TOP = 60;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // Font
        public static string FONT_FILE = "";
        public static int FONT_SMALL = 32;
        public static int FONT_LARGE = 48;


        // Sound
        public static string ARTILLERY_SOUND = "";
        public static string MUSIC_SOUND = "";
        public static string WELCOME_SOUND = "";
        public static string OVER_SOUND = "";


        // Text
        public static int ALIGN_CENTER = 0;
        public static int ALIGN_LEFT = 1;
        public static int ALIGN_RIGHT = 2;


        // Colors
        public static Color BLACK = Color.BLACK;
        public static Color WHITE = Color.WHITE;

        // Keys
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // Scenes
        public static int NEW_GAME = 0;
        public static int TRY_AGAIN = 1;
        public static int NEXT_LEVEL = 2;
        public static int IN_PLAY = 3;
        public static int GAME_OVER = 4;

        // Levels
        public static string LEVEL_FILE = "";
        public static int BASE_LEVELS = 5;



        // SCRIPTING CONSTANTS

        // Phases
        public static int INITIALIZE = 0;
        public static int LOAD = 1;
        public static int INPUT = 2;
        public static int UPDATE = 3;
        public static int OUTPUT = 4;
        public static int UNLOAD = 5; 
        public static int RELEASE = 6;



        // CASTING CONSTANTS

        // Stats
        public static string STATS_GROUP = "";
        public static int DEFAULT_LIVES = 3;
        public static int MAXIMUM_LIVES = 5;
        public static int SCORE = 0;

        // HUD


        // Ammunition
        public static string AMMUNITION_GROUP = "";
        public static string AMMUNITION_IMAGE = "final-project/assets/images/";
        public static int AMMUNITION_WIDTH = 28;
        public static int AMMUNITION_HEIGHT = 28;
        public static int AMMUNITION_VELOCITY = 8;

        // Artillery
        public static string ARTILLERY_GROUP = "";
        public static string ARTILLERY_IMAGE = "final-project/assets/images/artillery2.png";
        public static int ARTILLERY_WIDTH = 10;
        public static int ARTILLERY_HEIGHT = 10;
        public static int ARTILLERY_RATE = 6;
        public static int ARTILLERY_VELOCITY = 7;

        // Building
        public static string BUILDING_GROUP = "";
        public static string BUILDING_IMAGE = "";
        public static int BUILDING_WIDTH = 10;
        public static int BUILDING_HEIGHT= 10;
        public static int BUILDING_VELOCITY = 0;


        // Aliens
        public static string ALIEN_GROUP = "";
        public static string ALIEN_IMAGE = "final-project/assets/images/alien2.png";
        public static int ALIEN_WIDTH = 30;
        public static int ALIEN_HEIGHT = 30;
        public static float ALIEN_DELAY = 0.5F;
        public static int ALIEN_RATE = 4;
        public static int ALIEN_POINTS = 1;


        // Flying Saucer
        public static string FLYING_SAUCER_GROUP = "";
        public static string FLYING_SAUCER_IMAGE = "final-project/assets/images/flyingSaucer.png";
        public static int FLYING_SAUCER_WIDTH = 20;
        public static int FLYING_SAUCER_HEIGHT = 20;
        public static float FLYING_SAUCER_DELAY = 0.5F;
        public static int FLYING_SAUCER_RATE = 4;
        public static int FLYING_SAUCER_POINTS = 2;

        // Background
        public static string BACKGROUND_GROUP = "";
        public static string BACKGROUND_IMAGE = "final-project/assets/images/spaceBackground2.png";


        // Dialog
        public static string DIALOG_GROUP = "dialog";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string GAME_ENDING = "GAME OVER";
    }
}