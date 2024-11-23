public class Square {
    public float Height { get; set; }
    public float Width { get; set; }

    public Vertex[] vertices {get;private set;}

    public Square(float h, float w, Point origin, Color c){
        Height = h;
        Width = w;
        vertices = new Vertex[4];
        

    }


}