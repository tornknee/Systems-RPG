using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class PickUpItem : MonoBehaviour
{
    public ItemData data = new ItemData();

    /// <summary>
    /// Checks inventory manager for  available slots, if found adds itemData to slot and destroys object.
    /// </summary>
    public virtual void PickedUp()
    {
        int slot;
        if(data.stackable)
        {
            Debug.Log("stackable item contacted, searching for available slot");
            slot = Menu.menu.playerInv.FindAvailableStackSlot(this);
            if(slot >= 0)
            {
                Menu.menu.playerInv.items[slot].count += data.count;
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
        slot = Menu.menu.playerInv.FindEmptySlot();        
        if (slot >= 0)
        {
            Menu.menu.playerInv.items[slot] = data;
            Menu.menu.playerInv.items[slot].invSlot = slot;
            Menu.menu.playerInv.pickUps[slot] = gameObject.GetComponent<PickUpItem>();
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

    /// <summary>
    /// Removes 1 count of item and instantiates in world. If count is reduced to 0 or object is not stackable clears inventory button.
    /// </summary>
    public void Drop()
    {
        GameObject toDrop = Resources.Load("Prefabs/" + data.itemName) as GameObject;
        Vector3 dropPos = PlayerPickup.playerPickup.gameObject.transform.position;
        dropPos.y += 3;
        dropPos.x += 1;
        dropPos.z += 1;
        GameObject.Instantiate(toDrop, dropPos, Quaternion.identity);
        if(data.stackable)
        {
            data.count--;
            Menu.menu.playerInv.UpdateSlot(data.invSlot);
            if(data.count<=0)
            {
                data.inv.ClearSlot(data.invSlot);
            }
        }
        else
        {
            data.inv.ClearSlot(data.invSlot);
        }
        
        Debug.Log("dropped" + data.itemName);
    }

    public virtual void Move(ItemData item)
    {
        Debug.Log("moving" + item.itemName);
    }
}
