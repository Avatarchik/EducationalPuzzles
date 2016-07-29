using System;
using UnityEngine;
using System.Collections;

public class UserModel : GameElement
{
	private ModeOperation _currModeOperation;
	private ModeGame _currModeGame;
	private int _max;
	private int _countPuzzleElements;

	public Action OnCangeMode = delegate { };
	public Action OnAddValueRecord = delegate { };

	public int CountPuzzleElements { get { return _countPuzzleElements; } }

	public void SetPuzzleElements(int count)
	{
		_countPuzzleElements = count;
	}

	public void SetModeGame(ModeGame mode)
	{
		_currModeGame = mode;
	}

	public void SetModeOperation(ModeOperation mode)
	{
		_currModeOperation = mode;

		OnCangeMode();
	}

	public void SetMax(int max)
	{
		_max = max;
	}

	public ModeOperation GetModeOperation()
	{
		return _currModeOperation;
	}

	public ModeGame GetModeGame()
	{
		return _currModeGame;
	}

	public int GetMax()
	{
		return _max;
	}
}

public enum ModeOperation
{
	Addition,
	Deduction,
	Division,
	Multiplication
}

public enum ModeGame
{
	Normal,
	Record
}