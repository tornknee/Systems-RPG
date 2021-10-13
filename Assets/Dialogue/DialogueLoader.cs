using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueLoader : MonoBehaviour
{
    public Conversation currentConvo;
    public GameObject buttonPrefab;
    public GameObject dialogueBox;
    public Text npcText;
    public Transform buttonArea;
    //public bool inConversation;

    public static DialogueLoader dialogueLoader;
    public Scrollbar scrollBar;
        
    public Text currentText;

    private void Start()
    {     
        if (dialogueLoader != null)
        {
            Destroy(gameObject);
        }
        else
        {
            dialogueLoader = this;
        }
    }

    /// <summary>
    /// Activates dialogue box and spawns in appropriate text and buttons as taken from the character's conversation script
    /// </summary>
    /// <param name="convo">Conversation script attached to character</param>
    public void Load(Conversation convo)
    {        
        GameObject currentButton;
        dialogueBox.SetActive(true);
        scrollBar.value = 1;

        currentConvo = convo;
        GameManager.gameM.paused = true;

        //Instantiate greeting
        currentText = Instantiate(npcText, buttonArea);
        currentText.text = currentConvo.greeting;

         int i = 0;
         //Go through each dialogue option in their conversation script
         foreach (DialogueOption option in currentConvo.dialogueOptions)
         {
            //Spawn in buttons for each option
            currentButton = Instantiate(buttonPrefab, buttonArea);
            currentButton.GetComponentInChildren<Text>().text = option.playerLine;
            
            //Make each button do what it needs to when clicked
            int j = i;
            currentButton.GetComponent<Button>().onClick.AddListener(delegate {Clicked(j); });
            i++;
         }    
         
         //Check if character has quest && that the quest is not already started or failed
         //If so spawn in quest dialogue
         if (convo.questGiver && !convo.quest.started && !convo.quest.failed)
         {
            currentButton = Instantiate(buttonPrefab, buttonArea);
            currentButton.GetComponentInChildren<Text>().text = currentConvo.quest.playerLine;
            currentButton.GetComponent<Button>().onClick.AddListener(delegate { GiveQuest(); });
         }

         //Checks if they are questgiver && quest is completed
         //Spawns in quest completed dialogue
         else if (convo.questGiver && convo.quest.completed && !convo.quest.failed)
         {
             currentButton = Instantiate(buttonPrefab, buttonArea);
             currentButton.GetComponentInChildren<Text>().text = currentConvo.quest.completeLine;
             currentButton.GetComponent<Button>().onClick.AddListener(delegate { FinishQuest(); });
         }

         //Checks for questGiver && quest is failed
         //Spawns in failed dialogue
         else if(convo.questGiver && convo.quest.failed)
         {
            currentButton = Instantiate(buttonPrefab, buttonArea);
            currentButton.GetComponentInChildren<Text>().text = currentConvo.quest.failedLine;
            currentButton.GetComponent<Button>().onClick.AddListener(delegate { FailQuest(); });
         }

        //Spawn in goodbye button
        currentButton = Instantiate(buttonPrefab, buttonArea);
        currentButton.GetComponentInChildren<Text>().text = "Goodbye";
        currentButton.GetComponent<Button>().onClick.AddListener(delegate {EndConversation(); });
    }

    /// <summary>
    /// Checks approval as returned from conversation script and displays appropriate response
    /// </summary>
    /// <param name="buttonNum">Assigned when buttons are spawned</param>
    void Clicked(int buttonNum)
    {       
        string approval = currentConvo.Friendly();
        switch (approval)
        {
            case "friend":
                currentText.text = currentConvo.dialogueOptions[buttonNum].positiveResponse;
                break;
            case "neutral":
                currentText.text = currentConvo.dialogueOptions[buttonNum].neutralResponse;
                break;
            case "enemy":
                currentText.text = currentConvo.dialogueOptions[buttonNum].negativeResponse;
                break;
        }       
        scrollBar.value = 1;       
    }

    /// <summary>
    /// Destroys everything in the dialogue box and deactivates it
    /// </summary>
    void EndConversation()
    {
        ClearDialogue();
        currentConvo = null;
        GameManager.gameM.paused = false;
        dialogueBox.SetActive(false);
    }
    void ClearDialogue()
    {
        foreach (Transform item in buttonArea.transform)
        {
            Destroy(item.gameObject);
        }
    }

    //I started building this quest stuff before I implemented the GameManager, I feel like it should be over there, but now it's more pain than it's worth
    /// <summary>
    /// Displays quest related response
    /// </summary>
    void GiveQuest()
    {
        string approval = currentConvo.Friendly();
        if(approval == "friend" || approval =="neutral")
        {
            currentText.text = currentConvo.quest.neutralResponse;
            currentConvo.quest.started = true;
            GameManager.gameM.prompt.SetActive(true);
            QuestPrompt.questPrompt.FillPromptText(currentConvo.quest);
        }
        else if(approval == "enemy")
        {
            currentText.text = currentConvo.quest.negativeResponse;
        }
        scrollBar.value = 1;       
    }

    /// <summary>
    /// Displays finished response, then removes their questgiver status.
    /// Increases character approval by questApproval
    /// </summary>
    void FinishQuest()
    {
        currentText.text = currentConvo.quest.completeResponse;
        StartCoroutine(QuestComplete());
        currentConvo.approval += currentConvo.quest.questApproval;
        currentConvo.questGiver = false;
        GameManager.gameM.questLog.Remove(currentConvo.quest);
        scrollBar.value = 1;
    }
    /// <summary>
    /// Displays failed response, then removes their questgiver status.
    /// Decreases character approval by questApproval
    /// </summary>
    void FailQuest()
    {
        currentText.text = currentConvo.quest.failedResponse;
        StartCoroutine(QuestFailed());
        currentConvo.approval -= currentConvo.quest.questApproval;
        currentConvo.questGiver = false;
        scrollBar.value = 1;
    }

    /// <summary>
    /// Simple coroutine to flash up a new quest message
    /// </summary>
    public IEnumerator GotQuest()
    {
        GameManager.gameM.questLog.Add(currentConvo.quest);
        GameManager.gameM.alert.SetActive(true);   
        
        Text alertText = GameManager.gameM.alert.GetComponent<Text>();
        alertText.text = "New Quest: " + currentConvo.quest.questName;
        ClearDialogue();
        Load(currentConvo);
        yield return new WaitForSeconds(2f);

        GameManager.gameM.alert.SetActive(false);        
        yield return null;        
    }

    public IEnumerator QuestComplete()
    {
        GameManager.gameM.alert.SetActive(true);

        Text alertText = GameManager.gameM.alert.GetComponent<Text>();
        alertText.text = "Quest: " + currentConvo.quest.questName + " Complete";       
        yield return new WaitForSeconds(2f);

        alertText.text = currentConvo.gameObject.name + " is very pleased";
        ClearDialogue();
        Load(currentConvo);
        yield return new WaitForSeconds(2f);

        GameManager.gameM.alert.SetActive(false);       
        yield return null;
    }

    public IEnumerator QuestFailed()
    {
        GameManager.gameM.alert.SetActive(true);

        Text alertText = GameManager.gameM.alert.GetComponent<Text>();
        alertText.text = "Quest: " + currentConvo.quest.questName + " failed";
        yield return new WaitForSeconds(2f);

        alertText.text = currentConvo.gameObject.name + " is very angry";
        ClearDialogue();
        Load(currentConvo);
        yield return new WaitForSeconds(2f);

        GameManager.gameM.alert.SetActive(false);      
        yield return null;
    }
}
