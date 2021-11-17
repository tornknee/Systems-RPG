using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameM;
    public GameObject alert;
    public GameObject menu;
    public GameObject prompt;
    public List<Quest> questLog = new List<Quest>();
    public bool paused;

    private void Start()
    {
        if (gameM != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameM = this;
        }
    }
    void Update()
    {
        MenuActive();
    }
    public void MenuActive()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
                Menu.menu.PopulateQuestLog();
                GameManager.gameM.paused = true;
            }
            else
            {              
                menu.SetActive(false);
                Menu.menu.invPanel.SetActive(false);
                Menu.menu.EmptyQuestLog();
                GameManager.gameM.paused = false;
            }
        }
    }
}
