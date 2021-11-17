using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PickUpItem : MonoBehaviour
{
    public ItemData data = new ItemData();

    public virtual void PickedUp()
    {
        int slot;
        if(data.stackable)
        {
            Debug.Log("stackable item contacted, searching for available slot");
            slot = InventoryManager.invMan.FindAvailableStackSlot(this);
            if(slot >= 0)
            {
                InventoryManager.invMan.items[slot].count += data.count;
                //InventoryManager.invMan.UpdateSlot(slot);
                Debug.Log("An item has been added to a stack");
                Destroy(gameObject);
                return;
            }
            else
            {
                Debug.Log("No slot with enough space found");
            }
        }
        Debug.Log("searching for empty slot");
        slot = InventoryManager.invMan.FindEmptySlot(this);        
        if (slot >=0)
        {
            InventoryManager.invMan.items[slot] = data;
            InventoryManager.invMan.items[slot].invSlot = slot;
            InventoryManager.invMan.pickUps[slot] = this;
            //InventoryManager.invMan.UpdateSlot(slot);
            Debug.Log("an item has been picked up into a new slot");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No valid slot was found");
        }
    }

    public virtual void Use()
    {
        Debug.Log(data.itemName + " used");
    }
}
