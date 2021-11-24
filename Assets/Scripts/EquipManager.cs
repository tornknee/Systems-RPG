using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquipManager : MonoBehaviour
{
    public static EquipManager equip;
    public ClickableObject[] equipButtons = new ClickableObject[5];
    public PickUpItem[] equippedItems = new PickUpItem[5];
    int invSlot;
    public Image defaultSprite;


    //I've come to realise that this whole class is kinda unneccessary, as the equipment could have just had it's own inventory manager 
    //And then it largely just would have used functions I already had, but I built it and it works and I don't have time to scrap it and start over.
    private void Start()
    {

        if (equip == null)
        {
            equip = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void EquipSlotUpdate(int index)
    {
        ItemData item = Menu.menu.playerInv.items[invSlot];
        //update icon
        equipButtons[index].GetComponent<Image>().sprite = item.icon;
        equipButtons[index].GetComponent<Image>().color = Color.white;
        equipButtons[index].item = item;
        equipButtons[index].GetComponent<ClickableObject>().item = item;
        equipButtons[index].GetComponent<ClickableObject>().middleClick = Unequip;
        
    }    

    public void FindItem(ItemData item)
    {
        invSlot = item.invSlot;
    }

    public void Unequip(ItemData item)
    {
        equipButtons[item.invSlot].item = new ItemData();
  
        //update icon
        equipButtons[item.invSlot].GetComponent<Image>().sprite = defaultSprite.sprite;
        equipButtons[item.invSlot].GetComponent<Image>().color = defaultSprite.color;

        //update text
        equipButtons[item.invSlot].GetComponentInChildren<Text>().text = "";

        //update function
        equipButtons[item.invSlot].GetComponent<ClickableObject>().middleClick = null;

        int slot;
        Debug.Log("searching for empty slot");
        slot = Menu.menu.playerInv.FindEmptySlot();
        if (slot >= 0)
        {
            Menu.menu.playerInv.pickUps[slot] = equippedItems[item.invSlot];
            equip.equippedItems[item.invSlot] = null;
            Menu.menu.playerInv.items[slot] = item;
            Menu.menu.playerInv.items[slot].invSlot = slot;
            Debug.Log("an item has been picked up into a new slot");
            Menu.menu.playerInv.UpdateSlot(slot);
        }
        else
        {
            Debug.Log("No valid slot was found");
        }

    }
}
