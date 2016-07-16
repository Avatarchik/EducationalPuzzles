using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleGridElement : UGUIAbstractGridElement<UIPuzzleGridViewModel>
{

	public Text Anser;

	public override void Initialize(UIPuzzleGridViewModel data)
	{
		Anser.text = data.MathOperator.Result.ToString();
	}

	public override void UpdateElementView()
	{

	}
}
