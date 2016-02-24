using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pickup : MonoBehaviour {

    public Text pickup;
    private int countPickup;
    

    void Start () {
        countPickup = 0;
        pickup = GameObject.Find("Score").GetComponent<Text>();
	}
	
	
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            countPickup += 1;
            SetCountPickup();
        }
    }

    

    void SetCountPickup()
    {
        pickup.text = "Bonus \nPoints: " + countPickup.ToString() + "/4";
    }
}
