using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

	public Action OnSettingAccept;

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
				app.Model.UserModel.SetModeGame(ModeGame.Normal);
				break;
			case 1:
				app.Model.UserModel.SetModeGame(ModeGame.Record);
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
				app.Model.UserModel.SetPuzzleElements(3);
				break;
			case 1:
				app.Model.UserModel.SetPuzzleElements(4);
				break;
		}
	}

	private void OnChangeMax(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.UserModel.SetMax(10);
				break;
			case 1:
				app.Model.UserModel.SetMax(20);
				break;
			case 2:
				app.Model.UserModel.SetMax(30);
				break;
			case 3:
				app.Model.UserModel.SetMax(40);
				break;
			case 4:
				app.Model.UserModel.SetMax(50);
				break;
		}
	}

	private void OnChangeOperator(int index)
	{
		switch (index)
		{
			case 0:
				app.Model.UserModel.SetModeOperation(ModeOperation.Addition);
				break;
			case 1:
				app.Model.UserModel.SetModeOperation(ModeOperation.Deduction);
				break;
			case 2:
				app.Model.UserModel.SetModeOperation(ModeOperation.Multiplication);
				break;
			case 3:
				app.Model.UserModel.SetModeOperation(ModeOperation.Division);
				break;
		}
	}
}
