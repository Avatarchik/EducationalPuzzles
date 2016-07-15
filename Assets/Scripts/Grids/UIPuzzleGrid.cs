using UnityEngine;
using System.Collections;

public class UIPuzzleGrid : UGUIAbstractGrid<UIPuzzleGridViewModel>
{

	public UIPuzzleGridElement Prefab;

	public override UGUIAbstractGridElement<UIPuzzleGridViewModel> GetPrefab(UIPuzzleGridViewModel data)
	{
		return Prefab;
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
