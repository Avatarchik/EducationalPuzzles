using UnityEngine;

public class GameView : GameElement
{

	public SettingView SettingView;
	public PuzzleView PuzzleView;
	public RectTransform ConfigurationsPanel;

	void Start()
	{
		SettingView.gameObject.SetActive(true);
		PuzzleView.gameObject.SetActive(false);
		ConfigurationsPanel.gameObject.SetActive(false);

		SettingView.OnSettingAccept += OnSettingAccept;
		PuzzleView.OnPuzzleCollect += OnPuzzleCollect;
	}

	private void OnPuzzleCollect()
	{
		ConfigurationsPanel.gameObject.SetActive(true);
	}

	private void OnSettingAccept()
	{
		SettingView.gameObject.SetActive(false);
		PuzzleView.gameObject.SetActive(true);
	}
}
