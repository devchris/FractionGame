using UnityEngine;
using System.Collections;

public class MovingPlatforms : MonoBehaviour
{

    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector2 newPosition;
    public string currentState;
    public float smooth;
    public float resetTime;


    // Use this for initialization
    void Start()
    {
        ChangeTarget();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movingPlatform.position = Vector2.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
            
            //Slerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }

    void ChangeTarget()
    {
        if (currentState == "moving to position 1")
        {
            currentState = "moving to position 2";
            newPosition = position2.position;
        }
        else if (currentState == "moving to position 2")
        {
            currentState = "moving to position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "moving to position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
       
    }
}
