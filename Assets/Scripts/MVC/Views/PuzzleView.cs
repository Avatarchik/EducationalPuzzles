using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleView : GameElement
{

	public UIPuzzleGrid PuzzleGrid;
	public UIPuzzleAnserGrid PuzzleAnserGrid;

	public Image Back;

	public Button ButtonMenu;
	public Button ButtonHint;

	public ConfirmAdvertisingView ConfirmPanel;

	public event Action OnPuzzleCollect;
	
	public Text RecordText;
	private int _record;

	private int _indexChild;
	private List<UIPuzzleGridElement> _tipElements = new List<UIPuzzleGridElement>();

	public Text ErrorText;
	public int Errors;
	private int _countError;

	public RectTransform TutorPanel;
	public Button CloseTutor;//перенести

	void Start () 
	{

		ButtonMenu.onClick.AddListener(delegate { SceneManager.LoadScene("MenuScene"); });
		ButtonHint.onClick.AddListener(ConfirmAdvertising);
//		ButtonHint.onClick.AddListener(OnAppledTip);
		app.Model.PuzzleModel.OnGeneratePuzzleElements += OnGenerateElements;
		app.Model.PuzzleModel.OnGeneratePuzzleElement += OnGenerateElement;
		app.Model.PuzzleModel.OnAppledTip += OnAppledTip;
		PuzzleGrid.OnSelectElement += OnSelectElement;

		PuzzleGrid.SetCellSize(app.Model.PuzzleModel.CountPuzzleElements);
		PuzzleAnserGrid.SetCellSize(app.Model.PuzzleModel.CountPuzzleElements);
		Initialize();

		if (app.Model.PuzzleModel.GetModeGame() == ModeGame.Normal)
		{
			RecordText.gameObject.SetActive(false);
		}

		ErrorText.text = Errors.ToString();
		TutorPanel.gameObject.SetActive(false);
		CloseTutor.onClick.AddListener(delegate {TutorPanel.gameObject.SetActive(false);});
	}

	private void OnAppledTip()
	{
		var currAnser = PuzzleAnserGrid.GetElements().FirstOrDefault();

		foreach (var element in PuzzleGrid.GetElements())
		{
			if (currAnser.GetData().MathOperator.Result.Equals(element.GetData().MathOperator.Result))
			{
				((UIPuzzleGridElement) element).Image.color = Color.green;
				_tipElements.Add(element as UIPuzzleGridElement);
			}
		}
		ConfirmPanel.gameObject.SetActive(false);
		//и отключать кнопку получения подсказок
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
		Back.sprite = app.Model.PuzzleModel.GetRandomBack();
		app.Model.PuzzleModel.GenerateInts();
	}

	private void OnSelectElement(UGUIAbstractGridElement<UIPuzzleGridViewModel> element)
	{
		Debug.Log(element.GetData().MathOperator.Result);
		TutorPanel.gameObject.SetActive(true);
		PuzzleGrid.OnSelectElement -= OnSelectElement;
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

	private void OnDropElement(GameObject dropElement)
	{
		var currElement = dropElement.GetComponent<UIPuzzleGridElement>();
		var currTemp = UIDrag.ItemBeingDragged.GetComponent<UIPuzzleAnserGridElement>();

		if (currElement == null || currTemp == null) return;

		if (!currElement.GetData().MathOperator.Result.ToString().Equals(currTemp.GetData().MathOperator.Result.ToString()))
		{
			currElement.ChangeViewFalseAnser();
			_countError++;
			ErrorText.text = (Errors - _countError).ToString();
			if (_countError >= Errors)
			{
				PuzzleAnserGrid.gameObject.SetActive(false);
				OnPuzzleCollect();
			}
			return;
		}

		foreach (var element in _tipElements)
		{
			element.UpdateElementView();
		}

		_tipElements.Clear();

		if (app.Model.PuzzleModel.GetModeGame() == ModeGame.Normal)
		{

			app.Controller.PuzzleController.DeleteElement(currElement.GetData().MathOperator);

			PuzzleGrid.EnableLayout();
			currElement.ChangeViewTrueAnser();
			
		}

		if (app.Model.PuzzleModel.GetModeGame() == ModeGame.Record)
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

			PuzzleGrid.DeleteElement(currElement);
			currElement.ChangeViewTrueAnser();

			app.Model.PuzzleModel.GenerateInt();
		}

		PuzzleGrid.DeleteElement(currElement);
		GenerateRandAnser();
	}
}
