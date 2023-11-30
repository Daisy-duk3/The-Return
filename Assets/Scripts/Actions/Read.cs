using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {

        if (ReadItem(controller, controller.player.currentLocation.itemList, noun))
            return;



        if (ReadItem(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItem(GameController controller, List<Item> itemList, string noun)
    {
        foreach (Item item in itemList)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "The  " + noun + " does nothing";
                return true;
            }

        }
        return false;
    }
}
