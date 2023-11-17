using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.itemList, noun))
            return;

        controller.currentText.text = "As the wind whips your hair, nothing was said...";
    }

    private bool SayToItem(GameController controller, List<Item>itemList, string noun)
    {
        foreach(Item item in itemList)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanTalkToItem(controller, item))
                {
                    if (item.InteractWith(controller, "say", noun))
                        return true;
                }
            }
           
            
        }
        return false;
    }

}
