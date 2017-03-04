using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Item {

    public string itemName;
    public string itemDesc;
    public Sprite itemSprite;
    public string itemSpriteName;
    public int itemID;


    public Item(string name, string desc,string spriteFileName,string spriteName, int id)
    {
        itemName = name;
        itemDesc = desc;
        itemSprite = Resources.Load<Sprite>("ItemIcons/" + spriteFileName);
        itemSpriteName = spriteName;
        itemID = id;
    }
    public Item()
    {

    }
}
