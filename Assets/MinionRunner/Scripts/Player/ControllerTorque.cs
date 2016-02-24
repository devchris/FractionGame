using UnityEngine;
using System.Collections;

public class ControllerTorque : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        GetComponent<Rigidbody>().AddTorque(transform.up * h);

    }
}
