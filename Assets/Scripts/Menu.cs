using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu menu;

    public GameObject questLogPanel;
    public Transform questLogArea;
    public Text questLogText;

    public GameObject invPanel;

    Text currentText;

    public InventoryManager playerInv;

    private void Awake()
    {
        menu = this;      
    }

    public void PopulateQuestLog()
    {
        foreach(Quest quest in GameManager.gameM.questLog)
        {
            currentText = Instantiate(questLogText, questLogArea);
            currentText.text = quest.questName + ": " + quest.questDescription;
            if (quest.completed && !quest.failed)
            {
                currentText.text += " - Complete!";
            }
            else if (quest.failed)
            {
                currentText.text += " - Failed!";
            }
        }
    }
    public void EmptyQuestLog()
    {
        foreach(Transform item in questLogArea.transform)
        {
            Destroy(item.gameObject);
        }
    }
    public void ShowQuestLog()
    {
        if (invPanel.activeSelf)
        {
            invPanel.SetActive(false);
        }
        if (!questLogPanel.activeSelf)
        {
            questLogPanel.SetActive(true);
        }
        else
        {
            questLogPanel.SetActive(false);
        }
    }
    public void ShowInv()
    {
        if(questLogPanel.activeSelf)
        {
            questLogPanel.SetActive(false);
        }
        if (!invPanel.activeSelf)
        {
            invPanel.SetActive(true);
            foreach (ItemData item in playerInv.items)
            {
                playerInv.invButtons = GetComponentsInChildren<ClickableObject>();
                playerInv.UpdateSlot(item.invSlot);
            }
        }
        else
        {
            invPanel.SetActive(false);
        }
    }

    
}
