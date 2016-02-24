using UnityEngine;
using System.Collections;

public class ClickSpawn : MonoBehaviour {

    public GameObject[] sphere;
    public Transform SpawnChild;

    private Vector3 spawnPoint;

    bool minion = false;

    // private int amount = 0;
    // Use this for initialization

    public void spawn()
    { 
        minion = true;
    }

    void createPrefabs()
    {
        if (minion == true)
            
            InvokeRepeating("spawnObject", 0f, 0f);
            minion = false;
            
    }

    void spawnObject()
    {
/*
        spawnPoint.x = -38;
        spawnPoint.y = 2;
        spawnPoint.z = 0;
        */
        ((GameObject)Instantiate(sphere[UnityEngine.Random.Range(0,sphere.Length)], SpawnChild.position, SpawnChild.rotation)).transform.parent = SpawnChild;
        //CancelInvoke();

    }

    // Update is called once per frame
    void Update()
    {
        if (minion == true)
        {
            createPrefabs();
        }

    }
}
