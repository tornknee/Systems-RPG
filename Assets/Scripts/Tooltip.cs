using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Text box follows mouse location and scales to size of text
public class Tooltip : MonoBehaviour
{
    private Text tooltipText;
    private RectTransform backgroundRect;

    Camera uiCamera;

    private void Start()
    {
        backgroundRect = GetComponent<RectTransform>();
        tooltipText = transform.Find("Text").GetComponent<Text>();
        HideTooltip();
    }

    //Finds mouse position and makes it tooltip's position
    private void Update()
    {
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, uiCamera, out localPoint);
        localPoint.x += 50;
        transform.localPosition = localPoint;
        
    }

    //Displays tooltip and resizes to match text
    public void ShowTooltip(string tooltipString)
    {
        gameObject.SetActive(true);

        tooltipText.text = tooltipString;
        float textPadding = 10;
        Vector2 backgroundSize = new Vector2(100 , tooltipText.preferredHeight + textPadding);
        backgroundRect.sizeDelta = backgroundSize;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
    }
}
