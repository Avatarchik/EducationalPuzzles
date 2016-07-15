using UnityEngine;
using System.Collections;

public class Multiplication : MathOperator {

	public Multiplication(int a, int b)
	{
		this.a = a;
		this.b = b;
	}

	public override string GetTemplate()
	{
		return a + " * " + b + " = ";
	}
}
