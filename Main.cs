using FinalProject.Game.Casting;
using FinalProject.Game.Directing;
using FinalProject.Game.Services;
using FinalProject.Game;
using System.Numerics;



class spaceInvaders {

    static void Main(string[] args){


        VideoService videoService = new VideoService(false);

        Director director = new Director(videoService);
        director.StartGame();
    }
}