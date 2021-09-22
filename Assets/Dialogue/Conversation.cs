using UnityEngine;

public class Conversation : MonoBehaviour
{
    public void Interact()
    {
        DialogueLoader.dialogueLoader.Load(this);
    }

    public string npcName;
    public string greeting;
    public DialogueOption[] dialogueOptions;
    public string bye;
    public float approval;
    public float friendThreshold;
    public float enemyThreshold;
    public bool isStore;
    public bool questGiver;

    public string Friendly()
    {
        if(approval>friendThreshold)
        {
            return "friend";
        }
        else if(approval < enemyThreshold)
        {
            return "enemy";
        }
        else
        {
            return "neutral";
        }
    }
}

