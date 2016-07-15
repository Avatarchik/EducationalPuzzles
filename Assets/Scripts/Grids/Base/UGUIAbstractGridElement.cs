using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public abstract class UGUIAbstractGridElement<TData> : MonoBehaviour where TData : class
{
	public Action<UGUIAbstractGridElement<TData>> OnSelectElement = delegate { };

	void Awake()
	{
		//у GridElement обязательно должен быть компонент Button
		try
		{
			gameObject.GetComponent<Button>().onClick.AddListener(ClickElement);
		}
		catch
		{
			Debug.LogError("Не назначена кнопка на GridElement " + typeof(TData));
		}
	}

	private void ClickElement()
	{
		//при срабатываниии onClick на Button запускается событие с передачей UGUIAbstractElement<TData>
		OnSelectElement(this);
	}

	private TData _data;

	public TData GetData()
	{
		return _data;
	}

	public void InitializeElement(TData data)
	{
		_data = data;
		Initialize(_data);
	}

	public abstract void Initialize(TData data);

	public abstract void UpdateElementView();
}
