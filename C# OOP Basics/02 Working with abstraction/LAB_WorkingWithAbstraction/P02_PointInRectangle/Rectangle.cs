public class Rectangle
{
    private Point topLeft;
    private Point bottomRight;
    
    public Rectangle(Point topCorner, Point bottomCorner)
    {
        this.TopLeft = topCorner;
        this.BottomRight = bottomCorner;
    }

    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }

    public Point BottomRight
    {
        get { return bottomRight; }
        set { bottomRight = value; }
    }

    public bool Contains(Point point)
    {
        bool isInHorizontal = this.TopLeft.X <= point.X && this.BottomRight.X >= point.X;
        bool isInVertical = this.TopLeft.Y <= point.Y && this.BottomRight.Y >= point.Y;

        return isInHorizontal && isInVertical;
    }
}

