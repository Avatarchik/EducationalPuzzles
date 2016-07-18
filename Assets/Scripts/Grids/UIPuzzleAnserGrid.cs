using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleAnserGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleAnserGridElement Prefab;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}

	void Start()
	{
		int sizeCell = Screen.width / 3;
		GetComponent<GridLayoutGroup>().cellSize = new Vector2(sizeCell, sizeCell);
	}
}
