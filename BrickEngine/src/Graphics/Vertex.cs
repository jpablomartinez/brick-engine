public class Vertex
{

    /// <summary>
    /// a (x,y,z) point
    /// </summary>
    readonly Point point;

    /// <summary>
    /// Coordinate Point's color in rgb format
    /// </summary>
    readonly Color color;

    /// <summary>
    /// Initializes a new instance of the <see cref="Vertex"/> class with the specified point and color.
    /// </summary>
    /// <param name="ps">The point representing the position of the vertex.</param>
    /// <param name="c">The color associated with the vertex.</param>
    public Vertex(Point ps, Color c)
    {
        point = ps;
        color = c;
    }

    /// <summary>
    /// Returns the vertex data as a float array containing the X and Y coordinates,
    /// a default Z coordinate of 0, and the RGB color components.
    /// </summary>
    public float[] getVertex()
    {
        float[] vertex = { point.X, point.Y, 0f, color.Red, color.Green, color.Blue };
        return vertex;
    }



}