// GameOverScript
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
	private Image image;

	private float delay;

	public Sprite[] images = new Sprite[5];

	public Sprite rare;

	private float chance;

	private AudioSource audioDevice;

	private void Start()
	{
		image = base.GetComponent<Image>();
		audioDevice = base.GetComponent<AudioSource>();
		delay = 5f;
		chance = Random.Range(1f, 99f);
		if (chance < 98f)
		{
			int num = Mathf.RoundToInt(Random.Range(0f, 4f));
			image.sprite = images[num];
		}
		else
		{
			image.sprite = rare;
		}
	}

	private void Update()
	{
		delay -= 1f * Time.deltaTime;
		if (delay <= 0f)
		{
			if (chance < 98f)
			{
				SceneManager.LoadScene("MainMenu");
			}
			else
			{
				image.transform.localScale = new Vector3(5f, 5f, 1f);
				image.color = Color.red;
				if (!audioDevice.isPlaying)
				{
					audioDevice.Play();
				}
				if (delay <= -5f)
				{
					Application.Quit();
				}
			}
		}
	}
}
