using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    string _androidGameId;
    [SerializeField]
    string _iOsGameId;
    [SerializeField]
    bool _testMode = true;
    [SerializeField]
    bool _enablePerPlacementMode = true;
    string _gameId;
    [SerializeField]
    IntesrtitialAd interstitialAd;
    [SerializeField]
    RewardedAd rewardedAd;
    //[SerializeField]
    //BannerAd bannerAd;

    public static AdsManager instance;

    void Awake()
    {
        instance = this;
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOsGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, _enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void ShowInterstitialAd() => interstitialAd.ShowAd();
    public void ShowRewardedAd() => rewardedAd.ShowAd();
    //public void ShowBannerAd() => bannerAd.ShowBannerAd();
}
