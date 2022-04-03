using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<AnimatorOverrideController> skins = new List<AnimatorOverrideController>();
    public static  int selectedSkin = 0;
    public GameObject PlayerObject;

    [SerializeField]  GameObject PurchaseSkinButton;

   
    bool Owned;
    CurrentSkin currentSkin;
    int CurrentMoney;


    public static int Is_Third_SkinPurchased;
    public static int Is_fourth_SkinPurchased;
    public static int Is_fifth_SkinPurchased;
    public static int Is_sixth_SkinPurchased;
    public static int Is_seventh_SkinPurchased;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        isSkinPurcahsed();
       

        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
        currentSkin = new CurrentSkin(skins, Owned, PlayerObject, PurchaseSkinButton);
        PurchaseSkinButton.SetActive(false);
        CurrentMoney = PlayerPrefs.GetInt("CurrentScore", 0);
    }
    public void PurcahseButton()
    {
        if (selectedSkin == 2&& CurrentMoney>=40)
        {
            PlayerPrefs.SetInt("Is_Third_SkinPurchased", 1);
            Is_Third_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);          
            CurrentMoney -= 40;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();

        }
        if (selectedSkin == 3&& CurrentMoney >= 40)
        {
            PlayerPrefs.SetInt("Is_fourth_SkinPurchased", 1);
            Is_fourth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);          
            CurrentMoney -= 40;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 4 && CurrentMoney >= 40)
        {
            PlayerPrefs.SetInt("Is_fifth_SkinPurchased", 1);
            Is_fifth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);  
            CurrentMoney -= 40;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 5 && CurrentMoney >= 40)
        {
            PlayerPrefs.SetInt("Is_sixth_SkinPurchased", 1);
            Is_sixth_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);
           
            CurrentMoney -= 40;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
        if (selectedSkin == 6 && CurrentMoney >= 40)
        {
            PlayerPrefs.SetInt("Is_seventh_SkinPurchased", 1);
            Is_seventh_SkinPurchased = 1;
            PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
            PurchaseSkinButton.SetActive(false);
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);           
            CurrentMoney -= 40;
            PlayerPrefs.SetInt("CurrentScore", CurrentMoney);
            PlayerPrefs.Save();
        }
    }

    void isSkinPurcahsed()
    {
       
        Is_Third_SkinPurchased = PlayerPrefs.GetInt("Is_Third_SkinPurchased", 0);
        
        PlayerPrefs.SetInt(" Is_Third_SkinPurchased", Is_Third_SkinPurchased);
        PlayerPrefs.Save();

        Is_fourth_SkinPurchased = PlayerPrefs.GetInt("Is_fourth_SkinPurchased", 0);
        
        PlayerPrefs.SetInt(" Is_fourth_SkinPurchased", Is_fourth_SkinPurchased);
        PlayerPrefs.Save();

        Is_fifth_SkinPurchased = PlayerPrefs.GetInt("Is_fifth_SkinPurchased", 0);
       
        PlayerPrefs.SetInt(" Is_fifth_SkinPurchased", Is_fifth_SkinPurchased);
        PlayerPrefs.Save();

        Is_sixth_SkinPurchased = PlayerPrefs.GetInt("Is_sixth_SkinPurchased", 0);
      
        PlayerPrefs.SetInt(" Is_sixth_SkinPurchased", Is_sixth_SkinPurchased);
        PlayerPrefs.Save();

        Is_seventh_SkinPurchased = PlayerPrefs.GetInt("Is_seventh_SkinPurchased", 0);
       
        PlayerPrefs.SetInt(" Is_seventh_SkinPurchased", Is_seventh_SkinPurchased);
        PlayerPrefs.Save();

       
    }
   

    public void NextOption()
    {
              
        currentSkin.NextSkin();
        currentSkin.SetSkin();
       
    }
    public void BackOption()
    {
        currentSkin.previusSkin();
        currentSkin.SetSkin();

    }
   
    private class CurrentSkin
    {
        List<AnimatorOverrideController> skinsList = new List<AnimatorOverrideController>();
        bool IsOwned;
        GameObject PlayerObject;
        GameObject PurchaseSkinButton;
        public CurrentSkin(List<AnimatorOverrideController> skinsList, bool isOwned,GameObject Player, GameObject PurchaseSkinButton)
        {
            this.skinsList = skinsList;
            IsOwned = isOwned;
            this.PlayerObject = Player;
            this.PurchaseSkinButton = PurchaseSkinButton;
        }
       bool isowned()
        {
            switch (selectedSkin)
            {
                case 0:
                    return true;
                   
                case 1:
                    return true;
                    
                case 2:
                    return intToBool(Is_Third_SkinPurchased);
                   
                case 3:
                    return intToBool(Is_fourth_SkinPurchased);
                   
                case 4:
                    return intToBool(Is_fifth_SkinPurchased);
                   
                case 5:
                    return intToBool(Is_sixth_SkinPurchased);
                    
                case 6:
                    return intToBool(Is_seventh_SkinPurchased);                                      
            }
            return true;
        }
        public void SetSkin()
        {
            if (!isowned())
            {
                PlayerObject.GetComponent<SpriteRenderer>().color = Color.black;
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skinsList[selectedSkin] as RuntimeAnimatorController;
                PurchaseSkinButton.SetActive(true);
            }
            else if(isowned())
            {
                PlayerObject.GetComponent<SpriteRenderer>().color = Color.white;
                PurchaseSkinButton.SetActive(false);
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skinsList[selectedSkin] as RuntimeAnimatorController;
                PlayerPrefs.SetInt("selectedSkin", selectedSkin);
                PlayerPrefs.Save();
            }
        }
        public void NextSkin()
        {
            
            selectedSkin += 1;
            
            if (selectedSkin == skinsList.Count)
            {
                selectedSkin = 0;
            }
        }
        public void previusSkin()
        {
            
            selectedSkin -= 1;
            if (selectedSkin < 0)
            {
                selectedSkin = 0;
            }
        }
    }



    public static bool intToBool(int num)
    {
        if (num > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}
