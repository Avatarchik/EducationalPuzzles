using UnityEngine;
using System.Collections;
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
		
	}
}
