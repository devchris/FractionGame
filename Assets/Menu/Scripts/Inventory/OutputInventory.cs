using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OutputInventory : MonoBehaviour 
{
    //Other classes
    private Inventory inventory;

    //Child objects
    public Text[] invText;

    //Tracking current Items listed
    private int InventoryIndex;
    private int ItemsDisplayed; //Set the number of Items displayed at one time in the inventory screen

    private string typeSelected;

	// Use this for initialization
	void Start () 
    {
        typeSelected = "All";
        InventoryIndex = 0; //Set Default Index
        ItemsDisplayed = 0;
	    inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
    
    //Display Item Tooltip if mouses is over the selected Item
    public void showTooltip(int i)
    {
        invText[3].text = string.Format("<b>Name:</b>\n{0}\n\n<b>Type:</b>\n{1}\n\n<b>Price:</b>\n{2}\n\n<b>Description:</b>\n{3}", 
                                        inventory.GetItem(i).itemName, inventory.GetItem(i).itemType,
                                        inventory.GetItem(i).itemPrice, inventory.GetItem(i).itemDesc);
    }

    //Display the Item Sprites according to the Item Type being displayed
    public void UpdateItemSprites()
    {
        ItemsDisplayed = 0;

        //Set each item's image according to the type of the item
        for (int i = InventoryIndex; i < inventory.GetInventorySize() && ItemsDisplayed <= 2; i++)
        {
            if(i < invText.Length) //Clear Text Boxes
                invText[i].text = "";

            if (inventory.GetItem(i).itemType.ToString() == typeSelected || typeSelected == "All") //If type selected matches the item at that index
            {
                invText[ItemsDisplayed].text = "Name: " + inventory.GetItem(i).itemName; //Other information can be added

                ItemsDisplayed++; //Increase the number of items on screen

                switch (inventory.GetItem(i).itemType)
                {
                    case Item.ItemType.Skin:
                        break;

                    case Item.ItemType.Consumable:
                        break;

                    case Item.ItemType.Achievement:
                        break;

                    default:
                        Debug.Log("ItemType could not be found.");
                        break;
                }
            }
        }

        //Clean up
        if (invText[2].text == "" && ItemsDisplayed == 2)
            ScrollLeft();
    }

    //Get Item type to be displayed
    public void TypeSelector(string type)
    {
        typeSelected = type;
        InventoryIndex = 0;
        UpdateItemSprites();
    }

    public void ScrollRight()
    {
        //As long as the Index has not reached the end of the array or last text box is empty
        if(InventoryIndex < inventory.GetInventorySize() - 3 && invText[2].text != "")
            InventoryIndex++;

        UpdateItemSprites();
    }

    public void ScrollLeft()
    {
        //As long as the Index is higher than 0
        if (InventoryIndex > 0)
            InventoryIndex--;

        UpdateItemSprites();
    }

}
