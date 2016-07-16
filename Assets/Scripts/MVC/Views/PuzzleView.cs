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
		GeneratePuzzle.onClick.AddListener(Initialize);
		app.Model.PuzzleModel.OnGeneratePuzzleElements += OnGenerate;
		PuzzleGrid.OnSelectElement += OnSelectElement;
		Initialize();
	}

	public void Initialize()
	{
		app.Controller.PuzzleController.GenerateInts();
	}

	private void OnSelectElement(UGUIAbstractGridElement<UIPuzzleGridViewModel> element)
	{
		Debug.Log(element.GetData().MathOperator.Result);
	}

	private void OnGenerate()
	{
		var viewModelPuzzle = app.Model.PuzzleModel.GetPuzzleElements().Select(e => new UIPuzzleGridViewModel(e));
		PuzzleGrid.Initialize(viewModelPuzzle);

		List<UIPuzzleGridViewModel> viewModelAnser = new List<UIPuzzleGridViewModel>
		{
			new UIPuzzleGridViewModel(app.Model.PuzzleModel.GetRandElement())
		};

		PuzzleAnserGrid.Initialize(viewModelAnser);

		foreach (var element in PuzzleGrid.GetElements())
		{
			element.GetComponent<UIDrop>().OnDropAction += OnDropElement;
		}
	}

	private void OnDropElement(GameObject obj)
	{
		var cuurElement = obj.GetComponent<UIPuzzleGridElement>();
		var currTemp = UIDrag.ItemBeingDragged.GetComponent<UIPuzzleAnserGridElement>();
		if (cuurElement == null || currTemp == null) return;

		if (!cuurElement.GetData().MathOperator.Result.ToString().Equals(currTemp.GetData().MathOperator.Result.ToString()))
			return;

		app.Controller.PuzzleController.DeleteElement(currTemp.GetData().MathOperator);

		obj.GetComponent<CanvasGroup>().alpha = 0;

		List<UIPuzzleGridViewModel> viewModelAnser = new List<UIPuzzleGridViewModel>
		{
			new UIPuzzleGridViewModel(app.Model.PuzzleModel.GetRandElement())
		};

		PuzzleAnserGrid.Initialize(viewModelAnser);
	}
}
