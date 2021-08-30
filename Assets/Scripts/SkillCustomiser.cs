using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkillCustomiser : MonoBehaviour
{
    public CharacterStats myStats;

    int pointPool;
    [SerializeField]
    Text poolText;

    [SerializeField]
    Text[] labels;

    [SerializeField]
    int[] stats;



    //Sets stat point pool to 10, and sets up array of temporary stat values - setting them initially to 0
    //Runs UpdateText()
    void Start()
    {
        pointPool = 10;

        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = 0;
        }

        UpdateText();
    }


    //Checks if point pool is greater than 0 and stat value < 10
    //If satisfied increases stat value by 1 and decreases point pool by 1
    //Triggered by + buttons
    public void StatUp(int stat)
    {
        if (pointPool > 0 && stats[stat] < 10)
        {
            stats[stat]++;
            pointPool--;
            UpdateText();
        }
    }


    //Checks if stat value > 0
    //If satisfied decreases stat value by 1 and increases point pool by 1
    //Triggered by - buttons
    public void StatDown(int stat)
    {
        if (stats[stat] > 0)
        {
            stats[stat]--;
            pointPool++;
            UpdateText();
        }
    }


    //Cycles through labels array and updates each label to CharacterStats mystats + stats temporary values
    public void UpdateText()
    {
        labels[0].text = "Affinity: " + (stats[0] + myStats.affinity);
        labels[1].text = "Boffo: " + (stats[1] + myStats.boffo);
        labels[2].text = "Prowess: " + (stats[2] + myStats.prowess);
        labels[3].text = "Stubbornness: " + (stats[3] + myStats.stubbornness);
        labels[4].text = "Class Ability: " + myStats.classAbility;
        poolText.text = pointPool + "";
    }


    //Adds changed stat values to CharacterStats class mystats
    public void ApplyChanges()
    {
        myStats.affinity += stats[0];
        myStats.boffo += stats[1];
        myStats.prowess += stats[2];
        myStats.stubbornness += stats[3];
    }


}
