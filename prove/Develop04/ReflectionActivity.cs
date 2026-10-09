using System;

public class ReflectionActivity : Activity 
{

    // Attributes/member variables
    private PromptGen _prompts = new PromptGen("ReflectionPrompts/prompts.txt"); 
    private PromptGen _questions = new PromptGen("ReflectionPrompts/questions.txt"); 



    // Constructors
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }
        
    // Methods
    public void Run()
    {
        Spinner spinner = new Spinner("ball", 70);

        int duration = GetDuration(); // s
        int elapsed = 0;
        int questionTime = 8; //s

        Console.Clear();
        string prompt = _prompts.GetRandom();

        Console.WriteLine("Consider:\n");
        Console.WriteLine(prompt);
        Console.WriteLine("\nPress enter to continue.");
        Console.ReadLine();

        do
        {
            Console.Clear();
            string question = _questions.GetRandom();

            Console.WriteLine(question);
            
            spinner.Play(questionTime);

            elapsed += questionTime;
        } while (elapsed < duration);

    } 

}
