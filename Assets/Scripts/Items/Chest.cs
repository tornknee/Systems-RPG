using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestUI;
    public GameObject myInvPanel;
    public GameObject chestInvPanel;
    public InventoryManager chest;

    private void Start()
    {
        chest = GetComponent<InventoryManager>();
    }

    /// <summary>
    /// Brings up chest and player inventory panels and populates them
    /// also tells trade manager which inventory managers to look at, i.e. player's and chest's
    /// </summary>
    public void Interact()
    {
        chestUI.SetActive(true);
        GameManager.gameM.paused = true;

        for (int i = 0; i < chest.pickUps.Length; i++)
        {           
            if(chest.pickUps[i] != null)
            {
                Debug.Log("item found");
                chest.items[i] = chest.pickUps[i].data;
                chest.items[i].invSlot = i;
                Destroy(chest.pickUps[i].gameObject);
            }
            Debug.Log("no item");
        }
        foreach (ItemData item in chest.items)
        {
            chest.invButtons = chestInvPanel.GetComponentsInChildren<ClickableObject>();
            chest.UpdateSlot(item.invSlot);
        }
        foreach (ItemData item in Menu.menu.playerInv.items)
        {
            Menu.menu.playerInv.invButtons = myInvPanel.GetComponentsInChildren<ClickableObject>();
            Menu.menu.playerInv.UpdateSlot(item.invSlot);
        }
        Trade.trade.StartTrade(this);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            chestUI.SetActive(false);
            GameManager.gameM.paused = false;
        }
    }
}
