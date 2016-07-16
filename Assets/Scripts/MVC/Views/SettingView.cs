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

	public Button ButtonPlay;
	public Button ButtonBack;

	public Action OnSettingAccept;

	void Start()
	{
		DropdownOperator.onValueChanged.AddListener(OnChangeOperator);
		DropdownMax.onValueChanged.AddListener(OnChangeMax);

		DropdownOperator.value = 0;
		DropdownMax.value = 0;

		ButtonPlay.onClick.AddListener(SettingAccept);
		ButtonBack.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene");});
	}

	private void SettingAccept()
	{
		//проверка на ведённые данные
		OnSettingAccept();
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
				app.Model.UserModel.SetMode(Mode.Addition);
				break;
			case 1:
				app.Model.UserModel.SetMode(Mode.Deduction);
				break;
			case 2:
				app.Model.UserModel.SetMode(Mode.Multiplication);
				break;
			case 3:
				app.Model.UserModel.SetMode(Mode.Division);
				break;
		}
	}
}
