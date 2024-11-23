using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;

public class GraphicsManager : GameWindow
{
    public int Width { get; set; }
    public int Height { get; set; }

    public string WindowsTitle { get; set; }
    public Color BackgroundColor {get;set;}


    public GraphicsManager(int width, int height, string title, Color backgroundColor)
        : base(GameWindowSettings.Default, new NativeWindowSettings() { ClientSize = (width, height), Title = title })
    {
        Width = width;
        Height = height;
        WindowsTitle = title;
        BackgroundColor = backgroundColor;
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(BackgroundColor.Red, BackgroundColor.Green, BackgroundColor.Blue, BackgroundColor.Alpha);
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
