using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    [SerializeField] GameObject PlayerObject;
    public AnimatorOverrideController blueanim;
    public AnimatorOverrideController pinkanim;
    public AnimatorOverrideController detectiveanim;
    public AnimatorOverrideController skeletonANim;
    public AnimatorOverrideController GoodSkinanim;
    public AnimatorOverrideController SlimeAnim;
    public AnimatorOverrideController astronoutAnim;
    static int SelectedVAr;

    private void Start()
    {
        SelectedVAr = PlayerPrefs.GetInt("selectedSkin", 0);
        if (SelectedVAr == 0)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = blueanim as RuntimeAnimatorController;

        if (SelectedVAr == 1)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = pinkanim as RuntimeAnimatorController;

        if (SelectedVAr == 2)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skeletonANim as RuntimeAnimatorController;

        if (SelectedVAr == 3)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = detectiveanim as RuntimeAnimatorController;


        if (SelectedVAr == 4)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = GoodSkinanim as RuntimeAnimatorController;


        if (SelectedVAr == 5)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = SlimeAnim as RuntimeAnimatorController;


        if (SelectedVAr == 6)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = astronoutAnim as RuntimeAnimatorController;
    }
    void Update()
    {
        
        SelectedVAr = PlayerPrefs.GetInt("selectedSkin", 0);

        if (SelectedVAr == 0)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = blueanim as RuntimeAnimatorController;

        if (SelectedVAr == 1)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = pinkanim as RuntimeAnimatorController;

        if (SelectedVAr == 2)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skeletonANim as RuntimeAnimatorController;

        if (SelectedVAr == 3)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = SlimeAnim as RuntimeAnimatorController;

        if (SelectedVAr == 4)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = detectiveanim as RuntimeAnimatorController;

        
        if (SelectedVAr == 5)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = astronoutAnim as RuntimeAnimatorController;

        if (SelectedVAr == 6)
            PlayerObject.GetComponent<Animator>().runtimeAnimatorController = GoodSkinanim as RuntimeAnimatorController;
    }
}
