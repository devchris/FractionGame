using UnityEngine;
using System.Collections;

public class JumpAudio : MonoBehaviour
{

   // public AudioClip jumpen;
    public AudioSource jump;
   // public AudioSource fall;



    void Awake()
    {
        jump = GetComponent<AudioSource>();
    //    fall = GetComponent<AudioSource>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.Play();
        }
        /*if (gameObject.transform.position.y <= -8.5)
        {
            fall.Play();
        }
        */
    }
}