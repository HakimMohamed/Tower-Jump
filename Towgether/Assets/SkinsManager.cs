using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine;

public class SkinsManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject PlayerSkin;

    public void NextOption()
    {
        selectedSkin += 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        PrefabUtility.SaveAsPrefabAsset(PlayerSkin, "Assets/Skins/SelectedSkin.prefab");
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
    }
    
}
