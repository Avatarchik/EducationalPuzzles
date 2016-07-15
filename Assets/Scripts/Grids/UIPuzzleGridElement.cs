using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleGridElement : UGUIAbstractGridElement<UIPuzzleGridViewModel>
{

	public Text Temp;

	public override void Initialize(UIPuzzleGridViewModel data)
	{
		Temp.text = data.MathOperator.GetTemplate();
	}

	public override void UpdateElementView()
	{

	}
}
