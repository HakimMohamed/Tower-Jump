using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SkinsSection;
    [SerializeField] GameObject SelectedSkin;
    [SerializeField] GameObject SettingsButtonObject;
    [SerializeField] GameObject SettingsSectoin;
    [SerializeField] GameObject CoinsAmount;
    [SerializeField] GameObject Coin;
    [SerializeField] Toggle TiltYourPhoneToggle;
    [SerializeField] Toggle ArrowToggle;
    [SerializeField] GameObject Note1;
    [SerializeField] GameObject Note2;
    int BoolTiltYourPhoneToggle;
    int ArrowToggleBool;
    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(true);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);
        Coin.SetActive(true);


        

       
        if (BoolTiltYourPhoneToggle == 1)
        {
            BoolTiltYourPhoneToggle = PlayerPrefs.GetInt("Tilt", 0);
            TiltYourPhoneToggle.isOn = intToBool(BoolTiltYourPhoneToggle);
            Note1.SetActive(true);
            Note2.SetActive(false);
        }
        else if (ArrowToggleBool == 1)

        {
            ArrowToggleBool = PlayerPrefs.GetInt("Arrows", 0);
            ArrowToggle.isOn = intToBool(ArrowToggleBool);
            Note1.SetActive(false);
            Note2.SetActive(true);  
        }


    }
   

    void Update()
    {
        BoolTiltYourPhoneToggle = PlayerPrefs.GetInt("Tilt", 0);
        ArrowToggleBool = PlayerPrefs.GetInt("Arrows", 0);

        if(BoolTiltYourPhoneToggle == 1)
        {
            TiltYourPhoneToggle.isOn = intToBool(BoolTiltYourPhoneToggle);
            Note1.SetActive(true);
            Note2.SetActive(false);
        }
        else if (ArrowToggleBool == 1)

        {
            ArrowToggle.isOn = intToBool(ArrowToggleBool);
            Note1.SetActive(false);
            Note2.SetActive(true);
        }
    }

    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(false);
        SettingsSectoin.SetActive(true);
        CoinsAmount.SetActive(false);
        Coin.SetActive(false);
    }
    public void ShopButtonPressed()
    {
        MainMenu.SetActive(false);
        SkinsSection.SetActive(true);
        SelectedSkin.SetActive(true);
        SettingsButtonObject.SetActive(false);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);
        Coin.SetActive(true);

    }

    public void BackButtonPressed()
    {
        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(true);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);
        Coin.SetActive(true);
    }
    public void ToggleTiltSetter(bool whichone)
    { 

      PlayerPrefs.SetInt("Tilt", boolToint(whichone));
      PlayerPrefs.SetInt("Arrows", boolToint(!whichone));
     
    }
    public void ToggleArrowSetter(bool whichone)
    {
        PlayerPrefs.SetInt("Tilt", boolToint(whichone));
        PlayerPrefs.SetInt("Arrows", boolToint(!whichone));
    }

    private  int boolToint(bool boolean)
    {
        if (boolean)
        {
            return 1;
        }
        else
        {
            return 0;
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
