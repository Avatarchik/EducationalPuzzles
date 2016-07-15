using UnityEngine;
using System.Collections;

public class GameElement : MonoBehaviour {

	public GameApplication app
	{
		get
		{
			return FindObjectOfType<GameApplication>();
		}
	}
}
