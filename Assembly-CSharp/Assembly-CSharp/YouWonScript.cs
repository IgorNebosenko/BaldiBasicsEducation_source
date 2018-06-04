// YouWonScript
using UnityEngine;

public class YouWonScript : MonoBehaviour
{
	private float delay;

	private void Start()
	{
		delay = 10f;
	}

	private void Update()
	{
		delay -= Time.deltaTime;
		if (delay <= 0f)
		{
			Application.Quit();
		}
	}
}
