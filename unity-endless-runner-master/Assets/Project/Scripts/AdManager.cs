using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string androidAdUnitId = "Rewarded_Android";
    private string adUnitId;

    private PlayerController playerController;

    void Awake()
    {
        adUnitId = androidAdUnitId;
        playerController = FindObjectOfType<PlayerController>();
    }

    public void ShowRewardedAd()
    {
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId) { }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {placementId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string placementId) { }
    public void OnUnityAdsShowClick(string placementId) { }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adUnitId) && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            playerController.Revive();
        }
    }
}
