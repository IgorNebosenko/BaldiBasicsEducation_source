// TapePlayerScript
using UnityEngine;

public class TapePlayerScript : MonoBehaviour
{
	public Sprite closedSprite;

	public SpriteRenderer sprite;

	public BaldiScript baldi;

	private AudioSource audioDevice;

	private void Start()
	{
		audioDevice = base.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (audioDevice.isPlaying & Time.timeScale == 0f)
		{
			audioDevice.Pause();
		}
		else if (Time.timeScale > 0f & baldi.antiHearingTime > 0f)
		{
			audioDevice.UnPause();
		}
	}

	public void Play()
	{
		sprite.sprite = closedSprite;
		audioDevice.Play();
		baldi.ActivateAntiHearing(30f);
	}
}
