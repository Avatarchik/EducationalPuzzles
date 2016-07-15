using UnityEngine;
using System.Collections;

public class Addition : MathOperator{

	public Addition(int a, int b)
	{
		this.a = a;
		this.b = b;
		result = a + b;
	}

	public override string GetTemplate()
	{
		return a + " + " + b + " = ";
	}
}
