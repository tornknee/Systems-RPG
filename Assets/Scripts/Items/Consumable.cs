using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : PickUpItem
{
    public enum Stat
    { 
        health, mana 
    }
    public Stat stat;
    public float increaseAmount;


    /// <summary>
    /// Adds increaseAmount to relevant stat, i.e. health/mana
    /// Controls cooldown of consumables
    /// </summary>
    public override void Use()
    {
        int slot = data.invSlot;

        if(data.inv.items[slot].count>1)
        {
            if(ConsumablesBar.consumables.timer < 3)
            {
                Debug.Log("item cooldown");
            }
            else
            {
                Debug.Log(stat + " + " + increaseAmount);
                data.inv.items[slot].count--;
                data.inv.UpdateSlot(slot);
                ConsumablesBar.consumables.timer = 0;
            }
        }
        else
        {
            Debug.Log(stat + " + " + increaseAmount);
            data.inv.items[slot].count--;
            data.inv.ClearSlot(slot);
        }       
    }

    public override void Move(ItemData item)
    {
        if (Menu.menu.invPanel.activeSelf)
        {
            Trade.trade.AddConsumable(item);
            //Trade.trade.Move(this.data);
        }
        else if (Menu.menu.chestUI.activeSelf)
        {
                      
            Trade.trade.Move(item); 
        }
    }
}

