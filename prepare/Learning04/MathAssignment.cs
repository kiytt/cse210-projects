using System;

public class MathAssignment : Assignment
{

    // Attributes/member variables
    private string _textbookSection = "";
    private string _problems = "";

    // Constructors
    public MathAssignment(string studentName, string topic, string textbookSection, string problems) : base(studentName, topic)
    {   
        _textbookSection = textbookSection;
        _problems = problems;
    }


    
    // Methods
    public string GetHwList()
    {
        return $"Section {_textbookSection} #{_problems}";
    }


}