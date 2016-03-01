using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrophySelection : MonoBehaviour 
{
    //Two possible states of the trophies
    public Sprite completedTrophy;
    public Sprite uncompletedTrophy;

    //Original State of the trophy Sprite
    private Sprite originalSprite;
    private Color originalColor;
    private Color[] originalTrophyColor;

    //Check for trophy status
    private Stats status = new Stats();
    private int selected;

    //Hold a reference to each trophy
    private Image[] trophies;

    void Start()
    {
        selected = -1; //No trophy is selected at the start
        trophies = GetComponentsInChildren<Image>();
        originalTrophyColor = new Color[trophies.Length];

        //Set sprite according to the trophy status
        for (int i = 0; i < trophies.Length; i++)
        {
            if (status.GetTrophyStatus(i))
                trophies[i].sprite = completedTrophy;
            else
                trophies[i].sprite = uncompletedTrophy;
        }

        //Save original state of the Sprite
        for (int i = 0; i < trophies.Length; i++)
        {
            originalTrophyColor[i] = trophies[i].color;
        }
    }

    public void UpdateTrophies()
    {
        for (int i = 0; i < trophies.Length; i++)
        {
            if (status.GetTrophyStatus(i))
                trophies[i].sprite = completedTrophy;
            else
                trophies[i].sprite = uncompletedTrophy;
        }
    }

    public void OnPointerEnter(int i)
    {
        //Skip the selected trophy
        if(i != selected)
            trophies[i].color = Color.grey;
    }

    public void OnPointerClick(int i)
    {
        selected = i;
        ResetTrophyiesImage();
        trophies[i].color = Color.yellow;
    }

    public void OnPointerExit(int i)
    {
        //Skip the selected trophy
        if(i != selected)
            ResetTrophyiesImage();
    }

    private void ResetTrophyiesImage()
    {
        for(int i = 0; i < trophies.Length; i++)
        {
            //Skip the selected trophy
            if(i != selected)
                trophies[i].color = originalTrophyColor[i];
        }
    }
}
