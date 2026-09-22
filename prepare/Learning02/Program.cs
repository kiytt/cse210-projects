using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Walgreens Boots Alliance";
        job1._jobTitle = "Customer Service Associate";
        job1._startYear = 2024;
        job1._endYear = 2024;

        Job job2 = new Job();
        job2._company = "Brigham Young University Idaho";
        job2._jobTitle = "Physics Teaching Aide";
        job2._startYear = 2024;
        job2._endYear = 2025;

        Job job3 = new Job();
        job3._company = "Brigham Young University";
        job3._jobTitle = "Undergraduate Research Intern";
        job3._startYear = 2025;
        job3._endYear = 2025;

        Job job4 = new Job();
        job4._company = "Los Alamos National Laboratory";
        job4._jobTitle = "Undergraduate Intern";
        job4._startYear = 2026;
        job4._endYear = 2026;

        Resume asResume = new Resume();
        asResume._name = "Abigail Stringham";
        asResume._jobs.Add(job1);
        asResume._jobs.Add(job2);
        asResume._jobs.Add(job3);
        asResume._jobs.Add(job4);
        asResume.Display();

    }
}