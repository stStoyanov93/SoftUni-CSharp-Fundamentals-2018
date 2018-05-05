﻿public class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X
    {
        get { return x; }
        private set { x = value; }
    }

    public int Y
    {
        get { return y; }
        private set { y = value; }
    }
}

