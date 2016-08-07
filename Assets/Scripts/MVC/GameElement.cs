using UnityEngine;

public class GameElement : MonoBehaviour {

	public GameApplication app
	{
		get
		{
			return FindObjectOfType<GameApplication>();
		}
	}
}
