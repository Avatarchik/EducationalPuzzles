using UnityEngine.UI;

public class UIPuzzleAnserGridElement : UGUIAbstractGridElement<UIPuzzleGridViewModel>
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
