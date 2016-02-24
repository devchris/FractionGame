using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Loot : MonoBehaviour {

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
                InventoryGUI.InventoryNameDictionary[0] = itemObject.cog16.name;
                InventoryGUI.dictonaryAmounts[0] += 1;
            }

            else if (fractionValue == 2)
            {
                InventoryGUI.InventoryNameDictionary[1] = itemObject.cog26.name;
                InventoryGUI.dictonaryAmounts[1] += 1;
            }

            else if (fractionValue == 3)
            {
                InventoryGUI.InventoryNameDictionary[2] = itemObject.cog36.name;
                InventoryGUI.dictonaryAmounts[2] += 1;
            }

            else if (fractionValue == 4)
            {
                InventoryGUI.InventoryNameDictionary[3] = itemObject.cog46.name;
                InventoryGUI.dictonaryAmounts[3] += 1;
            }

            else if (fractionValue == 5)
            {
                InventoryGUI.InventoryNameDictionary[4] = itemObject.cog56.name;
                InventoryGUI.dictonaryAmounts[4] += 1;
            }

            else if (fractionValue == 6)
            {
                InventoryGUI.InventoryNameDictionary[5] = itemObject.cog66.name;
                InventoryGUI.dictonaryAmounts[5] += 1;
            }
            /////////////////////////
        }
    }

}
