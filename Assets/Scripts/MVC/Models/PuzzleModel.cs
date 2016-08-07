using System;
using UnityEngine;
using System.Collections.Generic;
using Random = System.Random;

public class PuzzleModel : GameElement
{
	private ModeOperation _currModeOperation;
	private ModeGame _currModeGame;
	private int _max;
	private int _countPuzzleElements;

	public List<Sprite> AllBack; 
	private List<MathOperator> _puzzleElements = new List<MathOperator>();

	public event Action OnGeneratePuzzleElements = delegate { };
	public event Action<MathOperator> OnGeneratePuzzleElement = delegate { };
	public event Action OnCangeMode = delegate { };
	public event Action OnAppledTip = delegate { };

	public int CountPuzzleElements { get { return _countPuzzleElements; } }

	public void AppledTip()
	{
		//обработка если что-то сделать ещё
		OnAppledTip();
	}

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

	public ModeGame GetModeGame()
	{
		return _currModeGame;
	}

	public Sprite GetRandomBack()
	{
		Random rnd = new Random();
		int index = rnd.Next(0, AllBack.Count);
		return AllBack[index];
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

	public void GenerateInt()
	{
		switch (_currModeOperation)
		{
			case ModeOperation.Addition:
				GenerateAddition(1, _max);
				break;
			case ModeOperation.Deduction:
				GenerateDeduction(1, _max);
				break;
			case ModeOperation.Multiplication:
				GenerateMultiplication(1, _max);
				break;
			case ModeOperation.Division:
				GenerateDivision(1, _max);
				break;

			default:
				throw new ArgumentOutOfRangeException("mode", _currModeOperation, null);
		}
	}

	public void GenerateInts()
	{
		_puzzleElements.Clear();

		int elements = (int) Math.Pow(CountPuzzleElements, 2);
		switch (_currModeOperation)
		{
			case ModeOperation.Addition:
				GenerateAddition(elements, _max);
				break;
			case ModeOperation.Deduction:
				GenerateDeduction(elements, _max);
				break;
			case ModeOperation.Multiplication:
				GenerateMultiplication(elements, _max);
				break;
			case ModeOperation.Division:
				GenerateDivision(elements, _max);
				break;

			default:
				throw new ArgumentOutOfRangeException("mode", _currModeOperation, null);
		}
	}

	private void GenerateAddition(int count, int max)
	{

		Random rnd = new Random();
		MathOperator currOperator = null;

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			currOperator = new Addition(a,b);
			_puzzleElements.Add(currOperator);
		}

		if (count == 1)
		{
			OnGeneratePuzzleElement(currOperator);
			return;
		}

		OnGeneratePuzzleElements();
	}

	private void GenerateDeduction(int count, int max)
	{

		Random rnd = new Random();
		MathOperator currOperator = null;

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			currOperator = new Deduction(a, b);
			_puzzleElements.Add(currOperator);
		}

		if (count == 1)
		{
			OnGeneratePuzzleElement(currOperator);
			return;
		}

		OnGeneratePuzzleElements();
	}

	private void GenerateMultiplication(int count, int max)
	{

		Random rnd = new Random();
		MathOperator currOperator = null;

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			currOperator = new Multiplication(a, b);
			_puzzleElements.Add(currOperator);
		}

		if (count == 1)
		{
			OnGeneratePuzzleElement(currOperator);
			return;
		}

		OnGeneratePuzzleElements();
	}

	private void GenerateDivision(int count, int max)
	{

		Random rnd = new Random();
		MathOperator currOperator = null;

		for (int i = 0; i < count; i++)
		{
			var a = rnd.Next(max);
			var b = rnd.Next(max);
			if (b == 0 || a < b || a % b != 0)
			{
				i--;
				continue;
			}

			currOperator = new Division(a, b);

			_puzzleElements.Add(currOperator);
		}

		if (count == 1)
		{
			OnGeneratePuzzleElement(currOperator);
			return;
		}

		OnGeneratePuzzleElements();
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
