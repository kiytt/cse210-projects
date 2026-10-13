using System;

public class Rectangle : Shape
{
    // attr
    private double _length;
    private double _width;

    // cons
    public Rectangle(double length, double width, string color) : base(color)
    {
        _length = length;
        _width = width;
    }

    // meth
    public override double GetArea()
    {
        return _length*_width;
    }


}