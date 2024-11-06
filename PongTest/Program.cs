using System;

namespace BrickEngine{

    class Program{
        static void Main(string[] args){
            using(var game = new GraphicsManager(800,600,"Brick Engine - Pong Game")){
                game.Run();
            }
        }
    }

}