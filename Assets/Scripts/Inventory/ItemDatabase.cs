using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {

    public List<Item> items = new List<Item>();

    private void Start()
    {
        ItemDataBaseSetup();
    }
    private void ItemDataBaseSetup()
    {
        // Name , Description, Sprite File Name, Sprite Name, ID
        items.Add(new Item("Wood", "A piece of wood, WANT MORE DO YOU WANT FROM ME!?", "Wood", "Wood", 0));
        items.Add(new Item("Stone", "A piece of stone", "Stone", "Stone" , 1));
        items.Add(new Item("Axe", "Basic hand axe", "Axe", "Axe", 2));
        items.Add(new Item("Pickaxe", "Basic pick axe", "Pickaxe", "Pickaxe", 3));
    }
    public Item GetItemByID(int id)
    {
        foreach(Item itm in items)
        {
            if(itm.itemID == id)
            {
                return itm;
            }
        }
        Debug.LogError("Can't find item by ID!");
        return null;
    }
}
