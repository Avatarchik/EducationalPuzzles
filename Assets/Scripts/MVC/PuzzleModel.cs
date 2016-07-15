using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class PuzzleModel : GameElement
{

	private List<MathOperator> _puzzleElements = new List<MathOperator>();
	private int _countPuzzleElements = 9;

	public Action OnGeneratePuzzleElements = delegate { };

	public List<MathOperator> GetPuzzleElements()
	{
		return _puzzleElements;
	} 

	public void GenerateInts(Mode mode, int max)
	{

		switch (mode)
		{
				case Mode.Addition:
				GenerateAddition(_countPuzzleElements, max);
				break;
				case Mode.Deduction:
				break;
				case Mode.Multiplication:
				break;
				case Mode.Division:
				break;

			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
		}
	}

	private void GenerateAddition(int count, int max)
	{
		_puzzleElements.Clear();
		Random rnd = new Random();

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			var test = new Addition(a,b);
			_puzzleElements.Add(test);
		}

		OnGeneratePuzzleElements();
	}
}
