// ScoreScript
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	public GameObject scoreText;

	public Text text;

	private void Start()
	{
		if (PlayerPrefs.GetString("CurrentMode") == "endless")
		{
			scoreText.SetActive(true);
			text.text = "Score:\n" + PlayerPrefs.GetInt("CurrentBooks") + " Notebooks";
		}
	}

	private void Update()
	{
	}
}
