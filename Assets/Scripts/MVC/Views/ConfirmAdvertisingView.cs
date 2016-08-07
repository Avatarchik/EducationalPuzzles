using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ConfirmAdvertisingView : GameElement
{

	public Button ButtonYes;
	public Button ButtonNo;

	void Start()
	{
		ButtonNo.onClick.AddListener(delegate { gameObject.SetActive(false); });
		ButtonYes.onClick.AddListener(ShowRewrdedVideo);
	}

	private void ShowRewrdedVideo()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
			case ShowResult.Finished:
				Debug.Log("The ad was successfully shown.");
				//
				app.Model.PuzzleModel.AppledTip();
				// YOUR CODE TO REWARD THE GAMER
				// Give coins etc.
				break;
			case ShowResult.Skipped:
				Debug.Log("The ad was skipped before reaching the end.");
				break;
			case ShowResult.Failed:
				Debug.LogError("The ad failed to be shown.");
				break;
		}
	}
}
