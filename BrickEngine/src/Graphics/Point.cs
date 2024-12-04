/// <summary>
/// Represents a point in 3D space with X, Y, and Z coordinates.
/// Provides methods for initialization, string representation, equality comparison,
/// and hash code generation based on the coordinates.
/// </summary>
public class Point
{

    /// <summary>
    /// a x coordinate point
    /// </summary>
    public float X { get; set; }

    /// <summary>
    /// a y coordinate point
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// a z coordinate point (in 2D default value is 0f)
    /// </summary>
    public float Z { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Point"/> class with specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate of the point.</param>
    /// <param name="y">The Y coordinate of the point.</param>
    /// <param name="z">The Z coordinate of the point, default is 0.</param>
    public Point(float x, float y, float z = 0f)
    {
        X = x;
        Y = y;
        Z = z;
    }

    /// <summary>
    /// Returns a string representation of the point in the format "P:(X,Y)".
    /// </summary>
    public override string ToString()
    {
        return $"P:({X},{Y})";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current point instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current point.</param>
    /// <returns>
    /// <c>true</c> if the specified object is a <see cref="Point"/> and has the same X and Y coordinates;
    /// otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals(object? obj)
    {
        if (obj is Point other)
        {
            return other.X == X && other.Y == Y;
        }
        return false;
    }

    /// <summary>
    /// Generates a hash code for the current point instance using its X, Y, and Z coordinates.
    /// </summary>
    /// <returns>
    /// An integer hash code representing the point.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

}