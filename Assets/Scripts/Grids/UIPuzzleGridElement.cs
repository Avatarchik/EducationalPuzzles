using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIPuzzleGridElement : UGUIAbstractGridElement<UIPuzzleGridViewModel>
{

	public Text Anser;
	public Image Image;
	public LayoutElement LayoutElement;

	public override void Initialize(UIPuzzleGridViewModel data)
	{
		Anser.text = data.MathOperator.Result.ToString();
	}

	public void ChangeColor()
	{
		Image.color = Color.green;
	}

	public override void UpdateElementView()
	{
	}
}
