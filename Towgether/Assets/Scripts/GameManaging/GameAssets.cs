using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets instance;

    public static GameAssets Getinstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    [Header("Platforms")]
    public Transform platform;
    public Transform RedPlatform;
    public Transform OutlinePlatformPlatform;
    public Transform DissolvingPlatform;

    [Header("gameAssets")]
    public Transform Jump_pad;
    public Transform Trap;
    public Transform Explosion;
    public Transform PowerUp;

    [Header("Sound")]
    public SoundAudioCLip[] SoundAudioArray;

    [System.Serializable]
    public class SoundAudioCLip {

        public SoundManager.Sound sound;
        public AudioClip audioclip;
        
    }


}
