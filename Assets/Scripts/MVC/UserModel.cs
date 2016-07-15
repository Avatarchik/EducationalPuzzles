using System;
using UnityEngine;
using System.Collections;

public class UserModel : GameElement
{

	private Mode _currMode = Mode.Addition;///////////////////

	public Action OnCangeMode = delegate { };

	public void SetMode(Mode mode)
	{
		_currMode = mode;

		OnCangeMode();
	}

	public Mode GetMode()
	{
		return _currMode;
	}
}

public enum Mode
{
	Addition,
	Deduction,
	Division,
	Multiplication
}