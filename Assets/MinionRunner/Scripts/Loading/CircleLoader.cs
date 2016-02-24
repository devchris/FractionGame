using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircleLoader : MonoBehaviour {

    public Image Circle;
    public float time;
    public float amount;
   


	void Start () {
       Circle.fillAmount = 0.0f;
        
        
   
	}
	
	// Update is called once per frame
	void Update () {
        //Circle.fillAmount = 50;
        Circle.fillAmount += Time.deltaTime / time;

        
        /*while (Circle.fillAmount <= amount)
        {
            Circle.fillAmount += Time.deltaTime / Time.time;
        }
   */
    
    }
    
}
