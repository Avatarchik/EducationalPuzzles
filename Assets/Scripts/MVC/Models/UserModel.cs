using System;
using UnityEngine;
using System.Collections;

public class UserModel : GameElement
{

	private Mode _currMode;
	private int _max;

	public Action OnCangeMode = delegate { };

	public void SetMode(Mode mode)
	{
		_currMode = mode;

		OnCangeMode();
	}

	public void SetMax(int max)
	{
		_max = max;
	}

	public Mode GetMode()
	{
		return _currMode;
	}

	public int GetMax()
	{
		return _max;
	}
}

public enum Mode
{
	Addition,
	Deduction,
	Division,
	Multiplication
}