using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject[] sphere;

    private Vector3 spawnPoint;

  

    private int amount = 0;
	// Use this for initialization

    void createPrefabs()
    {
        if(amount <=0)
        InvokeRepeating("spawnObject", 0f, 0f);
        amount++;
    }

    void spawnObject()
    {
        
            spawnPoint.x = -38;
            spawnPoint.y = 2;
            spawnPoint.z = 0;
            Instantiate(sphere[UnityEngine.Random.Range(0, sphere.Length)], spawnPoint, Quaternion.Euler(0,90f,0f));
            //CancelInvoke();
            
    }

	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {


        if (gameObject.transform.position.x >= 27)
        {
        createPrefabs();
        }
        if(gameObject.transform.position.y <=-30)
        {
            
            Destroy(gameObject);
            
        }
	}
}
