using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PuzzleView : GameElement
{
	
	public Button GeneratePuzzle;
	public int Max;

	public UIPuzzleGrid PuzzleGrid;
	public UIPuzzleAnserGrid PuzzleAnserGrid;

	void Start () 
	{
		GeneratePuzzle.onClick.AddListener(Generate);
		app.Model.PuzzleModel.OnGeneratePuzzleElements += OnGenerate;
		PuzzleGrid.OnSelectElement += OnSelectElement;
	}

	private void OnSelectElement(UGUIAbstractGridElement<UIPuzzleGridViewModel> element)
	{
		Debug.Log(element.GetData().MathOperator.Result);
	}

	private void OnGenerate()
	{
		var viewModel = app.Model.PuzzleModel.GetPuzzleElements().Select(e => new UIPuzzleGridViewModel(e));
		PuzzleGrid.Initialize(viewModel);

		PuzzleAnserGrid.Initialize(viewModel);

		List<MathOperator> test;
		test = app.Model.PuzzleModel.GetPuzzleElements();
		foreach (var VARIABLE in test)
		{
			Debug.Log(VARIABLE.GetTemplate() + " " + VARIABLE.Result);
		}
	}

	private void Generate()
	{
		app.Model.PuzzleModel.GenerateInts(app.Model.UserModel.GetMode(), Max);
	}
}
