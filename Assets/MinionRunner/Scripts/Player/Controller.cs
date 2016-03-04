using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
{
    public float speed = 6f;
    public float jump;
    public float jumpRate;
    [HideInInspector]
    public static bool setActive;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 1000f;

    private float nextJump;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextJump)
        {
            nextJump = Time.time + jumpRate;
            playerRigidbody.AddForce(transform.up * jump, ForceMode.Impulse);
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        // if (setActive == true)
        //{
        Move(h, v);
        Animating(h, v);
        // }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime; // time between every call
        playerRigidbody.MovePosition(transform.localPosition + movement);
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}