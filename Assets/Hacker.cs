﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    
    // Game state
    string playerName;
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

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
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "007")
        {
            playerName = "Mr Bond";
            ShowMainMenu(playerName);
        }
        else if (input == "42")
        {
            playerName = "Arthur Dent";
            Terminal.WriteLine("That's the answer, what's the question?");
        }
        else if (input == "3.141592")
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
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password:");
    }

    void TestPassword(string input)
    {
        if (level == 1)
        {
            if (input == "books")
            {
                currentScreen = Screen.Win;
                Terminal.WriteLine("Congratulations! You're into the libary computer.");
            }
            else
            {
                Terminal.WriteLine("Incorrect password. Try again:");
            }
        }
        else if (level == 2)
        {
            if (input == "physics")
            {
                currentScreen = Screen.Win;
                Terminal.WriteLine("Congratulations! You're into the school computer.");
            }
            else
            {
                Terminal.WriteLine("Incorrect password. Try again:");
            }
        }
        else
        {
            Terminal.WriteLine("The system is broken!");
            print("Level not set to 1, 2, or 3!!!");
            currentScreen = Screen.MainMenu;
        }
    }
}
