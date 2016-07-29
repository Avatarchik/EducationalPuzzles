using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
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
	
	public Text RecordText;
	private int _record = 0;

	public RectTransform EndPanel;

	private int _indexChild;
	private List<UIPuzzleGridElement> _puzzleGridElementsForDestroy = new List<UIPuzzleGridElement>(); 

	void Start () 
	{
		EndPanel.gameObject.SetActive(false);

		ButtonMenu.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene"); });
		ButtonHint.onClick.AddListener(ConfirmAdvertising);
		app.Model.PuzzleModel.OnGeneratePuzzleElements += OnGenerateElements;
		app.Model.PuzzleModel.OnGeneratePuzzleElement += OnGenerateElement;
		PuzzleGrid.OnSelectElement += OnSelectElement;
		PuzzleGrid.SetCellSize(app.Model.UserModel.CountPuzzleElements);
		PuzzleAnserGrid.SetCellSize(app.Model.UserModel.CountPuzzleElements);
		Initialize();
	}

	private void OnGenerateElement(MathOperator mathOperator)
	{
		UIPuzzleGridElement element = PuzzleGrid.InitializeElement(new UIPuzzleGridViewModel(mathOperator), _indexChild);
		element.GetComponent<UIDrop>().OnDropAction += OnDropElement;
		DOTween.To(x => element.GetComponent<CanvasGroup>().alpha = x, 0, 1, 1f);
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
			return;
		}

		List<UIPuzzleGridViewModel> viewModelAnser = new List<UIPuzzleGridViewModel>
		{
			new UIPuzzleGridViewModel(randElement)
		};

		PuzzleAnserGrid.Initialize(viewModelAnser);

	}

	private void OnDropElement(GameObject obj)
	{
		var currElement = obj.GetComponent<UIPuzzleGridElement>();
		var currTemp = UIDrag.ItemBeingDragged.GetComponent<UIPuzzleAnserGridElement>();

		if (currElement == null || currTemp == null) return;

		if (!currElement.GetData().MathOperator.Result.ToString().Equals(currTemp.GetData().MathOperator.Result.ToString()))
			return;

		if (app.Model.UserModel.GetModeGame() == ModeGame.Normal)
		{

			app.Controller.PuzzleController.DeleteElement(currElement.GetData().MathOperator);

			currElement.ChangeColor();
			DOTween.To(x => obj.GetComponent<CanvasGroup>().alpha = x, 1, 0, 1f);

			GenerateRandAnser();
		}

		if (app.Model.UserModel.GetModeGame() == ModeGame.Record)
		{

			app.Controller.PuzzleController.DeleteElement(currElement.GetData().MathOperator);
			_record += currElement.GetData().MathOperator.Result;
			RecordText.text = _record.ToString();

			for (int i = 0; i < PuzzleGrid.transform.childCount; i++)
			{
				if (PuzzleGrid.transform.GetChild(i) == currElement.transform)
				{
					_indexChild = i;
					break;
				}
			}

			currElement.LayoutElement.ignoreLayout = true;
			_puzzleGridElementsForDestroy.Add(currElement);

			currElement.ChangeColor();
			DOTween.To(x => obj.GetComponent<CanvasGroup>().alpha = x, 1, 0, 1f).OnComplete(OnComplite);

			obj.GetComponent<CanvasGroup>().blocksRaycasts = false;

			app.Controller.PuzzleController.GenerateInt();

			GenerateRandAnser();
		}
	}

	private void OnComplite()
	{
		Debug.Log(_puzzleGridElementsForDestroy.First().name);
		Destroy(_puzzleGridElementsForDestroy.First().gameObject);//не удаляет все элементы, хз почему

	}
}
