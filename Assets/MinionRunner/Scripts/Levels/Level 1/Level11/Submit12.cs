using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Submit12 : MonoBehaviour {

    private static int nominator;
    private static int denominator;

   // public GameObject Hint;
   // bool showHint = false;
      

    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        nominator = Nominator.countN;
        denominator = Denominator.countD;
    }
/*
        if (showHint)
        {
            Hint.gameObject.SetActive(true);
        }
        if (!showHint)
        {
            Hint.gameObject.SetActive(false);
        }
    }
    */
    public void check()
    {
        if(nominator == 1 && denominator == 4)
        {
            Application.LoadLevel(7);
            Nominator.countN = 0;
            Denominator.countD = 0;
            
        }
        else
        {
            Nominator.countN = 0;
            Denominator.countD = 0;
            Application.LoadLevel(6);
      
        }
    }
}
