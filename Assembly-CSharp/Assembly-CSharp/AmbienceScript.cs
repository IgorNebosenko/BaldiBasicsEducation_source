// AmbienceScript
using UnityEngine;

public class AmbienceScript : MonoBehaviour
{
	public Transform aiLocation;

	public AudioClip[] sounds;

	public AudioSource audioDevice;

	private void Start()
	{
	}

	public void PlayAudio()
	{
		int num = Mathf.RoundToInt(Random.Range(0f, 49f));
		if (!audioDevice.isPlaying & num == 0)
		{
			base.transform.position = aiLocation.position;
			int num2 = Mathf.RoundToInt(Random.Range(0f, (float)(sounds.Length - 1)));
			audioDevice.PlayOneShot(sounds[num2]);
		}
	}
}
