using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleGridElement Prefab;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}

	void Start()
	{
		int sizeCell = Screen.width/3;
		GetComponent<GridLayoutGroup>().cellSize = new Vector2(sizeCell,sizeCell);
	}
}

public class UIPuzzleGridViewModel
{
	public MathOperator MathOperator;

	public UIPuzzleGridViewModel(MathOperator MathOperator)
	{
		this.MathOperator = MathOperator;
	}
}
