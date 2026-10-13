using System;

public class Triangle : Shape
{
    // attr
    private double _bottom;
    private double _height;
    private double _side1;
    private double _side2;
    private double _side3;
    private bool _useBaseHeight;


    // cons
    public Triangle(double bottom, double height, string color) : base(color)
    {
        _bottom = bottom;
        _height = height;
        _useBaseHeight = true;
    }

    public Triangle(double side1, double side2, double side3, string color) : base(color)
    {
        _side1 = side1;
        _side2 = side2;
        _side3 = side3;
        _useBaseHeight = false;
    }

    // meth
    public override double GetArea()
    {
        if (_useBaseHeight)
        {
            return 0.5*_bottom*_height; 
        }
        double s = (_side1+_side2+_side3)/2;
        return Math.Sqrt(s*(s-_side1)*(s-_side2)*(s-_side3));
    }

}