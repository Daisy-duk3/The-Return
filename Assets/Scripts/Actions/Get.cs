using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Actions/Get")]
public class Get : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        Debug.Log("Starting Get action");
        foreach (Item item in controller.player.currentLocation.itemList)
        {
            Debug.Log("Checking item: " + item.itemName);
            Debug.Log("Comparing with noun: " + noun);
            if (item.itemEnabled && item.itemName.Equals(noun, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("Match found: " + noun);
                
                controller.player.inventory.Add(item);
                controller.player.currentLocation.itemList.Remove(item);
                controller.currentText.text = "You take the " + noun;
                return;

            }
        }
        Debug.Log("Get action completed");
    }
}