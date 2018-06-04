// Script
using UnityEngine;

public class Script : MonoBehaviour
{
	public AudioSource audioDevice;

	private bool played;

	private void Start()
	{
	}

	private void Update()
	{
		if (!audioDevice.isPlaying & played)
		{
			Application.Quit();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Player" & !played)
		{
			audioDevice.Play();
			played = true;
		}
	}
}
