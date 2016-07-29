using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = System.Random;

public class PuzzleModel : GameElement
{

	private List<MathOperator> _puzzleElements = new List<MathOperator>();
	

	public Action OnGeneratePuzzleElements = delegate { };
	public Action<MathOperator> OnGeneratePuzzleElement = delegate {};

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

	public void GenerateInt(ModeOperation mode, int max)
	{
		switch (mode)
		{
			case ModeOperation.Addition:
				GenerateAddition(1, max);
				break;
			case ModeOperation.Deduction:
				GenerateDeduction(1, max);
				break;
			case ModeOperation.Multiplication:
				GenerateMultiplication(1, max);
				break;
			case ModeOperation.Division:
				GenerateDivision(1, max);
				break;

			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
		}
	}

	public void GenerateInts(ModeOperation mode, int max, int countElements)
	{
		_puzzleElements.Clear();

		int elements = (int) Math.Pow(countElements, 2);
		switch (mode)
		{
			case ModeOperation.Addition:
				GenerateAddition(elements, max);
				break;
			case ModeOperation.Deduction:
				GenerateDeduction(elements, max);
				break;
			case ModeOperation.Multiplication:
				GenerateMultiplication(elements, max);
				break;
			case ModeOperation.Division:
				GenerateDivision(elements, max);
				break;

			default:
				throw new ArgumentOutOfRangeException("mode", mode, null);
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
