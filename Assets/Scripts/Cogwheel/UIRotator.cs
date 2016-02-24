using UnityEngine;
using System.Collections;

public class UIRotator : MonoBehaviour {

	void Update ()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime*2);
    }
}
