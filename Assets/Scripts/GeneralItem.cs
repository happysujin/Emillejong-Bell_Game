using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralItem : Item
{
    public override void useItem()
    {
        DatabaseManager.instance.NewCurrentItemID(itemID);
        Inventory.instance.goSetactive(false);
    }

}