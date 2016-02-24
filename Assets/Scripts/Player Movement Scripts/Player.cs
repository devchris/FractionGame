using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public Animator anim;

    public float movementSpeed = 10;
	public float turningSpeed = 60;

	void Update() {
		float horizontal = Input.GetAxis("Vertical") * turningSpeed * Time.deltaTime;
		transform.Rotate(0, horizontal, 0);
        
		float vertical = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
		transform.Translate(0, 0, vertical);

        Animating(0, vertical);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}