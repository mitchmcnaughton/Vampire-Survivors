using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelUpMenu : MonoBehaviour
{

    [Header("Level Up Menu")]
    public GameObject levelUpMenu;

    public bool isLevelUp = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     private void Start()
    {
        levelUpMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void StartLevelMenu()
    {
        isLevelUp = true;

        levelUpMenu.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log("LevelUpMenu: Game Paused");
    }

    public void ResumeLevelMenu()
    {
        isLevelUp = false;

        levelUpMenu.SetActive(false);

        Time.timeScale = 1f;

        Debug.Log("LevelUpMenu: Game Resumed");
    }

    public void UpgradeChoices()

    {
        //makes two lists one for the words one for the pictures associated with them
        List<string> upgradeChoices = new List<string> { "Attack Damage", "Attack Speed", "Move Speed", "Ultimate Cooldown", "Ultimate Radius" };

        List<Sprite> upgradeIcons;

        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Upgrade Icons");
        upgradeIcons = new List<Sprite>(loadedSprites);

        //randomly chooses 3 choices from the list and removes them so they cant be picked again
        int choiceOneNo = Random.Range(0, 5);

        string choiceOne = upgradeChoices[choiceOneNo];

        Sprite iconOne = upgradeIcons[choiceOneNo];

        upgradeChoices.Remove(choiceOne);

        upgradeIcons.RemoveAt(choiceOneNo);


        int choiceTwoNo = Random.Range(0, 4);

        string choiceTwo = upgradeChoices[choiceTwoNo];

        Sprite iconTwo = upgradeIcons[choiceTwoNo];

        upgradeIcons.RemoveAt(choiceTwoNo);

        upgradeChoices.Remove(choiceTwo);


        int choiceThreeNo = Random.Range(0, 3);

        string choiceThree = upgradeChoices[choiceThreeNo];


        //finds the uprgade 1 img in the scene and changes it to the first option

        GameObject imageObjOne = GameObject.Find("Upgrade 1 Image");

        if (imageObjOne != null)
        { 
            Image uiImage1 = imageObjOne.GetComponent<Image>();

            if (uiImage1 != null)
            {
                uiImage1.sprite = iconOne;
            }
        }
        else
        {
            Debug.LogWarning("LevelUpMenu: Could not find 'Upgrade 1 Image' in the scene");

        }

        //finds the uprgade 2 img in the scene and changes it to the first option

        GameObject imageObjTwo = GameObject.Find("Upgrade 2 Image");

        if (imageObjTwo != null)
        {
            Image uiImage2 = imageObjTwo.GetComponent<Image>();

            if (uiImage2 != null)
            {
                uiImage2.sprite = iconTwo;
            }
        }
        else
        {
            Debug.LogWarning("LevelUpMenu: Could not find 'Upgrade 2 Image' in the scene");

        }


        //finds the uprgade 3 img in the scene and changes it to the first option

        GameObject imageObjThree = GameObject.Find("Upgrade 3 Image");

        if (imageObjThree != null)
        {
            Image uiImage3 = imageObjThree.GetComponent<Image>();

            if (uiImage3 != null)
            {
                uiImage3.sprite = upgradeIcons[choiceThreeNo];
            }
        }
        else
        {
            Debug.LogWarning("LevelUpMenu: Could not find 'Upgrade 3 Image' in the scene");

        }



    }

}
