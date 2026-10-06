using System;

public class Assignment
{

    // Attributes/member variables
    private string _studentName = "";
    private string _topic = "";

    // Constructors
    
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }
    
    // Methods
    public string GetSummary()
    {
        return $"{_studentName} | {_topic}";
    }

    // -- Get n set --
     public string GetStudentName()
    {
        return _studentName;
    }

     public string GetTopic()
    {
        return _topic;
    }


}