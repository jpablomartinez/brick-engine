using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.Common;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

public class GraphicsManager : GameWindow
{

    public int Width { get; set; }
    public int Height { get; set; }
    public Color BackgroundColor { get; set; }

    private int _vertexBufferHandler;

    private int shaderProgram;

    private int vertexArrayHandler;

    private int transformationLocation;
    private Matrix4 transformationMatrix = Matrix4.Identity;

    public GraphicsManager(int width, int height, Color color, NativeWindowSettings ns)
        : base(GameWindowSettings.Default, ns)
    {
        Width = width;
        Height = height;
        BackgroundColor = color;
        Console.WriteLine("{0} {1}", Width, Height);
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
        Console.WriteLine("{0} {1}", Width, Height);
    }

    protected override void OnLoad()
    {
        GL.ClearColor(BackgroundColor.Red, BackgroundColor.Green, BackgroundColor.Blue, BackgroundColor.Alpha);
        float[] vertices = {
            0.0f, 0.5f, 0.0f,
            0.5f, -0.5f,0.0f,
            -0.5f,-0.5f,0.0f
        };

        _vertexBufferHandler = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferHandler);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        vertexArrayHandler = GL.GenVertexArray();
        GL.BindVertexArray(vertexArrayHandler);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.BindVertexArray(0);

        string vertexShaderCode =
        @"
        #version 330 core

        layout (location = 0) in vec3 aPosition;
        uniform mat4 transformation;

            void main(){
                gl_Position = transformation * vec4(aPosition, 1.0);
            }
        ";

        string pixelShaderCode =
        @"
            #version 330 core
            out vec4 pixelColor;
            void main(){
                pixelColor = vec4(0.0,0.0,0.0,1.0);
            }
        ";

        int vertexShaderHandler = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderHandler, vertexShaderCode);
        GL.CompileShader(vertexShaderHandler);

        int pixelShaderHandler = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(pixelShaderHandler, pixelShaderCode);
        GL.CompileShader(pixelShaderHandler);

        shaderProgram = GL.CreateProgram();
        GL.AttachShader(shaderProgram, vertexShaderHandler);
        GL.AttachShader(shaderProgram, pixelShaderHandler);
        GL.LinkProgram(shaderProgram);

        transformationLocation = GL.GetUniformLocation(shaderProgram, "transformation");

        GL.DetachShader(shaderProgram, vertexShaderHandler);
        GL.DetachShader(shaderProgram, pixelShaderHandler);

        GL.DeleteShader(vertexShaderHandler);
        GL.DeleteShader(pixelShaderHandler);

        base.OnLoad();

    }

    /// <summary>
    /// Call every single frame. Is different from the update
    /// </summary>
    /// <param name="e"></param>
    protected override void OnRenderFrame(FrameEventArgs e)
    {

        GL.Clear(ClearBufferMask.ColorBufferBit); // Clear the screen        
        // Add rendering code here (e.g., draw sprites, shapes, etc.)

        GL.UseProgram(shaderProgram);

        GL.UniformMatrix4(transformationLocation, false, ref transformationMatrix);

        GL.BindVertexArray(vertexArrayHandler);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);


        Context.SwapBuffers(); // Display the frame, change between actual window for new window
        base.OnRenderFrame(e);
    }

    /// <summary>
    /// update rendering. Is different from the renderer
    /// </summary>
    /// <param name="args"></param>
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        var inputKey = KeyboardState;
        float moveSpeed = 1.5f * (float)args.Time;
        if (inputKey.IsKeyDown(Keys.W))
        {
            transformationMatrix *= Matrix4.CreateTranslation(0.0f, moveSpeed, 0.0f);
        }
        if (inputKey.IsKeyDown(Keys.A))
        {
            transformationMatrix *= Matrix4.CreateTranslation(-1 * moveSpeed, 0.0f, 0.0f);
        }
        if (inputKey.IsKeyDown(Keys.D))
        {
            transformationMatrix *= Matrix4.CreateTranslation(moveSpeed, 0.0f, 0.0f);
        }
        if (inputKey.IsKeyDown(Keys.S))
        {
            transformationMatrix *= Matrix4.CreateTranslation(0.0f, -1 * moveSpeed, 0.0f);
        }
    }

    protected override void OnUnload()
    {
        //GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.DeleteBuffer(_vertexBufferHandler);

        GL.UseProgram(0);
        GL.DeleteProgram(shaderProgram);

        base.OnUnload();
    }
}
