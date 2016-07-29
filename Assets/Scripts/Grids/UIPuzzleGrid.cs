using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleGridElement Prefab;

	public RectTransform Rect;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}

	public void SetCellSize(int countWidth)
	{
		int sizeCell = (int) (Rect.rect.width / countWidth);
		GetComponent<GridLayoutGroup>().cellSize = new Vector2(sizeCell, sizeCell);
		GetComponent<GridLayoutGroup>().constraintCount = countWidth;
	}

	public UIPuzzleGridElement InitializeElement(UIPuzzleGridViewModel viewModel, int indexChild)
	{
		var element = base.NewElementInstance(Prefab);
		base.InitializeElement(element,viewModel);
		element.transform.SetSiblingIndex(indexChild);
		return element as UIPuzzleGridElement;
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
