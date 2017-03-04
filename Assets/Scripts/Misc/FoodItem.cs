using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour {

    public enum HungerType {Food, Water };
    public HungerType hungerType = new HungerType();
    public float foodAmountToAdd = 25f;


    public void DestoryObject()
    {
        Destroy(gameObject);
    }

}
