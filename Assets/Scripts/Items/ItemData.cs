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

    public void Drop()
    {
        GameObject toDrop = Resources.Load("Prefabs/" + itemName) as GameObject;
        GameObject.Instantiate(toDrop);
        InventoryManager.invMan.ClearSlot(invSlot);
        Debug.Log("dropped" + itemName);
    }
}
