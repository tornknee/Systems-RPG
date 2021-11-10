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
    public int slot;
    /*/ add later potentially
    public int value;
    public float weight;
    /*/
    public void Use()
    {
        Debug.Log("used " + itemName);
    }
    public void Drop()
    {
        GameObject toDrop = Resources.Load("Prefabs/" + itemName) as GameObject;
        GameObject.Instantiate(toDrop);
        InventoryManager.invMan.ClearSlot(slot);
        Debug.Log("dropped" + itemName);
    }
}
