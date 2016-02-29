using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loot : MonoBehaviour {

    public Texture2D i1;
    public int fractionValue;
    public GameObject target;

    ItemClass itemObject = new ItemClass();

    private Ray mouseRay;
    private RaycastHit rayHit;

    /*private Dictionary<int, string> lootDictionary = new Dictionary<int, string>()
    {
        {1, null}
    };*/
	
	void Start ()
    {
        
	}

	void Update ()
    {
        /*mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetButtonDown("Fire1"))
        {
            Physics.Raycast(mouseRay, out rayHit, 10);
            if (rayHit.collider.transform.tag == "PickUp")
            {
                //la fel ca mai sus ca sa le adaug la mine in inventory
                /////////////////////////
                InventoryGUI.InventoryNameDictionary[1] = itemObject.cog16.name;
                InventoryGUI.dictonaryAmounts[0] += 1;
                /////////////////////////

                FractionManager.score += fractionValue;
                target.SetActive(false);
            }
        }*/
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FractionManager.score += fractionValue;
            target.SetActive(false);

            //la fel ca mai sus ca sa le adaug la mine in inventory
            /////////////////////////
            if (fractionValue == 1)
            {
                itemObject.cog16.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[0] = itemObject.cog16.icon;
                InventoryGUI.dictonaryAmounts[0] += 1;
            }

            else if (fractionValue == 2)
            {
                itemObject.cog26.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[1] = itemObject.cog26.icon;
                InventoryGUI.dictonaryAmounts[1] += 1;
            }

            else if (fractionValue == 3)
            {
                itemObject.cog36.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[2] = itemObject.cog36.icon;
                InventoryGUI.dictonaryAmounts[2] += 1;
            }

            else if (fractionValue == 4)
            {
                itemObject.cog46.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[3] = itemObject.cog46.icon;
                InventoryGUI.dictonaryAmounts[3] += 1;
            }

            else if (fractionValue == 5)
            {
                itemObject.cog56.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[4] = itemObject.cog56.icon;
                InventoryGUI.dictonaryAmounts[4] += 1;
            }

            else if (fractionValue == 6)
            {
                itemObject.cog66.SetIcon(i1);
                InventoryGUI.InventoryNameDictionary[5] = itemObject.cog66.icon;
                InventoryGUI.dictonaryAmounts[5] += 1;
            }
            /////////////////////////
        }
    }

}
