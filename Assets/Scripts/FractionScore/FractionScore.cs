using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FractionScore : MonoBehaviour {

    public int FractionValue = 0;
    public GameObject UICog;
    public GameObject UICogBlack;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FractionManager.score += FractionValue;
            UICog.SetActive(true);
            UICogBlack.SetActive(false);
        }
    }
}
