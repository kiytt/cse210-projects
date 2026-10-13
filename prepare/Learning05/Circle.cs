using System;

public class Circle : Shape
{
    // attr
    private double _radius;

    // cons
    public Circle(double radius, string color) : base(color)
    {
        _radius = radius;
    }

    // meth
    public override double GetArea()
    {
        return Math.PI*_radius*_radius;
        // Math.PI
    }


}