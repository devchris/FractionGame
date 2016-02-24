using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InventoryGUI : MonoBehaviour
{
    private bool inventoryToggle = false;
    private Rect inventoryRect = new Rect(300, 100, 410, 410);

    bool usingSlider;

    static public Dictionary<int, string> InventoryNameDictionary = new Dictionary<int, string>()
        {
            {0, null},
            {1, null},
            {2, null},
            {3, null},
            {4, null},
            {5, null}
        };

    static public List<int> dictonaryAmounts = new List<int>()
    {
        0,
        0,
        0,
        0,
        0,
        0
    };

    ItemClass itemObject = new ItemClass();

    void Update()
    {


        if (usingSlider == true)
        {
            FractionManager.score -= 1;
            dictonaryAmounts[0] -= 1;
            if (dictonaryAmounts[0] == 0)
                InventoryNameDictionary[0] = string.Empty;
        }

        if (Input.touchCount == 0)
            usingSlider = false;

        if (GUILayout.Button(InventoryNameDictionary[1]) && Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            FractionManager.score -= 2;
            dictonaryAmounts[1] -= 1;
            if (dictonaryAmounts[1] == 0)
                InventoryNameDictionary[1] = string.Empty;
        }

        else if (GUILayout.Button(InventoryNameDictionary[2]) && Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            FractionManager.score -= 3;
            dictonaryAmounts[2] -= 1;
            if (dictonaryAmounts[2] == 0)
                InventoryNameDictionary[2] = string.Empty;
        }

        else if (GUILayout.Button(InventoryNameDictionary[3]) && Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            FractionManager.score -= 4;
            dictonaryAmounts[3] -= 1;
            if (dictonaryAmounts[3] == 0)
                InventoryNameDictionary[3] = string.Empty;
        }

        else if (GUILayout.Button(InventoryNameDictionary[4]) && Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            FractionManager.score -= 5;
            dictonaryAmounts[4] -= 1;
            if(dictonaryAmounts[4] == 0)
                InventoryNameDictionary[4] = string.Empty;
        }

        else if (GUILayout.Button(InventoryNameDictionary[5]) && Input.GetKeyDown(KeyCode.Mouse1) == true)
        {
            FractionManager.score -= 6;
            dictonaryAmounts[5] -= 1;
            if (dictonaryAmounts[5] == 0)
                InventoryNameDictionary[5] = string.Empty;
        }

    }

    void OnGUI()
    {
        inventoryToggle = GUI.Toggle(new Rect(50, 30, 150, 75), inventoryToggle, "Inventory");

        if(inventoryToggle)
        {
            inventoryRect = GUI.Window(0, inventoryRect, inventoryMethod, "Inventory");
        }
    }

    void inventoryMethod(int windowId)
    {

        /*/Display at start Dictionary ==> Start Empty
        InventoryNameDictionary[1] = cog16.name;
        InventoryNameDictionary[2] = cog26.name;
        InventoryNameDictionary[3] = cog36.name;
        InventoryNameDictionary[4] = cog46.name;
        InventoryNameDictionary[5] = cog56.name;
        InventoryNameDictionary[6] = cog66.name;*/

        GUILayout.BeginArea(new Rect(5, 50, 400, 400));

        GUILayout.BeginHorizontal();
        GUILayout.Button(InventoryNameDictionary[0], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[0].ToString(), GUILayout.Height(50));

        GUILayout.Button(InventoryNameDictionary[1], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[1].ToString(), GUILayout.Height(50));


        GUILayout.Button(InventoryNameDictionary[2], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[2].ToString(), GUILayout.Height(50));
        GUILayout.EndHorizontal();


        GUILayout.BeginHorizontal();
        GUILayout.Button(InventoryNameDictionary[3], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[3].ToString(), GUILayout.Height(50));

        GUILayout.Button(InventoryNameDictionary[4], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[4].ToString(), GUILayout.Height(50));

        GUILayout.Button(InventoryNameDictionary[5], GUILayout.Height(50));
        GUILayout.Box(dictonaryAmounts[5].ToString(), GUILayout.Height(50));

        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }
}
