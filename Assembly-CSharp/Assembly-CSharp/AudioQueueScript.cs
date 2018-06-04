// AudioQueueScript
using UnityEngine;

public class AudioQueueScript : MonoBehaviour
{
	private AudioSource audioDevice;

	private int audioInQueue;

	private AudioClip[] audioQueue = new AudioClip[100];

	private void Start()
	{
		audioDevice = base.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!audioDevice.isPlaying && audioInQueue > 0)
		{
			PlayQueue();
		}
	}

	public void QueueAudio(AudioClip sound)
	{
		audioQueue[audioInQueue] = sound;
		audioInQueue++;
	}

	private void PlayQueue()
	{
		audioDevice.PlayOneShot(audioQueue[0]);
		UnqueueAudio();
	}

	private void UnqueueAudio()
	{
		for (int i = 1; i < audioInQueue; i++)
		{
			audioQueue[i - 1] = audioQueue[i];
		}
		audioInQueue--;
	}

	public void ClearAudioQueue()
	{
		audioInQueue = 0;
	}
}
