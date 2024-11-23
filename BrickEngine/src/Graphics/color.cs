/// <summary>
/// Represents a RGB color with transparency
/// </summary>

public class Color {

    /// <summary>
    /// Represents Red color from RGB (0-255)
    /// </summary>
    public float Red {get; set;}

    /// <summary>
    /// Represents Green color from RGB (0-255)
    /// </summary>
    public float Green {get; set;}

    /// <summary>
    /// Represents Blue color from RGB (0-255)
    /// </summary>
    public float Blue {get; set;}

    /// <summary>
    /// Represents Transparency/Alpha (0-1f)
    /// </summary>
    public float Alpha {get; set;}


    /// <summary>
    /// Constructor to build an instance for a Color. Use int numbers from 0-255 for a RGB combination.
    /// OpenTK use a percentage value to represents color's triplet, but the constructor only need the real value 
    /// from 0-255
    /// </summary>
    /// <param name="r">Red color from 0-255</param>
    /// <param name="g">Green color from 0-255</param>
    /// <param name="b">Blue color from 0-255</param>
    /// <param name="a">Transparency from 0-1</param>
    public Color(float r, float g, float b, float a){
        Red = r/255.0f;
        Green = g/255.0f;
        Blue = b/255.0f;
        Alpha = a;        
    }

    /// <summary>
    /// Gets a RGB Color from a HEX Color. Uses a integer value like 0xffffff
    /// </summary>
    /// <param name="hexColor">hex color in numeric format 0xffffff</param>
    /// <returns></returns>
    public static Color FromHexColor(int hexColor){
        float red = hexColor >> 16 & 0xFF;
        float green = hexColor >> 8 & 0xFF;
        float blue = hexColor & 0xFF;
        return new Color(red/255.0f,green/255.0f,blue/255.0f,1f);
    }



    



}