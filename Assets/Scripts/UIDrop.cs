using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDrop : MonoBehaviour, IDropHandler
{

	public Action<GameObject> OnDropAction = delegate {};
	public GridLayoutGroup GridLayoutGroup;

	public void OnDrop(PointerEventData eventData)
	{
		GridLayoutGroup.enabled = true;
		OnDropAction(gameObject);
	}
}
