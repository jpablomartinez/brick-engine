using System;

namespace BrickEngine{

    class Program{
        static void Main(string[] args){

            //Color backgroundColor = Color.FromHexColor(0x020919);                        

            using(var game = new GraphicsManager(800,600,"Brick Engine - Pong Game", Color.BrickColor)){
                game.Run();
            }
        }
    }

}