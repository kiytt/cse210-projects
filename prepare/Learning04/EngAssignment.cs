using System;

public class EngAssignment : Assignment
{

    // Attributes/member variables
    private string _title = "";

    // Constructors
    public EngAssignment(string studentName, string topic, string title) : base(studentName, topic)
    {   
        _title = title;
    }

    
    // Methods
    public string GetWritingInfo()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }

}