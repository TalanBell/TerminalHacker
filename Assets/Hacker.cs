using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "child", "adult", "books", "table", "dates" };
    string[] level2Passwords = { "physics", "chemistry", "biology", "english", "history" };
    string[] level3Passwords = { "continental", "biological", "espionage", "intelligence", "government" };
    string[] devices = { "library computer.", "local school.", "Pentagon!" };

    // Game state
    string playerName;
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

	// Use this for initialization
	void Start ()
    {
        playerName = "Berris Fueller";
        ShowMainMenu(playerName);
    }
	
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Hello " + greeting);
        Terminal.WriteLine("Who do you want to hack today?");
        //Terminal.WriteLine("Password length increases from 1-3");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for your local school");
        Terminal.WriteLine("Press 3 try to hack into the Pentagon");
        Terminal.WriteLine("Enter 'menu' at any time to return here");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
         if (input == "menu") // We can always go direct to main menu
        {
            ShowMainMenu(playerName);
        } 
         else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
         else if (currentScreen == Screen.Password)
        {
            TestPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            Terminal.WriteLine("Please type 'menu' for Main Menu:");
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = ( input =="1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")  //Easter Egg
        {
            playerName = "Mr Bond";
            ShowMainMenu(playerName);
        }
        else if (input == "42")  //Easter Egg
        {
            playerName = "Arthur Dent";
            Terminal.WriteLine("That's the answer, what's the question?");
        }
        else if (input == "3.141592")  //Easter Egg
        {
            Terminal.WriteLine("I do like a slice of Pi.");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Unknown error - invalid level!");
                break;
        }
        Terminal.WriteLine("Please enter your password:");
    }

    void TestPassword(string input)
    {
        if (input == password)
            {
                currentScreen = Screen.Win;
                Terminal.WriteLine("Congratulations! You've hacked into the" + devices[level-1] );
            }
        else
            {
                Terminal.WriteLine("Incorrect password. Try again:");
            }
    }
        //else
        //{
        //    Terminal.WriteLine("The system is broken!");
        //    print("Level not set to 1, 2, or 3!!!");
        //    currentScreen = Screen.MainMenu;
        //}
    
}
