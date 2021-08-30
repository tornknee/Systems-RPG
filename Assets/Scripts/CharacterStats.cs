using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Class mostly stores stats and also manages health and mana bars
public class CharacterStats : MonoBehaviour
{
    [Header("Character Stats")]
    public int affinity;
    public int boffo, prowess, stubbornness;

    [Header("General Stats")]
    public float health;
    public float mana;
    
    public Slider healthSlider;
    public Slider manaSlider;

    public string classAbility;
   
    //Continuously updates health and mana
    private void Update()
    {
        //Max health and mana are set in relation to stubbornness and affinity stats
        healthSlider.maxValue = stubbornness * 10;
        healthSlider.value = health;
        manaSlider.maxValue = affinity * 10;
        manaSlider.value = mana;

        //Checks if health and mana are full, if not slowly regenerates in relation to stubbornness/affinity stat
        if(health < healthSlider.maxValue)
        {
            health += stubbornness / 1000f;
        }
        if(mana < manaSlider.maxValue)
        {
            mana += affinity / 500f;
        }

    }
}
