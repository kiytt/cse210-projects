using System;

public class ListingActivity : Activity // I could add something that writes to file a question and every response for it you've ever given.
                                        // But I've done too much already for the time I have. So future self, if you ever want to add to
                                        // this for.. whatever reason, here's an idea.
{

    // Attributes/member variables
    private PromptGen _prompts = new PromptGen("ListingPrompts/prompts.txt"); 


    // Constructors
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    
    // Methods
    public void Run()
    {
        Spinner spinner = new Spinner("wait", 100);

        int duration = GetDuration(); // s
        DateTime endTime = DateTime.Now.AddSeconds(duration); // prev methods not work real time

        Console.Clear();
        string prompt = _prompts.GetRandom();

        Console.WriteLine("List as many responses as you can:");
        Console.WriteLine(prompt);
        
        while (DateTime.Now < endTime)
        {
            Console.ReadLine(); // i mean the times here are still a lie -- readline halts the loop, so it won't end until you enter past time
        }

    } 

}

// The activity should begin with the standard starting message and prompt for the duration that is used by all activities.
// The description of this activity should be something like: "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
// After the starting message, select a random prompt to show the user such as:

// Who are people that you appreciate?
// What are personal strengths of yours?
// Who are people that you have helped this week?
// When have you felt the Holy Ghost this month?
// Who are some of your personal heroes?
// After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
// The user lists as many items as they can until they they reach the duration specified by the user at the beginning.
// The activity them displays back the number of items that were entered.
// The activity should conclude with the standard finishing message for all activities.