using System;

public class UserManager // its time i get better at paths and navigation in C# -- hopefully sim to python
{
    // attributes
    private string _username;
    private string _userDir;
    private string _loginPath;
    private string _goalsPath;
    private string _progressPath;


    // constructors
    public UserManager(string username, string password)
    {
        _username = username;
        _userDir = Path.Combine("users", username);
        _loginPath = Path.Combine(_userDir, "login.txt");
        _goalsPath = Path.Combine(_userDir, "goals.txt");
        _progressPath = Path.Combine(_userDir, "progress.txt");

        InitFiles(password);
    }

    // methods
    public string GetGoalPath()
    {
        return _goalsPath;
    }
    public string GetProgressPath()
    {
        return _progressPath;
    }
    
    public void InitFiles(string password)
    {
        Directory.CreateDirectory(_userDir);

        if (File.Exists(_loginPath))
        {
            string storedPassword = File.ReadAllText(_loginPath).Split('|')[1]; // WAY simpler than streamwriter/reader!
            
            while (password != storedPassword)
            {
                Console.Write("Incorrect.\npassword: ");
                password = Console.ReadLine();
            }
        }
        else
        {
            File.WriteAllText(_loginPath, $"{_username}|{password}");
        }

        if (!File.Exists(_goalsPath)) File.WriteAllText(_goalsPath, "");
        if (!File.Exists(_progressPath)) File.WriteAllText(_progressPath, "");
    }

}