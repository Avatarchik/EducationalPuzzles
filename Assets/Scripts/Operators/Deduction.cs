using UnityEngine;
using System.Collections;

public class Deduction : MathOperator {

	public Deduction(int a, int b)
	{
		this.a = a;
		this.b = b;
	}

	public override string GetTemplate()
	{
		return a + " - " + b + " = ";
	}
}
