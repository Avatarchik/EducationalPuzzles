using UnityEngine;
using UnityEngine.UI;

public class UIPuzzleAnserGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleAnserGridElement Prefab;

	public RectTransform Rect;
	public GridLayoutGroup GridLayoutGroup;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}

	public void SetCellSize(int countWidth)
	{
		int sizeCell = (int)(Rect.rect.width / countWidth);
		GridLayoutGroup.cellSize = new Vector2(sizeCell, sizeCell);
	}
}
