using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private static int selectedSkin = 0;
    public GameObject PlayerSkin;

    public void NextOption()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        selectedSkin += 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        PrefabUtility.SaveAsPrefabAsset(PlayerSkin, "Assets/Skins/SelectedSkin.prefab");
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        PlayerPrefs.Save();
    }
    public void BackOption()
    {
        selectedSkin -= 1;
        if (selectedSkin < 0)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        PrefabUtility.SaveAsPrefabAsset(PlayerSkin, "Assets/Skins/SelectedSkin.prefab");
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        PlayerPrefs.Save();
    }
    
}
