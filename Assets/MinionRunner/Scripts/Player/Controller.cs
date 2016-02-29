using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float speed;
    public float jump;
    public float tiltX;

    float h;

    Animator anim;
    Vector3 movement;
    Rigidbody playerRigidbody;

    

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        anim.SetBool("IsWalking", false);
        if (Input.GetKeyDown(KeyCode.Space))
            playerRigidbody.AddForce(transform.up * jump, ForceMode.Impulse);

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            // if (setActive == true)
            //{
            Move(h, v);

        }

        void Move(float h, float v)
        {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime; // time between every call
        playerRigidbody.MovePosition(transform.localPosition + movement);
    //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
}

    void Animation(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        if (walking)
            anim.SetBool("IsWalking", true);
    }

}