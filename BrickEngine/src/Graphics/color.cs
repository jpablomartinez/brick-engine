/// <summary>
/// Represents a RGB color with transparency.
/// Bits 16 - 23 are red value
/// Bits 8 - 15 are green value
/// Bits 0 - 7 are blue value
/// For example, A full white color can be represented as follow: 0xffffff
/// </summary>

public class Color
{

    /// <summary>
    /// Represents Red color from RGB (0-1)
    /// </summary>
    public float Red { get; set; }

    /// <summary>
    /// Represents Green color from RGB (0-1)
    /// </summary>
    public float Green { get; set; }

    /// <summary>
    /// Represents Blue color from RGB (0-1)
    /// </summary>
    public float Blue { get; set; }

    /// <summary>
    /// Represents Transparency/Alpha (0-1f)
    /// </summary>
    public float Alpha { get; set; }


    /// <summary>
    /// Constructor to build an instance for a Color. Use int numbers from 0-255 for a RGB combination.
    /// OpenTK use a percentage value to represents color's triplet, but the constructor only need the real value 
    /// from 0-255
    /// </summary>
    /// <param name="r">Red color from 0-255</param>
    /// <param name="g">Green color from 0-255</param>
    /// <param name="b">Blue color from 0-255</param>
    /// <param name="a">Transparency from 0-1</param>
    public Color(float r, float g, float b, float a = 1f)
    {
        if (r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
            throw new ArgumentOutOfRangeException("RGB values must be in the range 0-255.");
        if (a < 0 || a > 1)
            throw new ArgumentOutOfRangeException("Alpha value must be in the range 0-1.");
        Red = r / 255.0f;
        Green = g / 255.0f;
        Blue = b / 255.0f;
        Alpha = a;
    }

    /// <summary>
    /// Gets a RGB Color from a HEX Color. Uses a integer value like 0xffffff
    /// </summary>
    /// <param name="hexColor">hex color in numeric format 0xffffff</param>
    /// <returns></returns>
    public static Color FromHexColor(int hexColor, float alpha = 1f)
    {
        if (hexColor < 0 || hexColor > 0xFFFFFF)
            throw new ArgumentOutOfRangeException("Hex color must be in the range 0x000000 to 0xFFFFFF.");
        if (alpha < 0 || alpha > 1)
            throw new ArgumentOutOfRangeException("Alpha value must be in the range 0-1.");
        //float alpha = hexColor >> 24 & 0xFF;
        float red = hexColor >> 16 & 0xFF;
        float green = hexColor >> 8 & 0xFF;
        float blue = hexColor & 0xFF;
        return new Color(red, green, blue, 1f);
    }

    /// <summary>
    /// A To String 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"RGB:({Red},{Green},{Blue},{Alpha})";
    }

    /// <summary>
    /// Gets a Color instance representing pure white (RGB: 255, 255, 255).
    /// </summary>
    public static Color PureWhite => new Color(255, 255, 255);

    /// <summary>
    /// Gets a Color instance representing pure black (RGB: 0, 0, 0).
    /// </summary>
    public static Color PureBlack => new Color(0, 0, 0);

    /// <summary>
    /// Gets a Color instance representing pure red (RGB: 255, 0, 0).
    /// </summary>
    public static Color PureRed => new Color(255, 0, 0);

    /// <summary>
    /// Gets a Color instance representing pure green (RGB: 0, 255, 0).
    /// </summary>
    public static Color PureGreen => new Color(0, 255, 0);

    /// <summary>
    /// Gets a Color instance representing pure blue (RGB: 0, 0, 255).
    /// </summary>
    public static Color PureBlue => new Color(0, 0, 255);

    /// <summary>
    /// Gets a Color instance representing a Brick Console background color (green tint, like a electronic old school screen).
    /// </summary>
    public static Color BrickColor => new Color(161, 170, 148);





}