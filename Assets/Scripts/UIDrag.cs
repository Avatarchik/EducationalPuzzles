using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public static GameObject ItemBeingDragged;
	private Vector2 _startPosition;
	public GridLayoutGroup GridLayoutGroup;
	public CanvasGroup CanvasGroup;

	public void OnBeginDrag(PointerEventData eventData)
	{
		ItemBeingDragged = gameObject;
		_startPosition = transform.position;
		GridLayoutGroup.enabled = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		CanvasGroup.blocksRaycasts = false;
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		CanvasGroup.blocksRaycasts = true;
		GridLayoutGroup.enabled = true;
		transform.position = _startPosition;
	}
}
