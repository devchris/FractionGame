using UnityEngine;
using System.Collections;

public class SwitchTab : MonoBehaviour 
{
    public CanvasGroup inventory;
    public CanvasGroup shop;

    void Start()
    {

    }

    public void SwitchToShop()
    {
        EnableInventory(false);
        EnableShop(true);
    }

    public void SwitchToInventory()
    {
        EnableShop(false);
        EnableInventory(true);
    }

    private void EnableShop(bool enabled)
    {
        if(enabled)
        {
            shop.alpha = 1;
            shop.blocksRaycasts = true;
            shop.interactable = true;
        }
        else
        {
            shop.alpha = 0;
            shop.blocksRaycasts = false;
            shop.interactable = false;
        }
    }

    private void EnableInventory(bool enabled)
    {
        if(enabled)
        {
            inventory.alpha = 1;
            inventory.blocksRaycasts = true;
            inventory.interactable = true;
        }
        else
        {
            inventory.alpha = 0;
            inventory.blocksRaycasts = false;
            inventory.interactable = false;
        }
    }
}
