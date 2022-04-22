using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SkinsSection;
    [SerializeField] GameObject SelectedSkin;
    [SerializeField] GameObject SettingsButtonObject;
    [SerializeField] GameObject SettingsSectoin;
    [SerializeField] GameObject CoinsAmount;
    [SerializeField] Toggle TiltYourPhoneToggle;
    [SerializeField] Toggle ArrowToggle;
    [SerializeField] GameObject Note1;
    [SerializeField] GameObject Note2;
    [SerializeField] CanvasGroup MainMenuCanvas;
    [SerializeField] CanvasGroup SkinsCanvas;
    [SerializeField] CanvasGroup settingssectionCanvas;
    int BoolTiltYourPhoneToggle;
    int ArrowToggleBool;

    DissolveItem MainMenuCanvasObject;
    DissolveItem SkinsCanvasObject;
    DissolveItem settingssectionCanvasObject;
    
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(true);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);

        MainMenuCanvasObject = new DissolveItem(MainMenuCanvas, MainMenuCanvas.alpha);
        SkinsCanvasObject = new DissolveItem(SkinsCanvas, SkinsCanvas.alpha);
        settingssectionCanvasObject = new DissolveItem(settingssectionCanvas, settingssectionCanvas.alpha);

        BoolTiltYourPhoneToggle = PlayerPrefs.GetInt("Tilt", 0);
        ArrowToggleBool = PlayerPrefs.GetInt("Arrows", 0);

        if (BoolTiltYourPhoneToggle == 1)
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

        MainMenuCanvasObject.Fading = false;
        SkinsCanvasObject.Fading = true;
        settingssectionCanvasObject.Fading = true;
    }

    void Update()
    {
        
        MainMenuCanvasObject.HandleFading();
        SkinsCanvasObject.HandleFading();
        settingssectionCanvasObject.HandleFading();

        if (started)
        {
            MainMenuCanvasObject.Fading = true;
            if (MainMenuCanvas.alpha <= 0f)
            {
               SceneManager.LoadScene("base");
            }

        }
    }


    bool started;
    public void StartButton()
    {
        started = true;


    }
    public void LoadingScene()
    {
        SceneManager.LoadScene("Loading");
    }
    public void SettingsButton()
    {
        MainMenu.SetActive(false);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(false);
        SettingsSectoin.SetActive(true);
        CoinsAmount.SetActive(false);
        MainMenuCanvasObject.Fading = true;
        SkinsCanvasObject.Fading = true;
        settingssectionCanvasObject.Fading =false ;

    }
   
    public void ShopButtonPressed()
    {
        MainMenu.SetActive(false);
        SkinsSection.SetActive(true);
        SelectedSkin.SetActive(true);
        SettingsButtonObject.SetActive(false);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);
        MainMenuCanvasObject.Fading = true;
        SkinsCanvasObject.Fading = false;
        settingssectionCanvasObject.Fading =true ;

    }

    public void BackButtonPressed()
    {
        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
        SettingsButtonObject.SetActive(true);
        SettingsSectoin.SetActive(false);
        CoinsAmount.SetActive(true);
         MainMenuCanvasObject.Fading = false;
        SkinsCanvasObject.Fading = true;
        settingssectionCanvasObject.Fading =true ;

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

    public class DissolveItem
    {

        CanvasGroup canvasGroup;
        float alpha;
        public bool Fading;
        public DissolveItem(CanvasGroup canvasGroup, float alpha)
        {
            this.canvasGroup = canvasGroup;
            this.alpha = alpha;
            
        }

        public void Alphadecrease()
        {
            
                alpha = canvasGroup.alpha;
                alpha -= Time.deltaTime;
                canvasGroup.alpha = alpha;
            
        }
        public void AlphaIncrease()
        {
            
                alpha = canvasGroup.alpha;
                alpha += Time.deltaTime;
                canvasGroup.alpha = alpha;
            
        }
        public void HandleFading()
        {
            if (Fading)
            {
                Alphadecrease();
            }
            else if (!Fading)
            {
                AlphaIncrease();
            }
        }


    }
    
}
