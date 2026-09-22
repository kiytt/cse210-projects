public class Job
{
    // Attributes/member variables
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // Constructor
    public Job()
    {
    }

    // Methods
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }


}