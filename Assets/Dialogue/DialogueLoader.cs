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
    public bool inConversation;

    public static DialogueLoader dialogueLoader;
    public Scrollbar scrollBar;

    Text currentText;

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

    public void Load(Conversation convo)
    {
        dialogueBox.SetActive(true);

        currentConvo = convo;
        inConversation = true;

        currentText = Instantiate(npcText, buttonArea);
        currentText.text = currentConvo.greeting;

        int i = 0;
        GameObject currentButton;
        foreach (DialogueOption option in currentConvo.dialogueOptions)
        {
            currentButton = Instantiate(buttonPrefab, buttonArea);
            currentButton.GetComponentInChildren<Text>().text = option.playerLine;

            int j = i;

            currentButton.GetComponent<Button>().onClick.AddListener(delegate {Clicked(j);} );
            i++;
        }

        //spawn in goodbye button
        currentButton = Instantiate(buttonPrefab, buttonArea);
        currentButton.GetComponentInChildren<Text>().text = "Goodbye";
        currentButton.GetComponent<Button>().onClick.AddListener(delegate { EndConversation(); });
        Debug.Log(currentConvo.greeting);
    }

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
    void EndConversation()
    {
        Debug.Log(currentConvo.bye);
        foreach(Transform item in buttonArea.transform)
        {
            Destroy(item.gameObject);
        }
        currentConvo = null;
        inConversation = false;
        dialogueBox.SetActive(false);
    }

}
