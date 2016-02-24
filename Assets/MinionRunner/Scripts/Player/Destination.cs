using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

    public GameObject ActiveScript;
    bool running = true;

    void Update() {
        if (running)
        {
            ActiveScript.gameObject.SetActive(true);
        }

        if (!running)
        {
            ActiveScript.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision Player)
    {
        if (Player.gameObject.tag == "Player" && gameObject.name == "Destination")
        {
            running = false;
        }
    }
}
