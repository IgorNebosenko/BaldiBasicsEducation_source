// BackButtonScript
using UnityEngine;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
	private Button button;

	public GameObject screen;

	private void Start()
	{
		button = base.GetComponent<Button>();
		button.onClick.AddListener(CloseScreen);
	}

	private void CloseScreen()
	{
		screen.SetActive(false);
	}
}
