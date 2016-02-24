using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Denominator : MonoBehaviour {

    public Text denominator;
    public static int countD = 0;


    void start()
    {
        countD = 0;
        SetCountTextD();
    }


    void OnCollisionEnter(Collision Player)
     {
         if (Player.gameObject.tag == "Player" && gameObject.name=="Denominator")
         {
             countD = 1;

         }
      

     }
    
    void Update()
    {
        if (gameObject.name == "Denominator")
        {
            SetCountTextD();

        }
    }

    void SetCountTextD()
    {
        denominator.text = countD.ToString();
    }

    public void Click()
    {
        countD++;
    }
}

