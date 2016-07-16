using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuView : MonoBehaviour
{
	public RectTransform MainPanel;
	public RectTransform SettingPanel;
	public RectTransform DevelopersPanel;

	public Button ButtonNewGame;
	public Button ButtonSetting;
	public Button ButtonDevelopers;
	public Button ButtonExit;

	void Start()
	{
		ButtonNewGame.onClick.AddListener(delegate {SceneManager.LoadScene("GameScene");});
		ButtonSetting.onClick.AddListener(delegate { TriggerPanel(MainPanel, SettingPanel);});
		ButtonDevelopers.onClick.AddListener(delegate { TriggerPanel(MainPanel, DevelopersPanel); });
		ButtonExit.onClick.AddListener(Application.Quit);
		SettingPanel.gameObject.SetActive(false);
		DevelopersPanel.gameObject.SetActive(false);
		MainPanel.gameObject.SetActive(true);
	}

	private void TriggerPanel(RectTransform offPanel, RectTransform onPanel)
	{
		offPanel.gameObject.SetActive(false);
		onPanel.gameObject.SetActive(true);
	}

}
