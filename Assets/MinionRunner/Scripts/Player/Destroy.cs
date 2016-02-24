using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	
	
	void Update () {
        if (gameObject.transform.position.y <= -30)
        {

            Destroy(gameObject);

        }
    }
}
