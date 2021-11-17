using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public static EquipManager equip;
    public ClickableObject[] equipButtons = new ClickableObject[5];
    public enum EquipSlot
    {
        hat, leftHand, rightHand, robe, boots
    }
    public EquipSlot equipSlot;

    private void Start()
    {
        if (equip == null)
        {
            equip = this;
        }
        else
        {
            Destroy(this);
        }
    }
}
