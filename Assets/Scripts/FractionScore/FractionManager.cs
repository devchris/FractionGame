using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FractionManager : MonoBehaviour
{
    public static int score;   
    public int StartingCogPart;    
    Text text;                    

    void Awake()
    {
        text = GetComponent<Text>();
        score = StartingCogPart;
    }

    void Update()
    {
        text.text = "Fraction: " + score + "/6";
    }
}