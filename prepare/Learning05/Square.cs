using System;

public class Square : Shape
{
    // attr
    private double _side;

    // cons
    public Square(double side, string color) : base(color)
    {
        _side = side;
    }

    // meth
    public override double GetArea()
    {
        return _side*_side; // what do you mean i cant just raise something to a power???
    }


}