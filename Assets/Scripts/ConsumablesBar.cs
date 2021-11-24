using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesBar : MonoBehaviour
{
    public InventoryManager consumablesInv;
    public static ConsumablesBar consumables;
    public float timer;
    public GameObject consumablesUI;
    void Start()
    {
        consumables = this;
        consumablesInv.invButtons = GetComponentsInChildren<ClickableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        { 
            consumablesInv.pickUps[0].Use(); 
        }                       
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            consumablesInv.pickUps[1].Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            consumablesInv.pickUps[2].Use();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            consumablesInv.pickUps[3].Use();
        }
    }
}
