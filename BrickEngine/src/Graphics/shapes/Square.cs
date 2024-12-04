using OpenTK.Graphics.OpenGL4;

public class Square
{
    public float Height { get; set; }
    public float Width { get; set; }

    private int _vertexBufferObject;
    private int _vertexArrayObject;
    private int _elementBufferObject;
    private int _shaderProgram;

    public Square(float h, float w, Color c)
    {
        Height = h;
        Width = w;

        float[] vertices = {
            -w/2, h/2, 0f,
            w/2, h/2, 0f,
            w/2, -h/2, 0f,
            -w/2, -h/2, 0f
        };

        uint[] indices =
        {
            0, 1, 2, // First triangle
            2, 3, 0  // Second triangle
        };

        //Generate and bind vertex array object
        _vertexBufferObject = GL.GenVertexArray();
        GL.BindVertexArray(_vertexBufferObject);

        //Generate and bind Vertex Buffer Object
        _vertexBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        //Genrate and bind Element Buffer Object
        _elementBufferObject = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

        // Compile shaders
        string vertexShaderSource = @"
            #version 330 core
            layout (location = 0) in vec3 aPosition;

            void main()
            {
                gl_Position = vec4(aPosition, 1.0);
            }
        ";

        string fragmentShaderSource = @"
            #version 330 core
            out vec4 FragColor;

            void main()
            {
                FragColor = vec4(0.0, 0.5, 1.0, 1.0); // Blue color
            }
        ";

        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, vertexShaderSource);
        GL.CompileShader(vertexShader);

        int fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShader, fragmentShaderSource);
        GL.CompileShader(fragmentShader);

        _shaderProgram = GL.CreateProgram();
        GL.AttachShader(_shaderProgram, vertexShader);
        GL.AttachShader(_shaderProgram, fragmentShader);
        GL.LinkProgram(_shaderProgram);

        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragmentShader);

        //configure vertex attr
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        //Unbind to avoid accidental modification
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);

    }

    public void Draw()
    {
        GL.UseProgram(_shaderProgram);
        GL.BindVertexArray(_vertexArrayObject);
        GL.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, 0);
    }


}