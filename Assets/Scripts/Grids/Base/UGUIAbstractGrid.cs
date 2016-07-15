using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;


[RequireComponent(typeof(GridLayoutGroup))]

public abstract class UGUIAbstractGrid<TData> : MonoBehaviour where TData : class
{

	protected List<UGUIAbstractGridElement<TData>> gridElements = new List<UGUIAbstractGridElement<TData>>();

	public Action<UGUIAbstractGridElement<TData>> OnSelectElement = delegate { };


	public IEnumerable<UGUIAbstractGridElement<TData>> GetElements()
	{
		return gridElements;
	}

	public virtual void Initialize(IEnumerable<TData> dataList)
	{
		Clear();

		List<UGUIAbstractGridElement<TData>> prefabs = new List<UGUIAbstractGridElement<TData>>();

		for (int i = 0; i < dataList.Count(); i++)
		{
			UGUIAbstractGridElement<TData> element = null;

			try
			{
				var data = dataList.ElementAt(i);

				if (data == null)
					throw new Exception("Data element of type <" + typeof(TData) + "> on index " + i + " is null!");

				var prefab = GetPrefab(data);

				if (prefab == null)
					throw new Exception("Prefab for data [" + data + "] is null!");

				element = NewElementInstance(prefab);

				if (element == null)
					throw new Exception("Failed to recieve instance element from prefab [" + prefab + "]");

				element.name = typeof(TData).Name + "." + i;

				InitializeElement(element, data);

				gridElements.Add(element);

				if (!prefabs.Contains(GetPrefab(data)))
					prefabs.Add(GetPrefab(data));
			}
			catch (Exception)
			{
				// Плохо проинициализировавшиеся объекты отключаем
				if (element != null)
				{
					gridElements.Remove(element);
				}
			}
		}

		prefabs.Add(GetPrefab(null));

		foreach (var prefab in prefabs)
			if (prefab != null) prefab.gameObject.SetActive(false);
	}

	protected virtual void InitializeElement(UGUIAbstractGridElement<TData> element, TData data)
	{
		element.InitializeElement(data);
		element.UpdateElementView();
		element.OnSelectElement += OnSelectedElement;
	}

	private void OnSelectedElement(UGUIAbstractGridElement<TData> uguiAbstractGridElement)
	{
		OnSelectElement(uguiAbstractGridElement);
	}

	protected virtual UGUIAbstractGridElement<TData> NewElementInstance(UGUIAbstractGridElement<TData> itemPrefab)
	{
		var instance = Instantiate(itemPrefab.gameObject) as GameObject;
		instance.transform.SetParent(transform);
		instance.transform.localScale = Vector3.one;
		instance.transform.localPosition = Vector3.zero;
		instance.transform.localEulerAngles = Vector3.zero;
		instance.transform.SetAsLastSibling();
		instance.SetActive(true);
		var gridElement = instance.GetComponent<UGUIAbstractGridElement<TData>>();
		UGUIAbstractGridElement<TData> element = gridElement;

		return element;
	}

	private void Clear()
	{
		foreach (var element in gridElements)
		{
			try
			{
				Destroy(element.gameObject);
			}
			catch (Exception)
			{
				Debug.LogWarning("Элементы Grid были уничтоженны ранее");
			}

		}
		gridElements.Clear();
	}

	public abstract UGUIAbstractGridElement<TData> GetPrefab(TData data);
}