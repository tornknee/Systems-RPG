using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{   
    public string itemName;
    public bool stackable;
    public int count;
    public Sprite icon;
    public int invSlot;
    
    public int value;
    public InventoryManager inv;

    public enum EquipSlot
    {
        hat, leftHand, rightHand, robe, boots
    }
    public EquipSlot equipSlot;
    public bool equipped;
}
