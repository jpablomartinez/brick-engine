using System;

namespace BrickEngine{

    class Program{
        static void Main(string[] args){
            using(var game = new GraphicsManager(800,600,"BrickEngine")){
                game.Run();
            }
        }
    }

}