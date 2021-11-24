using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public ItemData[] items = new ItemData[12];
    public PickUpItem[] pickUps = new PickUpItem[12];   
    public ClickableObject[] invButtons;
    //public static InventoryManager invMan;
    public Image defaultSprite;

    void Start()
    {

        /*/if (invMan == null)
        {
            invMan = this;
        }
        else
        {
            Destroy(this);
        }/*/
        //invButtons = GetComponentsInChildren<ClickableObject>();
    }

    public int FindAvailableStackSlot(PickUpItem pickup)
    {
        for(int i = 0; i<items.Length; i++)
        {
            if(pickup.data.itemName == items[i].itemName && items[i].count <= 10 - pickup.data.count)
            {
                Debug.Log("available slot found");
                return (i);
            }
        }
        return -1;
    }

    public int FindEmptySlot()
    {
        for(int i = 0; i<items.Length;i++)
        {
            if(items[i].itemName == "" || items[i].itemName == null )
            {
                return (i);
            }
        }
        return -1;
    }

    public void UpdateSlot(int index)
    {
        items[index].inv = this;
        //items[index].invSlot = index;
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
        invButtons[index].GetComponent<ClickableObject>().rightClick = pickUps[index].Drop;
               
        invButtons[index].GetComponent<ClickableObject>().item = items[index];
        invButtons[index].GetComponent<ClickableObject>().middleClick = pickUps[index].Move;

    }
    public void ClearSlot(int index)
    {
        items[index] = new ItemData();
        invButtons[index].item = new ItemData();
        pickUps[index] = null;

        //update icon
        invButtons[index].GetComponent<Image>().sprite = defaultSprite.sprite;
        invButtons[index].GetComponent<Image>().color = defaultSprite.color;

        //update text
        invButtons[index].GetComponentInChildren<Text>().text =  "";
        
        //update function
        invButtons[index].GetComponent<ClickableObject>().leftClick = null;
        invButtons[index].GetComponent<ClickableObject>().rightClick = null;
        invButtons[index].GetComponent<ClickableObject>().middleClick = null;
    }


    public void Move(ItemData item)
    {
        Debug.Log("moving" + item.itemName);
    }
}
