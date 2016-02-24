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
        h = Input.GetAxisRaw("Horizontal");
        if (h == -1)
            Move(0f);
        Move(h);
        Animation(h);

        GetComponent<Rigidbody>().rotation = Quaternion.Euler(GetComponent<Rigidbody>().velocity.x * tiltX, 90.0f, 0.0f);
      
        if (gameObject.transform.position.x >= 22)
        {
            anim.SetBool("IsWalking", false);
            Destroy(this,0.5f);
        }
    }

    void Move(float h)
    {
        movement.Set(h, 0f, 0f);
        movement = movement.normalized*speed*Time.deltaTime; // time between every call
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Animation(float h)
    {
        bool walking = h != 0f;
        if (walking)
            anim.SetBool("IsWalking", true);
    }

}