using UnityEngine;
using System.Collections;

public class MenuNavigation : MonoBehaviour
{
    public Canvas Menu;		//reference for the whole Menu

    //***RectTransform references to each Panel***
    public RectTransform mainMenuPanel;
    public RectTransform shopPanel;
    public RectTransform levelSelectPanel;
    public RectTransform trophyPanel;
    public RectTransform statsPanel;

    //***Animator references***
    public Animator mainMenuAnimator;
    public Animator shopAnimator;
    public Animator levelSelectAnimator;
    public Animator trophyAnimator;
    public Animator statsAnimator;

    //***All Types of possible Animations***
    private const string moveRight = "MoveRight";
    private const string moveLeft = "MoveLeft";
    private const string fadeIn = "MainMenuFadeIn";
    private const string fadeOut = "MainMenuFadeOut";

    //***All Types of possible Scenes***
    private const string Level1 = null;
	private const string Level2 = "Level 1.1";
	private const string Level3 = "Cog 16";
   // private const string UnionGame = "UnionAlgorithmScene";

    //Keep track of which panel the user is in
    /*
     * 0 = main menu panel
     * 1 = level select panel
     * 2 = shop panel
     * 3 = trophies panel
     * 4 = statistics panel
     */
    Stats stats = new Stats();

    void Start()
    {
        //Disable all Panels
        for (int i = 0; i < 4; i++)
        {
            DisablePanel(i);
        }

       //Enable and bring up new Panel
        EnablePanel(0);
        mainMenuAnimator.Play(moveRight);
        stats.SetCurrentPanel(0);
    }

    //Load Play Selection
    public void PlayButton()
    {
        //Enable and bring up new Panel
        EnablePanel(1);
        mainMenuAnimator.Play(fadeOut);
        levelSelectAnimator.Play(fadeIn);
        stats.SetCurrentPanel(1);

        DisablePanel(0); //Disable Main Menu
    }

    //Load Shop/Inventory
    public void ShopButton()
    {
        //Enable and bring up new Panel
        EnablePanel(2);
        mainMenuAnimator.Play(fadeOut);
        shopAnimator.Play(fadeIn);
        stats.SetCurrentPanel(2);

        DisablePanel(0); //Disable Main Menu
    }

    //Load Trophy Panel
    public void TrophiesButton()
    {
        //Enable and bring up new Panel
        EnablePanel(3);
        mainMenuAnimator.Play(fadeOut);
        trophyAnimator.Play(fadeIn);
        stats.SetCurrentPanel(3);

        DisablePanel(0); //Disable Main Menu
    }

    //Load Statistics Panel
    public void StatsButton()
    {
        //Enable and bring up new Panel
        EnablePanel(4);
        mainMenuAnimator.Play(fadeOut);
        statsAnimator.Play(fadeIn);
        stats.SetCurrentPanel(4);

        DisablePanel(0); //Disable Main Menu
    }

    //Load Main Panel
    public void GoToMainPanel()
    {
        //Disable Current Panel and switch over to Main Menu Panel
        switch(stats.GetCurrentPanel())
        {
            //Main Menu Panel
            case 0:
            break;

            case 1:
                levelSelectAnimator.Play(fadeOut);
                DisablePanel(1);
            break;

            case 2:
                shopAnimator.Play(fadeOut);
                DisablePanel(2);
            break;

            case 3:
                trophyAnimator.Play(fadeOut);
                DisablePanel(3);
            break;

            case 4:
                statsAnimator.Play(fadeOut);
                DisablePanel(4);
            break;

            default:
                Debug.LogError("Current Menu Location not found.");
            break;
        }

        EnablePanel(0); //Enable Main Menu
        mainMenuAnimator.Play(fadeIn); //Bring up the Main Menu
    }

    //Load Balancing Game
    public void PlayBalancingGame()
    {
        Application.LoadLevel(Level1); //start level1 game
    }

	//Load Ship Game
	public void PlayShipGame()
	{
		Application.LoadLevel (Level2); //Start level2 game
	}

	//Load Treadmill Game
	public void PlayTreadmillGame()
	{
		Application.LoadLevel(Level3); //Start level3 game
	}

    //Load Union Game
    /*public void PlayUnionGame()
    {
        Application.LoadLevel(UnionGame); //Start the union game
    }*/

    //Save Game
    /*public void SaveButton()
    {
        GameData gameData = new GameData();

        gameData.Save();
    }

    //Load Game
    public void LoadButton()
    {
        GameData gameData = new GameData();

        gameData.Load();
    }*/

    //Quit the Game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Disables Panel
    private void DisablePanel(int panel)
    {
        switch (panel)
        {
            //Main Menu
            case 0:
                mainMenuPanel.GetComponent<CanvasGroup>().interactable = false;
                mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            break;

            //Level Select
            case 1:
                levelSelectPanel.GetComponent<CanvasGroup>().interactable = false;
                levelSelectPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            break;

            //Shop/Inventory
            case 2:
                shopPanel.GetComponent<CanvasGroup>().interactable = false;
                shopPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            break;

            //Trophy
            case 3:
                trophyPanel.GetComponent<CanvasGroup>().interactable = false;
                trophyPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            break;

            //Statistics
            case 4:
                statsPanel.GetComponent<CanvasGroup>().interactable = false;
                statsPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
            break;

            default:
                Debug.LogError("Current Menu Location not found.");
            break;
        }
    }

    //Enable Panel
    private void EnablePanel(int panel)
    {
        switch (panel)
        {
            //Main Menu
            case 0:
                mainMenuPanel.GetComponent<CanvasGroup>().interactable = true;
                mainMenuPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                mainMenuPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;

            //Level Select
            case 1:
                levelSelectPanel.GetComponent<CanvasGroup>().interactable = true;
                levelSelectPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                levelSelectPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;

            //Shop/Inventory
            case 2:
                shopPanel.GetComponent<CanvasGroup>().interactable = true;
                shopPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                shopPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;

            //Trophy
            case 3:
                trophyPanel.GetComponent<CanvasGroup>().interactable = true;
                trophyPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                trophyPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;

            //Statistics
            case 4:
                statsPanel.GetComponent<CanvasGroup>().interactable = true;
                statsPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
                statsPanel.GetComponent<CanvasGroup>().alpha = 1;
                break;

            default:
                Debug.LogError("Current Menu Location not found.");
                break;
        }
    }
}
