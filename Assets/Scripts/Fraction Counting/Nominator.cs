using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Nominator : MonoBehaviour {

    public Text nominator;
    public static int countN = 0;

    

    void start()
    {
        countN = 0;
        SetCountTextN();
    }

    
    void OnCollisionEnter(Collision Player)
     {
         if (Player.gameObject.tag == "Player" && gameObject.name == "Nominator")
         {
            countN = 1;
         }
     }

   
    void Update()
    {
        if (gameObject.name == "Nominator")
        {
            SetCountTextN();
        }

    }

    void SetCountTextN()
    {
        nominator.text = countN.ToString();
    }

    public void Click()
    {
        countN++;
    }
}
