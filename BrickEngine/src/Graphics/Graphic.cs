using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;

public class GraphicsManager : GameWindow
{

    public int Width { get; set; }
    public int Height { get; set; }
    public Color BackgroundColor { get; set; }

    public GraphicsManager(int width, int height, Color color, NativeWindowSettings ns)
        : base(GameWindowSettings.Default, ns)
    {
        Width = width;
        Height = height;
        BackgroundColor = color;
        this.CenterWindow(new Vector2i(width, height));
    }

    /// <summary>
    /// Call every time the screen is resize
    /// </summary>
    /// <param name="e"></param>
    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, e.Width, e.Height);
        Width = e.Width;
        Height = e.Height;
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(BackgroundColor.Red, BackgroundColor.Green, BackgroundColor.Blue, BackgroundColor.Alpha);
    }

    /// <summary>
    /// Call every single frame. Is different from the update
    /// </summary>
    /// <param name="e"></param>
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the screen        
        // Add rendering code here (e.g., draw sprites, shapes, etc.)
        Context.SwapBuffers(); // Display the frame, change between actual window for new window
    }

    /// <summary>
    /// update rendering. Is different from the renderer
    /// </summary>
    /// <param name="args"></param>
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }

    protected override void OnUnload()
    {
        base.OnUnload();
        // Cleanup resources here
    }
}
