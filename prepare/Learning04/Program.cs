using System;

class Program
{
    static void Main(string[] args)
    {
        // Wouldn't it be neat to make something for the Standard Model of Particle Physics?   
        // oh, but there's too much overlap!
        // baryons are fermionic hadrons - half int spin and composed of quarks
        // mesons are bosonic hadrons - int spin and composed of quarks
        // quarks are fundamental fermions - no internal structure and half int spin
        // I could do particle / fermion, boson --> everything is one of those two
        // but then that means I can't have an overall split of fundamental particle or composite hadron

        // Assignment test1 = new Assignment("Pippin", "Accept scritches");
        // Assignment test2 = new Assignment("Merry", "Step up");

        // Console.WriteLine(test1.GetSummary());
        // Console.WriteLine(test2.GetSummary());

        MathAssignment test1 = new MathAssignment("Pippin", "Don't bite", "3.4", "7-10");
        EngAssignment test2 = new EngAssignment("Merry", "Making friends", "To Step Up, or Not to Step Up");

        Console.WriteLine(test1.GetSummary());
        Console.WriteLine(test1.GetHwList());
        Console.WriteLine();
        Console.WriteLine(test2.GetSummary());
        Console.WriteLine(test2.GetWritingInfo());

    }
}