using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestObject : MonoBehaviour
{
    public Quest quest;

    /// <summary>
    /// Interacts with quest object
    /// If quest is started and not failed then makes it completed
    /// </summary>
    public void Interact()
    {  
        if (quest.started && !quest.failed)
        {
            StartCoroutine(Success());
            quest.completed = true;
        }
    }
    public void Attacked()
    {
        quest.failed = true;
        gameObject.SetActive(false);
    }
    IEnumerator Success()
    {
        GameManager.gameM.alert.SetActive(true);
        Text alertText = GameManager.gameM.alert.GetComponent<Text>();
        alertText.text = "Found " + quest.questObject.name;
        yield return new WaitForSeconds(2f);
        GameManager.gameM.alert.SetActive(false);
    }
}
