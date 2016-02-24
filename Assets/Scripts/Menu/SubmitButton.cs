using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubmitButton : MonoBehaviour
{
    private static int finalScore;
    public Text submit;

    void Start()
    {
        submit.text = "";
    }

    void Update()
    {
        finalScore = FractionManager.score;
    }

    public void validate()
    {
        StartCoroutine(TemporarilyDeactivate(6));
        
    }

    private IEnumerator TemporarilyDeactivate(float time)
    {
        yield return new WaitForSeconds(time);
        if (finalScore == 6)
        {
            //FractionManager.score = -199;
            submit.text = "That is correct! You collected 6/6 parts!\nThe Cogwheel is complete and you may go to the next level!";
        }
        else submit.text = "That was almost correct!\nRemember, a WHOLE Cogwheel has 6/6 parts.\nNow, try again."; //FractionManager.score = 199; 
    }
}