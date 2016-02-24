using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(new Vector3(0, 0, -45) * Time.deltaTime);
    }
}
