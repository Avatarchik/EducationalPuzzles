using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIDrop : MonoBehaviour, IDropHandler
{

	public Action<GameObject> OnDropAction;

	public void OnDrop(PointerEventData eventData)
	{
		OnDropAction(gameObject);
	}
}
