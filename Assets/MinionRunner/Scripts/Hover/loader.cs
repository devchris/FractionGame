using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class loader : MonoBehaviour {

    public Image circularSlider;

    public float time;
    bool pressMouse = false;

    public void press()
    {   
            pressMouse = true;
    }

	// Use this for initialization
	void Start () {
        circularSlider.fillAmount = 0f;
	
	}
	
 
  
	// Update is called once per frame
	void Update () {
        if (pressMouse == true)
        {
            circularSlider.fillAmount += Time.deltaTime / time;
           // pressMouse = false;
        }
	}
}
