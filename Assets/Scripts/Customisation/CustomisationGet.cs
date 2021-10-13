using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Recalls values from PlayerPrefs
//Sets textures to player object
public class CustomisationGet : MonoBehaviour
{
    public Renderer characterRenderer;
    public GameObject player;
    public CharacterStats stats;
    
    //Finds player object
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Load();
    }

    //Recalls values from PlayerPrefs
    //Sets CharacterStats values
    void Load()
    {
        SetTexture("Skin", PlayerPrefs.GetInt("SkinIndex"));
        SetTexture("Eyes", PlayerPrefs.GetInt("EyesIndex"));
        SetTexture("Mouth", PlayerPrefs.GetInt("MouthIndex"));
        SetTexture("Hair", PlayerPrefs.GetInt("HairIndex"));
        SetTexture("Clothes", PlayerPrefs.GetInt("ClothesIndex"));
        SetTexture("Armour", PlayerPrefs.GetInt("ArmourIndex"));
        player.name = PlayerPrefs.GetString("CharacterName");
        stats.affinity = PlayerPrefs.GetInt("Affinity");
        stats.boffo = PlayerPrefs.GetInt("Boffo");
        stats.prowess = PlayerPrefs.GetInt("Prowess");
        stats.stubbornness = PlayerPrefs.GetInt("Stubbornness");
        stats.classAbility = PlayerPrefs.GetString("Class Ability");
        stats.health = stats.stubbornness * 10;
        stats.mana = stats.affinity * 10;
    }

    //Renders recalled textures
    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int matIndex = 0;
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                break;

        }
        Material[] mats = characterRenderer.materials;
        mats[matIndex].mainTexture = texture;
        characterRenderer.materials = mats;
    }
}
