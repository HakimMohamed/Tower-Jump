using UnityEngine.Advertisements;
using System;
using UnityEngine;

public class AdsManager : MonoBehaviour,IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4693240";
#elif UNITY_ANDROID
    private string gameId = "4693241";
#endif

    Action OnRewardedAdSuccess;

    private void Start()
    {
        Advertisement.Initialize(gameId, false);
        Advertisement.AddListener(this);
    }

    public void PlayRewardedAd(Action onSuccess)
    {
        
        OnRewardedAdSuccess =onSuccess;
        if (Advertisement.IsReady("Rewarded_Android"))
        {
            Advertisement.Show("Rewarded_Android");
        }
        else if (Advertisement.IsReady("Rewarded_iOS"))
        {
            Advertisement.Show("Rewarded_iOS");
        }

        else
        {
            Debug.Log("ad is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("ads error" + message);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
         Debug.Log("video Started");
    }




    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished|| placementId == "Rewarded_iOS" && showResult == ShowResult.Finished)
        {                 
            OnRewardedAdSuccess.Invoke();
        }
    }

}
