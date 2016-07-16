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
		Mode currMode = app.Model.UserModel.GetMode();
		int max = app.Model.UserModel.GetMax();
		app.Model.PuzzleModel.GenerateInts(currMode, max);
	}
}
