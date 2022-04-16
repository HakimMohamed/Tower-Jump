using UnityEngine.Advertisements;
using System;
using UnityEngine;

public class  AdsManager : MonoBehaviour,IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "4693240";
#elif UNITY_ANDROID
    private string gameId = "4693241";
#endif

    [SerializeField] GameObject GameOverMenu;

    public static AdsManager instance { get; private set; }
    Action OnRewardedAdSuccess;

    private void Start()
    {
        DontDestroyOnLoad(this);

        Advertisement.Initialize(gameId, true);
        Advertisement.AddListener(this);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
            //Debug.Log("ad is not ready");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        //Debug.Log("Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
       // GameOverMenu.SetActive(false);
    }

    public void OnUnityAdsDidStart(string placementId)
    {
         //Debug.Log("video Started");
    }




    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished|| placementId == "Rewarded_iOS" && showResult == ShowResult.Finished)
        {                 
            OnRewardedAdSuccess.Invoke();
        }
    }

}
