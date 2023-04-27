using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookPot_Mono : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        FoodItem_Mono food = col.gameObject.GetComponent<FoodItem_Mono>();

        if (food)
        {
            food.isCooking = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        FoodItem_Mono food = col.gameObject.GetComponent<FoodItem_Mono>();

        if (food)
        {
            food.isCooking = false;
        }
    }
}
