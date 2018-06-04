// MouseSliderScript
using UnityEngine;
using UnityEngine.UI;

public class MouseSliderScript : MonoBehaviour
{
	public Slider slider;

	private void Start()
	{
		slider = base.GetComponent<Slider>();
		if (PlayerPrefs.GetFloat("MouseSensitivity") == 0f)
		{
			PlayerPrefs.SetFloat("MouseSensitvity", 1f);
		}
		slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
	}

	private void Update()
	{
		PlayerPrefs.SetFloat("MouseSensitivity", slider.value);
	}
}
