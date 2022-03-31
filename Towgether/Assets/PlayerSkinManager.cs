using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinManager : MonoBehaviour
{
    public GameObject SelectedSkin;
    public GameObject PlayerObject;

    private Sprite PlayerSprite;

    public AnimatorOverrideController blueanim;
    public AnimatorOverrideController pinkanim;
    public AnimatorOverrideController detectiveanim;
    public AnimatorOverrideController skeletonANim;
    public AnimatorOverrideController GoodSkinanim;
    public AnimatorOverrideController SlimeAnim;
    public AnimatorOverrideController astronoutAnim;
    void Awake()
    {

        PlayerSprite = SelectedSkin.GetComponent<SpriteRenderer>().sprite;
        PlayerObject.GetComponent<SpriteRenderer>().sprite = PlayerSprite;

        switch (PlayerSprite.name)
        {
            case "BlobPlayer_Blue_0":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = blueanim as RuntimeAnimatorController;
                break;

            case "BlobPlayer_Pink_0":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = pinkanim as RuntimeAnimatorController;
                break;

            case "Detective_8":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = skeletonANim as RuntimeAnimatorController;
                break;

            case "Detective_0":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = detectiveanim as RuntimeAnimatorController;
                break;        

            case "idle":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = GoodSkinanim as RuntimeAnimatorController;
                break;

            case "slime-walk-01":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = astronoutAnim as RuntimeAnimatorController;
                break;

            case "Astronaut_7":
                PlayerObject.GetComponent<Animator>().runtimeAnimatorController = SlimeAnim as RuntimeAnimatorController;
                break;
        }
    }

} 
