using UnityEngine;
using System.Collections;

public class Division : MathOperator {

	public Division(int a, int b)
	{
		this.a = a;
		this.b = b;
	}

	public override string GetTemplate()
	{
		return a + " : " + b + " = ";
	}
}
