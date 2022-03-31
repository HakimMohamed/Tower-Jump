using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SkinsSection;
    [SerializeField] GameObject SelectedSkin;
   
    void Awake()
    {
        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);
    }

    void Update()
    {
        
    }


   public void ShopButtonPressed()
    {
        MainMenu.SetActive(false);
        SkinsSection.SetActive(true);
        SelectedSkin.SetActive(true);
    }

    public void BackButtonPressed()
    {

        MainMenu.SetActive(true);
        SkinsSection.SetActive(false);
        SelectedSkin.SetActive(false);

    }
}
