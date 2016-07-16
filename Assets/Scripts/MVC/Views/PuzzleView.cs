using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleView : GameElement
{

	public UIPuzzleGrid PuzzleGrid;
	public UIPuzzleAnserGrid PuzzleAnserGrid;

	public Button ButtonMenu;
	public Button ButtonHint;

	public ConfirmAdvertisingView ConfirmPanel;

	public Action OnPuzzleCollect;

	void Start () 
	{
		ButtonMenu.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene"); });
		ButtonHint.onClick.AddListener(ConfirmAdvertising);
		app.Model.PuzzleModel.OnGeneratePuzzleElements += OnGenerateElements;
		PuzzleGrid.OnSelectElement += OnSelectElement;
		Initialize();
	}

	private void ConfirmAdvertising()
	{
		ConfirmPanel.gameObject.SetActive(true);
	}

	public void Initialize()
	{
		app.Controller.PuzzleController.GenerateInts();
	}

	private void OnSelectElement(UGUIAbstractGridElement<UIPuzzleGridViewModel> element)
	{
		Debug.Log(element.GetData().MathOperator.Result);
	}

	private void OnGenerateElements()
	{
		var viewModelPuzzle = app.Model.PuzzleModel.GetPuzzleElements().Select(e => new UIPuzzleGridViewModel(e));
		PuzzleGrid.Initialize(viewModelPuzzle);

		foreach (var element in PuzzleGrid.GetElements())
		{
			element.GetComponent<UIDrop>().OnDropAction += OnDropElement;
		}

		GenerateRandAnser();
	}

	public void GenerateRandAnser()
	{
		var randElement = app.Model.PuzzleModel.GetRandElement();

		if (randElement == null)
		{
			OnPuzzleCollect();
			PuzzleAnserGrid.gameObject.SetActive(false);
		}

		List<UIPuzzleGridViewModel> viewModelAnser = new List<UIPuzzleGridViewModel>
		{
			new UIPuzzleGridViewModel(randElement)
		};

		PuzzleAnserGrid.Initialize(viewModelAnser);

	}

	private void OnDropElement(GameObject obj)
	{
		var cuurElement = obj.GetComponent<UIPuzzleGridElement>();
		var currTemp = UIDrag.ItemBeingDragged.GetComponent<UIPuzzleAnserGridElement>();

		if (cuurElement == null || currTemp == null) return;

		if (!cuurElement.GetData().MathOperator.Result.ToString().Equals(currTemp.GetData().MathOperator.Result.ToString()))
			return;

		app.Controller.PuzzleController.DeleteElement(cuurElement.GetData().MathOperator);

		obj.GetComponent<CanvasGroup>().alpha = 0;

		GenerateRandAnser();
	}
}
