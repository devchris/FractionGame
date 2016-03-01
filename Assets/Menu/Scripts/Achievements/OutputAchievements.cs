using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputAchievements : MonoBehaviour
{
    //Update Trophy Status when the Trophy Panel is opened
    public void updateTrophy(int trophyID)
    {
        Stats stats = new Stats();
        stats.CheckTrophyUnlock(); //Checks if any new Trophies have been unlocked

        if (stats.GetTrophyStatus(trophyID))
            GetComponent<Text>().text = "Completed";
        else
            GetComponent<Text>().text = "Not Completed";
    }
}
