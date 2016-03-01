using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputStats : MonoBehaviour 
{
    private string text;

    void Start()
    {
        text = GetComponent<Text>().text;
    }

	public void Update()
    {
        Stats stats = new Stats();

        stats.CheckTrophyUnlock();

        //If the stat panel is currently active
        if (stats.GetCurrentPanel() == 4)
        {
            if (text == "Games Won")
                GetComponent<Text>().text = "Games Won: " + stats.GetWins();
            else if (text == "Games Lost")
                GetComponent<Text>().text = "Games Lost: " + stats.GetLosses();
            else if (text == "Lifes")
                GetComponent<Text>().text = "Lifes: " + stats.GetLives();
            else if (text == "Gold")
                GetComponent<Text>().text = "Gold: " + stats.GetGold();
            else
                Debug.LogError("Stat Not Found.");
        }
    }
}
