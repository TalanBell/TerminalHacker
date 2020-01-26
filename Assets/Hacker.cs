using UnityEngine;

public class Hacker : MonoBehaviour
{

    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "child", "adult", "books", "table", "dates" };
    string[] level2Passwords = { "physics", "chemistry", "biology", "english", "history" };
    string[] level3Passwords = { "continental", "biological", "espionage", "intelligence", "government" };
    string[] devices = { "library computer.", "local school.", "NORAD!" };

    // Game state
    string playerName;
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start()
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
            Terminal.WriteLine(menuHint);
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "quit" || input == "exit" || input == "exit")
        {
            Terminal.WriteLine("If on the web, close the browser tab.");
            Application.Quit();
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
        else if (input == "joshua")  //Easter Egg
        {
            playerName = "Dr Falken";
            Terminal.WriteLine("Hello Dr Falken. It's been a long time.");
            Terminal.WriteLine("Can you explain the removal of your");
            Terminal.WriteLine("useraccount on June 23rd, 1973?");
        }
        else if (input == "2b")  //Easter Egg
        {
            playerName = "Hamlet";
            Terminal.WriteLine("... or not 2B, that is the question...");
        }
        else if (input == "easter" || input == "easteregg" || input == "eastereggs")
        {
            Terminal.WriteLine("007, 42, 3.141592, 2b, ...");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid level.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
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
    }

    void TestPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Congratulations! You've hacked into the" + devices[level - 1]);
                Terminal.WriteLine("Have a book ...");
                Terminal.WriteLine(@"
 _______
(______(\
 \      \\
  \      \\
   \______\|
");
                break;
            case 2:
                Terminal.WriteLine("Congratulations! You've hacked into the" + devices[level - 1]);
                Terminal.WriteLine(@"
    \_/
  --(_)--  .
    / \   /_\
          |Q|
    .-----' '-----.           __
   /____[SCHOOL]___\         ()))
    | [] .-.-. [] |         (((())
  ..|____|_|_|____|...........)(..."
                );
                break;
            case 3:
                //               Terminal.WriteLine("Congratulations! You've hacked into " + devices[level - 1]);
                Terminal.WriteLine("Welcome to WPOR. Want to play a game?");
                Terminal.WriteLine(@"How about Global Thermonuclear War?

  /\     |\**/|      
 /  \    \ == /
 |  |     |  |
 |  |     |  |
/ == \    \  /
|/**\|     \/ "
                );
                Terminal.WriteLine("\nBonus: type Wargames password at menu");
                break;
            default:
                Debug.LogError("Unknown error - invalid level!");
                break;
        }
    }
    //else
    //{
    //    Terminal.WriteLine("The system is broken!");
    //    print("Level not set to 1, 2, or 3!!!");
    //    currentScreen = Screen.MainMenu;
    //}

}
