using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : PickUpItem
{ 
    public override void Use()
    {
        base.Use();
    }

    public override void Move(ItemData item)
    {
        if (Menu.menu.invPanel.activeSelf)
        {
            int index = 1;
            Debug.Log("equipped " + item.itemName);
           
            switch (item.equipSlot)
            {
                    case ItemData.EquipSlot.hat:
                        index = 0;
                        break;
                    case ItemData.EquipSlot.leftHand:
                        index = 1;
                        break;
                    case ItemData.EquipSlot.rightHand:
                        index = 2;
                        break;
                    case ItemData.EquipSlot.robe:
                        index = 3;
                        break;
                    case ItemData.EquipSlot.boots:
                        index = 4;
                        break;
            }
            item.equipped = true;
            EquipManager.equip.FindItem(item);            
            EquipManager.equip.EquipSlotUpdate(index);

            Menu.menu.playerInv.ClearSlot(item.invSlot);
            Menu.menu.playerInv.items[item.invSlot] = new ItemData();

            EquipManager.equip.equipButtons[index].item.invSlot = index;
            EquipManager.equip.equippedItems[index] = this;
        }
        else
        {
            Trade.trade.Move(item);
        }
    }
}
