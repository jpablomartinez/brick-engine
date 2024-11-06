using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

public class GraphicsManager : GameWindow
{
    public GraphicsManager(int width, int height, string title)
        : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title })
    {
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(0.1f, 0.2f, 0.3f, 1.0f); // Set background color
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the screen
        
        // Add rendering code here (e.g., draw sprites, shapes, etc.)

        Context.SwapBuffers(); // Display the frame
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        // Cleanup resources here
    }
}
