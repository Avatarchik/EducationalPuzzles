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

	public void SetCellSize(int countWidth)
	{
		int sizeCell = Screen.width / countWidth;
		GetComponent<GridLayoutGroup>().cellSize = new Vector2(sizeCell, sizeCell);
		GetComponent<GridLayoutGroup>().constraintCount = countWidth;
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
