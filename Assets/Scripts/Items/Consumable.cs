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
    public override void Use()
    {
        int slot = data.invSlot;
        if(InventoryManager.invMan.items[slot].count>1)
        {
            Debug.Log(stat + " + " + increaseAmount);
            InventoryManager.invMan.items[slot].count--;
            InventoryManager.invMan.UpdateSlot(slot);
        }
        else
        {
            Debug.Log(stat + " + " + increaseAmount);
            InventoryManager.invMan.items[slot].count--;
            InventoryManager.invMan.ClearSlot(slot);
        }       
    }
}

