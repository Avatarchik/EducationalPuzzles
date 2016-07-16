using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingView : GameElement
{

	public Button ButtonAddition;
	public Button ButtonDeduction;
	public Button ButtonMultiplication;
	public Button ButtonDivision;

	public Button ButtonMax10;
	public Button ButtonMax20;
	public Button ButtonMax30;
	public Button ButtonMax40;
	public Button ButtonMax50;

	public Button ButtonPlay;
	public Button ButtonBack;

	public PuzzleView PuzzleView;

	void Start()
	{
		ButtonAddition.onClick.AddListener(delegate { app.Model.UserModel.SetMode(Mode.Addition);});
		ButtonDeduction.onClick.AddListener(delegate { app.Model.UserModel.SetMode(Mode.Deduction);});
		ButtonMultiplication.onClick.AddListener(delegate { app.Model.UserModel.SetMode(Mode.Multiplication);});
		ButtonDivision.onClick.AddListener(delegate { app.Model.UserModel.SetMode(Mode.Division);});

		ButtonMax10.onClick.AddListener(delegate { app.Model.UserModel.SetMax(10);});
		ButtonMax20.onClick.AddListener(delegate { app.Model.UserModel.SetMax(20);});
		ButtonMax30.onClick.AddListener(delegate { app.Model.UserModel.SetMax(30);});
		ButtonMax40.onClick.AddListener(delegate { app.Model.UserModel.SetMax(40);});
		ButtonMax50.onClick.AddListener(delegate { app.Model.UserModel.SetMax(50);});

		ButtonPlay.onClick.AddListener(StartGame);
		ButtonBack.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene");});
	}

	private void StartGame()
	{
		PuzzleView.gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
