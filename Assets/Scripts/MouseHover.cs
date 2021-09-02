using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Detects if mouse is hovering over UI element and if so displays the appropriate tooltip
public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Tooltip tooltip;
    [SerializeField]
    CustomisationSet customisation;
    
    //Finds which object it is over, and sets tooltipString to appropriate text
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerEnter.name);
        switch(eventData.pointerEnter.name)
        {
            case "Affinity":
                tooltip.ShowTooltip("Affinity is your connection and influence over your environment");
                break;
            case "Boffo":
                tooltip.ShowTooltip("Boffo is your general witchiness, how much people respect you or how scared of you they are, which often amounts to the same thing");
                break;
            case "Prowess":
                tooltip.ShowTooltip("Prowess is your skill and dexterity, how easily you accomplish tasks");
                break;
            case "Stubbornness":
                tooltip.ShowTooltip("Stubbornness is how reluctant you are to fail. How much you refuse to take no for an answer, how easily you shrug off damage etc");
                break;
            case "Ability":
                Debug.Log("hover");
                switch(customisation.characterClass)
                {
                    case CharacterClass.greenWitch:
                        tooltip.ShowTooltip("Roots entangle the enemy, stopping their movement");
                        break;
                    case CharacterClass.hedgeWitch:
                        tooltip.ShowTooltip("A spirit appears to frighten the enemy, causing them to flee");
                        break;
                    case CharacterClass.cosmicWitch:
                        tooltip.ShowTooltip("Reading the stars reveals enemy weakness, increasing critical hit chance");
                        break;
                    case CharacterClass.kitchenWitch:
                        tooltip.ShowTooltip("Potion removes all enemy aggression");
                        break;
                }
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.HideTooltip();
    }

  
}
