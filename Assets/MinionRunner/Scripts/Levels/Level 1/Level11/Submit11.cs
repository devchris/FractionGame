using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Submit11 : MonoBehaviour {

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

    public void check()
    {
        if(nominator == 1 && denominator == 2)
        {
            Nominator.countN = 0;
            Denominator.countD = 0;
            Debug.Log("Congratulation");
            Application.LoadLevel(4);
            
            
        }
        else
        {
            Nominator.countN = 0;
            Denominator.countD = 0;
            
            Application.LoadLevel(3);
        }
    }
}
