using UnityEngine;
using UnityEngine.UI;

public class UIPuzzleGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleGridElement Prefab;
	public RectTransform Rect;
	public GridLayoutGroup GridLayoutGroup;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}

	public void SetCellSize(int countWidth)
	{
		int sizeCell = (int) (Rect.rect.width / countWidth);
		GridLayoutGroup.cellSize = new Vector2(sizeCell, sizeCell);
		GridLayoutGroup.constraintCount = countWidth;
	}

	public UIPuzzleGridElement InitializeElement(UIPuzzleGridViewModel viewModel, int indexChild)
	{
		var element = base.NewElementInstance(Prefab);
		base.InitializeElement(element,viewModel);
		element.transform.SetSiblingIndex(indexChild);
		gridElements.Add(element);
		return element as UIPuzzleGridElement;
	}

	public void DeleteElement(UIPuzzleGridElement element)
	{
		gridElements.Remove(element);
	}

	public void EnableLayout()
	{
		GridLayoutGroup.enabled = false;
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
