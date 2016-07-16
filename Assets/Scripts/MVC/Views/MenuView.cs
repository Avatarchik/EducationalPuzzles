using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
	public RectTransform MainPanel;
	public RectTransform SettingPanel;
	public RectTransform DevelopersPanel;
	public RectTransform CongirmPanel;

	public Button ButtonNewGame;
	public Button ButtonSetting;
	public Button ButtonDevelopers;
	public Button ButtonExit;
	public Button ButtonConfirmExit;

	public List<Button> InMenu; 

	void Start()
	{
		ButtonNewGame.onClick.AddListener(delegate { SceneManager.LoadScene("GameScene"); });
		ButtonSetting.onClick.AddListener(delegate { OpenPanel(SettingPanel); });
		ButtonDevelopers.onClick.AddListener(delegate { OpenPanel(DevelopersPanel); });
		ButtonExit.onClick.AddListener(delegate { OpenPanel(CongirmPanel); });
		ButtonConfirmExit.onClick.AddListener(Application.Quit);

		foreach (var button in InMenu)
		{
			button.onClick.AddListener(OpenMainPanel);
		}

		OpenMainPanel();
	}

	private void OpenPanel(RectTransform openPanel)
	{
		MainPanel.gameObject.SetActive(false);
		openPanel.gameObject.SetActive(true);
	}

	private void OpenMainPanel()
	{
		MainPanel.gameObject.SetActive(true);
		SettingPanel.gameObject.SetActive(false);
		DevelopersPanel.gameObject.SetActive(false);
		CongirmPanel.gameObject.SetActive(false);
	}

}
