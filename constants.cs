

public class constants {

    // GENERAL GAME CONSTANTS

    // Game
    public static string GAME_NAME = "Space Invaders";
    public static int FRAME_RATE = 60;

    
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
    public static Color BLACK = new Color(0,0,0);
    WHITE = Color(255,255,255);

    // Keys
    LEFT = "left";
    RIGHT = "right";
    SPACE = "space";
    ENTER = "enter";
    PAUSE = "p";

    // Scenes
    NEW_GAME = 0;
    TRY_AGAIN = 1;
    NEXT_LEVEL = 2;
    IN_PLAY = 3;
    GAME_OVER = 4;

    // Levels
    LEVEL_FILE = "";
    BASE_LEVELS = 5;



    // SCRIPTING CONSTANTS

    // Phases
    INITIALIZE = 0;
    LOAD = 1;
    INPUT = 2;
    UPDATE = 3;
    OUTPUT = 4;
    UNLOAD = 5; 
    RELEASE = 6;



    // CASTING CONSTANTS

    // Stats
    STATS_GROUP = "";
    DEFAULT_LIVES = 3;
    MAXIMUM_LIVES = 5;

    // HUD


    // Ammunition
    AMMUNITION_GROUP = "";
    AMMUNITION_IMAGE = "";
    AMMUNITION_WIDTH = 28;
    AMMUNITION_HEIGHT = 28;
    AMMUNITION_VELOCITY = 8;

    // Artillery
    ARTILLERY_GROUP = "";
    ARTILLERY_IMAGE = "";
    ARTILLERY_WIDTH = 10;
    ARTILLERY_HEIGHT = 10;
    ARTILLERY_RATE = 6;
    ARTILLERY_VELOCITY = 7;


    // Aliens
    ALIEN_GROUP = "";
    ALIEN_IMAGES = {};
    ALIEN_WIDTH = 30;
    ALIEN_HEIGHT = 30;
    ALIEN_DELAY = 0.5;
    ALIEN_RATE = 4;
    ALIEN_POINTS = ;


    // Dialog
    DIALOG_GROUP = "dialog";
    ENTER_TO_START = "PRESS ENTER TO START";
    GAME_ENDING = "GAME OVER";
}
