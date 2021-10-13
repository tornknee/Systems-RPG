using UnityEngine;

public class Conversation : MonoBehaviour
{
    [Header("Dialogue")]
    public string npcName;
    public string greeting;
    public string bye;
    public DialogueOption[] dialogueOptions;    
    
    [Header("Approval")]
    public float approval;
    public float friendThreshold;
    public float enemyThreshold;

    [Header("Quest")]
    public bool questGiver;
    public Quest quest;

    /// <summary>
    /// Launches dialogue loader
    /// </summary>
    public void Interact()
    {
        DialogueLoader.dialogueLoader.Load(this);
    }
    /// <summary>
    /// At present, just makes them angry at you
    /// </summary>
    public void Attacked()
    {
        approval -= 10;
    }
    
    //Checks character's approval against their friend/enemy threshold and returns appropriate status
    public string Friendly()
    {
        if(approval >= friendThreshold)
        {
            return "friend";
        }
        else if(approval <= enemyThreshold)
        {
            return "enemy";
        }
        else
        {
            return "neutral";
        }
    }
}

