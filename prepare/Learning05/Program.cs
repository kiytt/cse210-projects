using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        bool funSwitch = true;

        List<Shape> shapes = new List<Shape>()
        {
            new Square(3,"blue"), 
            new Rectangle(3,4,"magenta"), 
            new Circle(3,"green"), 
            new Triangle(3,4,5,"red"), 
            new Triangle(3,4,"cyan"),
            new Circle(45, "vermillion")
        };   

        foreach (Shape shape in shapes)
        {
            if (funSwitch)
            {
                Console.WriteLine($"Area: {shape.GetArea(), -10:F2} | Color: {shape.GetColoredColor()}"); // - is left aligned within 10 spaces, F for truncate to float with 2 after decimal
            }
            else
            {
                Console.WriteLine($"Area: {shape.GetArea(), -10:F2} | Color: {shape.GetColor()}");
            }
            
        }
    }
}