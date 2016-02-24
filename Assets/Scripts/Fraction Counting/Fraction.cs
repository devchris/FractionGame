using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fraction : MonoBehaviour {
    public Text nominator;
    public Text denominator;
    public int countN = 1, countD = 1;

    private static Fraction instance = null;
    public static Fraction SharedInstance
    {
        get
        {
            if (instance = null)
            {
                instance = new Fraction();
            }
            return instance;
        }
       
    }

    // Use this for initialization
    void start() {
  //      rigid = GetComponent<Rigidbody>();
  //      Text txt = gameObject.GetComponent<Text>();
        SetCountTextD();
        SetCountTextN();
    }


   /*void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag == "Player" && gameObject.name=="Denominator")
        {
            countD = 1;
            
        }
        if (Player.gameObject.tag == "Player" && gameObject.name == "Nominator")
        {
           countN = 1;
        }

    }
   */ 
    void Update()
    {
        //  txt.text = 1.ToString();

        if (gameObject.name == "Denominator")
        {
            SetCountTextD();
            
        }

        if (gameObject.name == "Nominator")
        {
            SetCountTextN();
            
        }
    }

    void SetCountTextN()
    {
      nominator.text = countN.ToString();
    }

   void SetCountTextD()
    {
      denominator.text = countD.ToString();
    }
}


