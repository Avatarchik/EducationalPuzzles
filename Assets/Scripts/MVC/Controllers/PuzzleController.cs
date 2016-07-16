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
}
