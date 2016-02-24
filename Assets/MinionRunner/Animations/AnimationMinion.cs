using UnityEngine;
using System.Collections;

public class AnimationMinion : MonoBehaviour {

    Animator minion;

   

    void Awake()
    {
        minion = GetComponent<Animator>();
        GetComponent<Rigidbody>();
    }



	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        move();
	}

    void move()
    {
        float move = Input.GetAxis("Horizontal");
        minion.SetFloat("Speed", move);
    }
}
