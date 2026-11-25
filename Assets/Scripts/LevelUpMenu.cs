using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
 
public class LevelUpMenu : MonoBehaviour
{

    [Header("Level Up Menu")]
    public GameObject levelUpMenu;

    public bool isLevelUp = false;
    private TMP_Text upgrade1Text;
    private TMP_Text upgrade1Stat;
    private TMP_Text upgrade2Text;
    private TMP_Text upgrade2Stat;
    private TMP_Text upgrade3Text;
    private TMP_Text upgrade3Stat;
    [Header("Player stats")]
    public PlayerMovement playerMovement; //for moveSpeed
    public SingleMeleeAutoAttack singleMeleeAutoAttack; //for damage + attack cooldown (cooldown) + ultimateCooldown
    


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



    public void UpgradeOneChoice(string choiceOne)
    {
        GameObject upgradeText1 = GameObject.Find("Upgrade1Text");
        upgrade1Text = upgradeText1.GetComponentInChildren<TMP_Text>();

        GameObject upgradeStat1 = GameObject.Find("Upgrade1Stat");
        upgrade1Stat = upgradeStat1.GetComponentInChildren<TMP_Text>();

        if(choiceOne == "Attack Damage") 
        {
            upgrade1Text.text = "Attack Damage";
            upgrade1Stat.text = singleMeleeAutoAttack.damage + "-->" + (singleMeleeAutoAttack.damage + 1);
            
        }   
        else if (choiceOne == "Attack Speed")
        {
            upgrade1Text.text = "Attack Speed";
            upgrade1Stat.text = singleMeleeAutoAttack.cooldown + "-->" + singleMeleeAutoAttack.cooldown * 0.9;
        } 
        else if (choiceOne == "Move Speed")
        {
            upgrade1Text.text = "Move Speed";
            upgrade1Stat.text = playerMovement.moveSpeed + "-->" + (playerMovement.moveSpeed * 1.1);
        } 
        else if (choiceOne == "Ultimate Cooldown") 
        {
            upgrade1Text.text = "Ultimate Cooldown";
            upgrade1Stat.text = singleMeleeAutoAttack.ultimateCooldown + "-->" + (singleMeleeAutoAttack.ultimateCooldown * 0.9);
        
        }
        else    if (choiceOne == "Ultimate Radius") 
        {
            upgrade1Text.text = "Ultimate Radius";
            upgrade1Stat.text = "idk what to put here";
        }

    }

    public void UpgradeTwoChoice(string choiceTwo)
    {
        GameObject upgradeText2 = GameObject.Find("Upgrade2Text");
        upgrade2Text = upgradeText2.GetComponentInChildren<TMP_Text>();

        GameObject upgradeStat2 = GameObject.Find("Upgrade2Stat");
        upgrade2Stat = upgradeStat2.GetComponentInChildren<TMP_Text>();

        if(choiceTwo == "Attack Damage") 
        {
            upgrade2Text.text = "Attack Damage";
            upgrade2Stat.text = singleMeleeAutoAttack.damage + "-->" + (singleMeleeAutoAttack.damage + 1);

        }   
        else if (choiceTwo == "Attack Speed")
        {
            upgrade2Text.text = "Attack Speed";
            upgrade2Stat.text = singleMeleeAutoAttack.cooldown + "-->" + (singleMeleeAutoAttack.cooldown * 0.9);
        } 
        else if (choiceTwo == "Move Speed")
        {
            upgrade2Text.text = "Move Speed";
            upgrade2Stat.text = playerMovement.moveSpeed + "-->" + (playerMovement.moveSpeed * 1.1);
        } 
        else if (choiceTwo == "Ultimate Cooldown") 
        {
            upgrade2Text.text = "Ultimate Cooldown";
            upgrade2Stat.text = singleMeleeAutoAttack.ultimateCooldown + "-->" + (singleMeleeAutoAttack.ultimateCooldown * 0.9);
        
        }
        else    if (choiceTwo == "Ultimate Radius") 
        {
            upgrade2Text.text = "Ultimate Radius";
            upgrade2Stat.text = "idk what to put here";
        }

    }


  public void UpgradeThreeChoice(string choiceThree)
    {
        GameObject upgradeText3 = GameObject.Find("Upgrade3Text");
        upgrade3Text = upgradeText3.GetComponentInChildren<TMP_Text>();

        GameObject upgradeStat3 = GameObject.Find("Upgrade3Stat");
        upgrade3Stat = upgradeStat3.GetComponentInChildren<TMP_Text>();

        if(choiceThree == "Attack Damage") 
        {
            upgrade3Text.text = "Attack Damage";
            upgrade3Stat.text = singleMeleeAutoAttack.damage + "-->" + (singleMeleeAutoAttack.damage + 1);

        }   
        else if (choiceThree == "Attack Speed")
        {
            upgrade3Text.text = "Attack Speed";
            upgrade3Stat.text = singleMeleeAutoAttack.cooldown + "-->" + (singleMeleeAutoAttack.cooldown * 0.9);
        } 
        else if (choiceThree == "Move Speed")
        {
            upgrade3Text.text = "Move Speed";
            upgrade3Stat.text = playerMovement.moveSpeed + "-->" + (playerMovement.moveSpeed * 1.1);
        } 
        else if (choiceThree == "Ultimate Cooldown") 
        {
            upgrade3Text.text = "Ultimate Cooldown";
            upgrade3Stat.text = singleMeleeAutoAttack.ultimateCooldown + "-->" + (singleMeleeAutoAttack.ultimateCooldown * 0.9);
        
        }
        else if (choiceThree == "Ultimate Radius") 
        {
            upgrade3Text.text = "Ultimate Radius";
            upgrade3Stat.text = "idk what to put here";
        }

    }

