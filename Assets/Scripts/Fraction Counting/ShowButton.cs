using UnityEngine;
using System.Collections;

public class ShowButton : MonoBehaviour {

  
    public GameObject Increase_Button;
    bool showGui = false;

	void Update () {
	    if (showGui)
        {
            Increase_Button.gameObject.SetActive(true);
        }

        if (!showGui)
        {
            Increase_Button.gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag == "Player" && gameObject.name == "Denominator")
        {
            showGui = true;
        }
        if (Player.gameObject.tag == "Player" && gameObject.name == "Nominator")
        {
            showGui = true;
        }
    }
   
}
