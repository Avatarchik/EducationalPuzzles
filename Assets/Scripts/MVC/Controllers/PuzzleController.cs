using UnityEngine;
using System.Collections;

public class PuzzleController : GameElement {

	public void DeleteElement(MathOperator mathOperator)
	{
		if (app.Model.PuzzleModel.GetPuzzleElements().Contains(mathOperator))
		{
			app.Model.PuzzleModel.DeleteElement(mathOperator);
		}
	}

	public void GenerateInts()
	{
		ModeOperation currMode = app.Model.UserModel.GetModeOperation();
		int max = app.Model.UserModel.GetMax();
		app.Model.PuzzleModel.GenerateInts(currMode, max,app.Model.UserModel.CountPuzzleElements);
	}

	public void GenerateInt()
	{
		ModeOperation currMode = app.Model.UserModel.GetModeOperation();
		int max = app.Model.UserModel.GetMax();
		app.Model.PuzzleModel.GenerateInt(currMode, max);
	}
}
