using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{
    public enum Sound
    {
        Jump,
        PowerUp,
        JumpPad,
        Die,
        boost,
        FullChargeBoost,
        BuySkin,
        nextskin,
        previousskin,
    }
    
    private static Dictionary<Sound, float> soundtimerDictionary;
    public static void initialize()
    {
       soundtimerDictionary = new Dictionary<Sound, float>();
        soundtimerDictionary[Sound.PowerUp] = 0f;
    }
    public static void PlaySound(Sound sound)
    {
        if (canPlaySound(sound))
        {
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(GetAudioClip(sound));
            Object.Destroy(soundGameObject, 1f);
        }
    }
    private static bool canPlaySound(Sound sound)
    {
        switch (sound)
        {
            default:
                return true;

            case Sound.PowerUp:
                if (soundtimerDictionary.ContainsKey(sound))
                {
                    float lasttimePlayed = soundtimerDictionary[sound];
                    float poweruptimemax = 0.5f;
                    if(lasttimePlayed+ poweruptimemax < Time.time)
                    {
                        soundtimerDictionary[sound] = Time.time;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                   return true;
                }
                
        }
    }
    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameAssets.SoundAudioCLip soundaudioclip in GameAssets.Getinstance().SoundAudioArray)
        {
            if (soundaudioclip.sound == sound)
            {
                return soundaudioclip.audioclip;
            }
           
            

        }
        Debug.LogError("sound" + sound + "notfound");
        return null;
    }
    
}
