using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Creates Lists for textures, fills them with textures
//Allows selection of currently rendered textures
//Sets characterName and CharacterClass
//Saves all values to PlayerPrefs
public class CustomisationSet : MonoBehaviour
{   
    public SkillCustomiser customiser;

    [Header("Character Name")]
    public string characterName;

    [Header("Character Class")]
    public CharacterClass characterClass = CharacterClass.greenWitch;
    public string[] selectedClass = new string[4];
    public int selectedClassIndex = 0;
    
    [Header("Texture Lists")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();

    [Header("Index")]
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex;

    [Header("Renderer")]
    public Renderer characterRenderer;

    [Header("Max amount of textures per type")]
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armourMax, clothesMax;


    //Cycles through textures and adds them to relevant lists
    //Also sets default class values ie runs ChooseClass()
    private void Start()
    {        
        selectedClass = new string[] { "Green Witch", "Hedge Witch" , "Cosmic Witch", "Kitchen Witch" };

        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Eyes_" + i) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Mouth_" + i) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Hair_" + i) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Armour_" + i) as Texture2D;
            armour.Add(tempTexture);
        }
        ChooseClass(0);

    }
   

    //Manages which texture is currently being rendered
    //Triggered on > buttons
    public void SetTextureUp(string type)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                break;

        }

        index ++;
        if(index < 0)
        {
            index = max - 1;
        }
        if(index > max-1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;
        
        switch(type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }

    } 
    //Triggered on < buttons
    public void SetTextureDown(string type)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                break;
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                break;

        }

        index--;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = characterRenderer.materials;
        mat[matIndex].mainTexture = textures[index];
        characterRenderer.materials = mat;

        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }

    }
   

    //Simply sets characterName to what is being entered into the input field
    public void SetName(string name)
    {
        characterName = name;
    }


    //Sets base stats for each class. Also sets classes' unique ability.
    //As selected from dropdown
    public void ChooseClass(int classIndex)
    {
        
        switch (classIndex)
        {
            case 0:
                customiser.myStats.affinity = 4;
                customiser.myStats.boffo = 1;
                customiser.myStats.prowess = 3;
                customiser.myStats.stubbornness = 2;
                characterClass = CharacterClass.greenWitch;
                customiser.myStats.classAbility = "Bush Bind";
                selectedClassIndex = 0;
                
                break;
            case 1:
                customiser.myStats.affinity = 2;
                customiser.myStats.boffo = 4;
                customiser.myStats.prowess = 1;
                customiser.myStats.stubbornness = 3;
                characterClass = CharacterClass.hedgeWitch;
                customiser.myStats.classAbility = "Spirit Spook";
                selectedClassIndex = 1;
                break;
            case 2:
                customiser.myStats.affinity = 3;
                customiser.myStats.boffo = 1;
                customiser.myStats.prowess = 4;
                customiser.myStats.stubbornness = 2;
                characterClass = CharacterClass.cosmicWitch;
                customiser.myStats.classAbility = "Star Sight";
                selectedClassIndex = 2;
                break;
            case 3:
                customiser.myStats.affinity = 1;
                customiser.myStats.boffo = 2;
                customiser.myStats.prowess = 3;
                customiser.myStats.stubbornness = 4;
                characterClass = CharacterClass.kitchenWitch;
                customiser.myStats.classAbility = "Pacify Potion";
                selectedClassIndex = 3;
                break;
        }
    }


    //Saves indexes for textures, character name string, stat value ints, class and class ability strings to PlayerPrefs, then loads game scene
    //Triggered by done button
    public void SaveCharacter()
    {
        customiser.ApplyChanges();
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);

        PlayerPrefs.SetString("CharacterName", characterName);

        PlayerPrefs.SetInt("Affinity", customiser.myStats.affinity);
        PlayerPrefs.SetInt("Boffo", customiser.myStats.boffo);
        PlayerPrefs.SetInt("Prowess", customiser.myStats.prowess);
        PlayerPrefs.SetInt("Stubbornness", customiser.myStats.stubbornness);

        PlayerPrefs.SetString("Character Class", selectedClass[selectedClassIndex]);
        PlayerPrefs.SetString("Class Ability", customiser.myStats.classAbility);

        SceneManager.LoadScene(1);
    }
}

public enum CharacterClass
{
    greenWitch,
    hedgeWitch,
    cosmicWitch,
    kitchenWitch
}
