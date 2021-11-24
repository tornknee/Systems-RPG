using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{
    public delegate void LeftClick();
    public LeftClick leftClick;
    public delegate void RightClick();
    public RightClick rightClick;

    public delegate void MiddleClick(ItemData item);
    public MiddleClick middleClick;
    public ItemData item;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if(leftClick != null)
            {
                Debug.Log("Left click");
                leftClick();
            }
        }

        else if (eventData.button == PointerEventData.InputButton.Middle)
        { 
            if(middleClick != null)
            {
                Debug.Log("Middle click");
                middleClick(item);
            }      
        }

        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(rightClick != null)
            {
                Debug.Log("Right click");
                rightClick();
            }
        }
    }
}

