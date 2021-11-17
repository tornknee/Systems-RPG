using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : PickUpItem
{
    public enum Slot
    {
        hat, leftHand, rightHand, robe, boots
    }
    public Slot slot;

    public override void Use()
    {
        base.Use();
    }
}
