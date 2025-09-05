using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleAdResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleAdResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            GameManager.Instance.AddScore(50);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
