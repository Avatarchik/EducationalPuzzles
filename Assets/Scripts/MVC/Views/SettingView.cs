using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingView : GameElement
{
	public Dropdown DropdownOperator;
	public Dropdown DropdownMax;
	public Dropdown DropdownMaxElements;
	public Dropdown DropdownModeGame;

	public Button ButtonPlay;
	public Button ButtonBack;

	public event Action OnSettingAccept;

	void Start()
	{
		DropdownOperator.onValueChanged.AddListener(OnChangeOperator);
		DropdownMax.onValueChanged.AddListener(OnChangeMax);
		DropdownMaxElements.onValueChanged.AddListener(OnChangeMaxElements);
		DropdownModeGame.onValueChanged.AddListener(OnChangeModeGame);

		DropdownOperator.value = 0;
		DropdownMax.value = 0;
		DropdownMaxElements.value = 0;
		DropdownModeGame.value = 0;

		ButtonPlay.onClick.AddListener(SettingAccept);
		ButtonBack.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene");});
	}

	private void OnChangeModeGame(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.PuzzleModel.SetModeGame(ModeGame.Normal);
				break;
			case 1:
				app.Model.PuzzleModel.SetModeGame(ModeGame.Record);
				break;
		}
	}

	private void SettingAccept()
	{
		//проверка на ведённые данные
		OnSettingAccept();
	}

	private void OnChangeMaxElements(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.PuzzleModel.SetPuzzleElements(3);
				break;
			case 1:
				app.Model.PuzzleModel.SetPuzzleElements(4);
				break;
		}
	}

	private void OnChangeMax(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.PuzzleModel.SetMax(10);
				break;
			case 1:
				app.Model.PuzzleModel.SetMax(20);
				break;
			case 2:
				app.Model.PuzzleModel.SetMax(30);
				break;
			case 3:
				app.Model.PuzzleModel.SetMax(40);
				break;
			case 4:
				app.Model.PuzzleModel.SetMax(50);
				break;
		}
	}

	private void OnChangeOperator(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.PuzzleModel.SetModeOperation(ModeOperation.Addition);
				break;
			case 1:
				app.Model.PuzzleModel.SetModeOperation(ModeOperation.Deduction);
				break;
			case 2:
				app.Model.PuzzleModel.SetModeOperation(ModeOperation.Multiplication);
				break;
			case 3:
				app.Model.PuzzleModel.SetModeOperation(ModeOperation.Division);
				break;
		}
	}
}
