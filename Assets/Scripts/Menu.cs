using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu menu;
    public Transform questLogArea;
    public Text questLogText;
    Text currentText;

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
}
