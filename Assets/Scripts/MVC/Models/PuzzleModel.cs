using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class PuzzleModel : GameElement
{

	private List<MathOperator> _puzzleElements = new List<MathOperator>();
	private int _countPuzzleElements;

	public Action OnGeneratePuzzleElements = delegate { };

	public int CountPuzzleElements { get { return _countPuzzleElements;} }

	public void SetPuzzleElements(int count)
	{
		_countPuzzleElements = count;
	}

	public List<MathOperator> GetPuzzleElements()
	{
		return _puzzleElements;
	}

	public MathOperator GetRandElement()
	{
		if (_puzzleElements.Count == 0) return null;

		Random rnd = new Random();
		int index = rnd.Next(_puzzleElements.Count - 1);
		return _puzzleElements[index];
	}

	public void DeleteElement(MathOperator mathOperator)
	{
		_puzzleElements.Remove(mathOperator);
	}

	public void GenerateInts(Mode mode, int max)
	{

		switch (mode)
		{
				case Mode.Addition:
				GenerateAddition(_countPuzzleElements * _countPuzzleElements, max);
				break;
				case Mode.Deduction:
				GenerateDeduction(_countPuzzleElements, max);
				break;
				case Mode.Multiplication:
				GenerateMultiplication(_countPuzzleElements, max);
				break;
				case Mode.Division:
				GenerateDivision(_countPuzzleElements, max);
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

	private void GenerateDeduction(int count, int max)
	{
		_puzzleElements.Clear();

		Random rnd = new Random();

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			var test = new Deduction(a, b);
			_puzzleElements.Add(test);
		}

		OnGeneratePuzzleElements();
	}

	private void GenerateMultiplication(int count, int max)
	{
		_puzzleElements.Clear();

		Random rnd = new Random();

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			var test = new Multiplication(a, b);
			_puzzleElements.Add(test);
		}

		OnGeneratePuzzleElements();
	}

	private void GenerateDivision(int count, int max)
	{
		_puzzleElements.Clear();

		Random rnd = new Random();

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			if (b == 0 || a < b || a % b != 0)
			{
				i--;
				continue;
			}

			var test = new Division(a, b);

			_puzzleElements.Add(test);
		}

		OnGeneratePuzzleElements();
	}
}
