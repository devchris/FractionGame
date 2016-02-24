using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    [HideInInspector] public static bool setActive;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 1000f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
       // if (setActive == true)
        //{
            Move(h, v);
            Turning();
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

    void Turning()
    {
         Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit floorHit;
         if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
         {
             Vector3 playerToMouse = floorHit.point - transform.position;
             playerToMouse.y = 0f;
             Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
             playerRigidbody.MoveRotation(newRotation);
         } 
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
        bool walking = h!=0f || v!=0f;
        anim.SetBool("IsWalking", walking);
    }
}
