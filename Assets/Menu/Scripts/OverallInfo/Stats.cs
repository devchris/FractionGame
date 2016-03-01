using UnityEngine;
using System.Collections;

public class Stats
{
    public static Stats gameControl;

    //Game Data
    private static int gamesWon = 0;
    private static int gamesLost = 0;
    private static int playerLives = 5;
    private static int playerGold = 0;
    private static bool[] trophy = new bool[6]; //Stores the status of each trophy (number of trophies has to be adjusted if changed)

    //Keep Track of current panel
    private static int currentLocation = 0;

    //***Accessor Functions***
    public int GetWins()
    {
        return gamesWon;
    }
    public int GetLosses()
    {
        return gamesLost;
    }

    public int GetLives()
    {
        return playerLives;
    }

    public int GetGold()
    {
        return playerGold;
    }

    public bool[] GetTrophyStatus()
    {
        return trophy;
    }

    public bool GetTrophyStatus(int trophyID)
    {
        return trophy[trophyID];
    }

    public int GetCurrentPanel()
    {
        return currentLocation;
    }

    //***Mutator Functions***
    public void AddWin()
    {
        gamesWon++;
    }

    public void AddLoss()
    {
        gamesLost++;
    }

    public void LostLife()
    {
        if (playerLives > 0)
            playerLives--;
        else
            Debug.Log("You have no more lives.");
    }

    public void AddGold(int value)
    {
        playerGold += value;
    }

    public void SubtractGold(int value)
    {
        playerGold -= value;
    }

    //For Loading information
    public void SetWins(int won)
    {
        gamesWon = won;
    }

    public void SetLosses(int lost)
    {
        gamesLost = lost;
    }

    public void SetLives(int lives)
    {
        playerLives = lives;
    }

    public void SetGold(int gold)
    {
        playerGold = gold;
    }

    public void SetTrophyStatus(bool[] status)
    {
        trophy = status;
    }

    public void SetTrophyStatus(int trophyID, bool trophyStatus)
    {
        trophy[trophyID] = trophyStatus;
    }

    public void SetCurrentPanel(int newLocation)
    {
        currentLocation = newLocation;
    }

    //Check for any trophy changes (if requirements are met) ***Needs to be changed for new Trophies or Rewards***
    public void CheckTrophyUnlock()
    {
        //Trophy #1 Conditions
        if (gamesWon > 0 && trophy[0] == false)
        {
            SetTrophyStatus(0, true); //trophy completed
            AddGold(50); //reward added
        }
    }
}
