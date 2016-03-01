using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item
{
    private const string resourcePath = "MyItemDatabase/";
    public string itemName { get; set; }

    public int itemID { get; set; }

    public ItemType itemType { get; set; }

    public string itemDesc { get; set; }

    public int itemPrice { get; set; }

    public int itemAmount { get; set; }

    public Sprite itemIcon;

    public enum ItemType
    {
        Skin,
        Consumable,
        Achievement
    }

    //Constrcutor
    public Item(string name, int id, ItemType type, string description, int price)
    {
        itemName = name;
        itemType = type;
        itemDesc = description;
        itemPrice = price;
        itemAmount++; //Add to item count
        itemIcon = Resources.Load<Sprite>(resourcePath + type);  
    }

    public Item(Item item)
    {
        itemName = item.itemName;
        itemType = item.itemType;
        itemDesc = item.itemDesc;
        itemPrice = item.itemPrice;
        itemAmount = item.itemAmount;
        itemIcon = Resources.Load<Sprite>(resourcePath + item.itemType);  
    }
}