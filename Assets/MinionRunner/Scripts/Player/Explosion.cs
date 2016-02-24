using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public GameObject explosion;
    

    void OnCollision(Collider test)
    {
        if (test.gameObject.tag == "Player" && gameObject.name == "Denominator")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("test");
        }
        
        
    }
}
