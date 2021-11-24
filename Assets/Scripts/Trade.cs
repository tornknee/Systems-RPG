using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trade : MonoBehaviour
{
    public InventoryManager playerInv;
    public InventoryManager chestInv;
    public static Trade trade;
    void Start()
    {
        trade = this;
    }

    public void StartTrade(Chest chest)
    {
        playerInv = Menu.menu.playerInv;
        chestInv = chest.chest;
    }
    public void AddConsumable()
    {
        playerInv = Menu.menu.playerInv;
        chestInv = ConsumablesBar.consumables.consumablesInv; 
    }

    public void Move(ItemData item)
    {
            Debug.Log("moving" + item.itemName);
            InventoryManager inv1;
            InventoryManager inv2;
            if (item.inv == playerInv)
            {
                inv1 = playerInv;
                inv2 = chestInv;
            }
            else
            {
                inv1 = chestInv;
                inv2 = playerInv;
            }

            int slot = 0;
            
            if (item.stackable)
            {
                slot = inv2.FindAvailableStackSlot(inv1.pickUps[item.invSlot]);
                Debug.Log("stackable item contacted, searching for available slot");
                if (slot >= 0)
                {
                    inv2.items[slot].count += item.count;
                    inv2.pickUps[slot] = inv1.pickUps[item.invSlot];
                    Debug.Log("An item has been added to a stack");
                    inv2.UpdateSlot(slot);
                    inv1.ClearSlot(item.invSlot);
                    return;
                }
                else
                {
                    Debug.Log("No slot with enough space found");
                }               
            }
            Debug.Log("searching for empty slot");
            slot = inv2.FindEmptySlot();
            Debug.Log(slot);
            if (slot >= 0)
            {
                
                Debug.Log(item.invSlot);
                inv2.pickUps[slot] = inv1.pickUps[item.invSlot];
                inv1.pickUps[item.invSlot] = null;
            inv1.ClearSlot(item.invSlot);

            inv2.items[slot] = item;
                inv2.items[slot].invSlot = slot;
                inv2.UpdateSlot(slot);

                Debug.Log("an item has been picked up into a new slot");
            }
            else
            {
                Debug.Log("No valid slot was found");
            }
    }
}
