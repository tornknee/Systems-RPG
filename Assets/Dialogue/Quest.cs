using System.Collections;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public string questDescription;
    public QuestObject questObject;

    [Header("Dialogue")]
    public string playerLine;
    public string neutralResponse;
    public string negativeResponse;

    public string completeLine;
    public string completeResponse;

    public string failedLine;
    public string failedResponse;

    [Header("Quest status")]
    public bool started;
    public bool completed;
    public bool failed;

    public float questApproval;
}