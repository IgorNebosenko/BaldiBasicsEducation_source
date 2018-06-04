// AlarmClockScript
using UnityEngine;

public class AlarmClockScript : MonoBehaviour
{
	public float timeLeft;

	private float lifeSpan;

	private bool rang;

	public BaldiScript baldi;

	public AudioClip ring;

	public AudioSource audioDevice;

	private void Start()
	{
		timeLeft = 30f;
		lifeSpan = 35f;
	}

	private void Update()
	{
		if (timeLeft >= 0f)
		{
			timeLeft -= Time.deltaTime;
		}
		else if (!rang)
		{
			Alarm();
		}
		if (lifeSpan >= 0f)
		{
			lifeSpan -= Time.deltaTime;
		}
		else
		{
			Object.Destroy(base.gameObject, 0f);
		}
	}

	private void Alarm()
	{
		rang = true;
		baldi.Hear(base.transform.position, 8f);
		audioDevice.clip = ring;
		audioDevice.loop = false;
		audioDevice.Play();
	}
}
