// EndlessTextScript
using UnityEngine;
using UnityEngine.UI;

public class EndlessTextScript : MonoBehaviour
{
	public Text text;

	private void Start()
	{
		text.text = "Endless Mode:\nCollect as many notebooks as you can!\nHigh Score:\n " + PlayerPrefs.GetInt("HighBooks") + " Notebooks";
	}

	private void Update()
	{
	}
}
