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

    int CurrentMoney;

    bool Owned;
    CurrentSkin currentSkin;



   public static int Is_Third_SkinPurchased;
    int Is_fourth_SkinPurchased;
    int Is_fifth_SkinPurchased;
    int Is_sixth_SkinPurchased;
    int Is_seventh_SkinPurchased;

   
    void isSkinPurcahsed()
    {
       
        Is_Third_SkinPurchased = PlayerPrefs.GetInt("Is_Third_SkinPurchased", 0);
        Is_Third_SkinPurchased = 1;
        PlayerPrefs.SetInt(" Is_Third_SkinPurchased", Is_Third_SkinPurchased);
        PlayerPrefs.Save();
    }

    void Awake()
    {
        isSkinPurcahsed();


        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController ;
        currentSkin = new CurrentSkin(skins, Owned, PlayerObject, PurchaseSkinButton);
        PurchaseSkinButton.SetActive(false);
        CurrentMoney =  PlayerPrefs.GetInt("CurrentScore", 0);
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
    
    public void PurcahseButton()
    {


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
                    return false;
                   
                case 4:
                    return false;
                   
                case 5:
                    return false;
                    
                case 6:
                    return false;                                      
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
