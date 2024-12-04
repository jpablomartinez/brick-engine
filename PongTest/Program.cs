using System;
using OpenTK.Windowing.Desktop;

namespace BrickEngine
{

    class Program
    {
        static void Main(string[] args)
        {
            NativeWindowSettings ns = NativeWindowSettings.Default;
            ns.Title = "Brick Engine - Pong Game";
            GraphicsManager graphicsManager = new GraphicsManager(800, 600, Color.BrickColor, ns);
            graphicsManager.Run();
        }
    }

}