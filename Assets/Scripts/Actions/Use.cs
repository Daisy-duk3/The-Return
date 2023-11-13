using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //use items in room 
        if (UseItems(controller, controller.player.currentLocation.itemList, noun))
            return;


        //use items in inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no "+noun;
    }

    private bool UseItems(GameController controller, List<Item> itemList, string noun)
    {
        foreach (Item item in itemList)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller, item))
                {
                        if (item.InteractWith(controller, "use"))
                             return true;
                }
                controller.currentText.text = "The  " +noun+ " does nothing";
                return true;
            }
            
        }
        return false;
    }
}
