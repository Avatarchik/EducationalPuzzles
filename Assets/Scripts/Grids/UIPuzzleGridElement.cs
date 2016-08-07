using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIPuzzleGridElement : UGUIAbstractGridElement<UIPuzzleGridViewModel>
{

	public Text Anser;
	public Image Image;
	public LayoutElement LayoutElement;
	public CanvasGroup CanvasGroup;

	private Color _startColor;////временные меры надо убрать этот говнокод

	public override void Initialize(UIPuzzleGridViewModel data)
	{
		Anser.text = data.MathOperator.Result.ToString();
		_startColor = Image.color;
	}

	public void ChangeViewTrueAnser()
	{
		LayoutElement.ignoreLayout = true;

		Image.color = Color.green;
		DOTween.To(x => CanvasGroup.alpha = x, 1, 0, 1f).OnComplete(OnComplite);

		CanvasGroup.blocksRaycasts = false;
	}

	public void ChangeViewFalseAnser()
	{
		Image.color = Color.red;
		DOTween.To(() => Image.color, x => Image.color = x, _startColor, 1f);
	}

	private void OnComplite()
	{
		Destroy(gameObject);
	}

	public override void UpdateElementView()
	{
		Image.color = _startColor;
	}
}
