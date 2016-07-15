using UnityEngine;
using System.Collections;

public class UIPuzzleAnserGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleAnserGridElement Prefab;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
	}
}