    public void UpgradeChoices()

    {
        //makes two lists one for the words
        List<string> upgradeChoices = new List<string> { "Attack Damage", "Attack Speed", "Move Speed", "Ultimate Cooldown", "Ultimate Radius" };

        List<Sprite> upgradeIcons;
        
        //makes a list for the pictures associated with the stats(in order)
        Sprite[] loadedSprites = Resources.LoadAll<Sprite>("Upgrade Icons");
        upgradeIcons = new List<Sprite>(loadedSprites);

        //randomly chooses 3 choices from the list and removes them so they cant be picked again
        int choiceOneNo = Random.Range(0, 5);

        string choiceOne = upgradeChoices[choiceOneNo];

        UpgradeOneChoice(choiceOne);

        Sprite iconOne = upgradeIcons[choiceOneNo];

        upgradeChoices.Remove(choiceOne);

        upgradeIcons.RemoveAt(choiceOneNo);


        int choiceTwoNo = Random.Range(0, 4);

        string choiceTwo = upgradeChoices[choiceTwoNo];

        UpgradeTwoChoice(choiceTwo);

        Sprite iconTwo = upgradeIcons[choiceTwoNo];

        upgradeIcons.RemoveAt(choiceTwoNo);

        upgradeChoices.Remove(choiceTwo);


        int choiceThreeNo = Random.Range(0, 3);

        string choiceThree = upgradeChoices[choiceThreeNo];

        UpgradeThreeChoice(choiceThree);


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

    public void UpgradeStat1()
    {
        ResumeLevelMenu();
        if (upgrade1Text.text == "Attack Damage")
        {
            singleMeleeAutoAttack.damage += 1;
        }
        else if (upgrade1Text.text == "Attack Speed")
        {
            singleMeleeAutoAttack.cooldown *= 0.9f;
        }
        else if (upgrade1Text.text == "Move Speed")
        {
            playerMovement.moveSpeed *= 1.1f;
        }
        else if (upgrade1Text.text == "Ultimate Cooldown")
        {
            singleMeleeAutoAttack.ultimateCooldown *= 0.9f;
        }
        else if (upgrade1Text.text == "Ultimate Radius") 
        {
            // Implement the logic for upgrading Ultimate Radius here (might change)
        }
        Debug.Log("LevelUpMenu: UpgradeStat2 executed. Current stats - Damage: " + singleMeleeAutoAttack.damage + ", Cooldown: " + singleMeleeAutoAttack.cooldown + ", Move Speed: " + playerMovement.moveSpeed + ", Ultimate Cooldown: " + singleMeleeAutoAttack.ultimateCooldown);
    }

       public void UpgradeStat2()
    {
        ResumeLevelMenu();
        if (upgrade2Text.text == "Attack Damage")
        {
            singleMeleeAutoAttack.damage += 1;
        }
        else if (upgrade2Text.text == "Attack Speed")
        {
            singleMeleeAutoAttack.cooldown *= 0.9f;
        }
        else if (upgrade2Text.text == "Move Speed")
        {
            playerMovement.moveSpeed *= 1.1f;
        }
        else if (upgrade2Text.text == "Ultimate Cooldown")
        {
            singleMeleeAutoAttack.ultimateCooldown *= 0.9f;
        }
        else if (upgrade2Text.text == "Ultimate Radius") 
        {
            // Implement the logic for upgrading Ultimate Radius here (might change)
        }
        Debug.Log("LevelUpMenu: UpgradeStat2 executed. Current stats - Damage: " + singleMeleeAutoAttack.damage + ", Cooldown: " + singleMeleeAutoAttack.cooldown + ", Move Speed: " + playerMovement.moveSpeed + ", Ultimate Cooldown: " + singleMeleeAutoAttack.ultimateCooldown);
    }
    
       public void UpgradeStat3()
    {
        ResumeLevelMenu();
        if (upgrade3Text.text == "Attack Damage")
        {
            singleMeleeAutoAttack.damage += 1;
        }
        else if (upgrade3Text.text == "Attack Speed")
        {
            singleMeleeAutoAttack.cooldown *= 0.9f;
        }
        else if (upgrade3Text.text == "Move Speed")
        {
            playerMovement.moveSpeed *= 1.1f;
        }
        else if (upgrade3Text.text == "Ultimate Cooldown")
        {
            singleMeleeAutoAttack.ultimateCooldown *= 0.9f;
        }
        else if (upgrade3Text.text == "Ultimate Radius") 
        {
            // Implement the logic for upgrading Ultimate Radius here (might change)
        }
        Debug.Log("LevelUpMenu: UpgradeStat2 executed. Current stats - Damage: " + singleMeleeAutoAttack.damage + ", Cooldown: " + singleMeleeAutoAttack.cooldown + ", Move Speed: " + playerMovement.moveSpeed + ", Ultimate Cooldown: " + singleMeleeAutoAttack.ultimateCooldown);
    }


}
