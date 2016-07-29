using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	public static GameObject ItemBeingDragged;
	private Vector2 _startPosition;
	public GridLayoutGroup GridLayoutGroup;

	public void OnBeginDrag(PointerEventData eventData)
	{
		ItemBeingDragged = gameObject;
		_startPosition = transform.position;
		GridLayoutGroup.enabled = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		GetComponent<CanvasGroup>().blocksRaycasts = false;
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		GetComponent<CanvasGroup>().blocksRaycasts = true;
		GridLayoutGroup.enabled = true;
		transform.position = _startPosition;
	}
}
