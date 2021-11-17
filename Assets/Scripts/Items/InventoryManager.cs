using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public ItemData[] items = new ItemData[12];
    public PickUpItem[] pickUps = new PickUpItem[12];   
    public ClickableObject[] invButtons;
    public static InventoryManager invMan;

    // Start is called before the first frame update
    void Start()
    {        
        if (invMan == null)
        {
            invMan = this;
        }
        else
        {
            Destroy(this);
        }
        //invButtons = GetComponentsInChildren<ClickableObject>();
    }

    public int FindAvailableStackSlot(PickUpItem item)
    {
        for(int i = 0; i<items.Length; i++)
        {
            if(item.data.itemName == items[i].itemName && items[i].count <= 10 - item.data.count)
            {
                Debug.Log("available slot found");
                return (i);
            }
        }
        return -1;
    }

    public int FindEmptySlot(PickUpItem item)
    {
        for(int i = 0; i<invMan.items.Length;i++)
        {
            if(invMan.items[i].itemName == "" || invMan.items[i].itemName == null )
            {
                return (i);
            }
        }
        return -1;
    }

    public void UpdateSlot(int index)
    {
        // items[index].invSlot = index;
        //update icon
        invButtons[index].GetComponent<Image>().sprite = items[index].icon;
        invButtons[index].GetComponent<Image>().color = Color.white;

         //update text
         if (items[index].stackable)
         {
             invButtons[index].GetComponentInChildren<Text>().text = items[index].count + "";
         }
         else
         {
             invButtons[index].GetComponentInChildren<Text>().text = "";
         }

        //update function        
        invButtons[index].GetComponent<ClickableObject>().leftClick = pickUps[index].Use;
        invButtons[index].GetComponent<ClickableObject>().rightClick = items[index].Drop;      
    }
    public void ClearSlot(int index)
    {
        items[index] = new ItemData();

        //update icon
        invButtons[index].GetComponent<Image>().sprite = null;
        invButtons[index].GetComponent<Image>().color = Color.white;

        //update text
        invButtons[index].GetComponentInChildren<Text>().text =  "";
        
        //update function
        invButtons[index].GetComponent<ClickableObject>().leftClick = null;
        invButtons[index].GetComponent<ClickableObject>().rightClick = null;
    }
}
