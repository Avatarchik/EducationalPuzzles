public abstract class MathOperator
{

	protected int a;
	protected int b;
	protected int result;

	public int Result
	{
		get { return result; }
	}

	public abstract string GetTemplate();
}
