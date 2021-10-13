using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPrompt : MonoBehaviour
{
    public static QuestPrompt questPrompt;
    public Text promptText;

    // Start is called before the first frame update
    void Awake()
    {      
        questPrompt = this;
    }

    public void Accepted()
    {
        DialogueLoader.dialogueLoader.StartCoroutine("GotQuest");
    }
    public void FillPromptText(Quest quest)
    {
        promptText.text = "Accept Quest: " + quest.questName;
    }
}
