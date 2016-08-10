

using UnityEngine;

public class Multiplication : MathOperator {

	public Multiplication(int a, int b)
	{
		this.a = a;
		this.b = b;
		result = a*b;
	}

	public Multiplication()
	{
		Debug.Log("Привет хуй");
		result = 100000;
	}

	public override string GetTemplate()
	{
		return a + " * " + b + " = ";
	}
}
