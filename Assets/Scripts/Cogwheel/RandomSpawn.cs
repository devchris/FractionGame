using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] CogWheels;
    public int maxSpawnCount = 0;

    // Instantiate the prefab somewhere between -a and a on the x-z plane 
    void Start()
    {
        for (int i = 0; i < maxSpawnCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-45.0F, 45.0F), 3, Random.Range(-45.0F, 45.0F));
            Instantiate(CogWheels[Random.Range(0, CogWheels.Length)], position, Quaternion.identity);
        }
    }
}