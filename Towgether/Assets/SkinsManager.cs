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
    
    void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController ;

    }

    public void NextOption()
    {
      
        selectedSkin += 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;

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
        PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skins[selectedSkin] as RuntimeAnimatorController;

        PlayerPrefs.SetInt("selectedSkin", selectedSkin);
        PlayerPrefs.Save();

    }
 
}
