// MathGameScript
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MathGameScript : MonoBehaviour
{
	public GameControllerScript gc;

	public BaldiScript baldiScript;

	public Vector3 playerPosition;

	public GameObject mathGame;

	public RawImage[] results = new RawImage[3];

	public Texture correct;

	public Texture incorrect;

	public InputField playerAnswer;

	public Text questionText;

	public Text questionText2;

	public Text questionText3;

	public Animator baldiFeed;

	public Transform baldiFeedTransform;

	public AudioClip bal_plus;

	public AudioClip bal_minus;

	public AudioClip bal_times;

	public AudioClip bal_divided;

	public AudioClip bal_equals;

	public AudioClip bal_howto;

	public AudioClip bal_intro;

	public AudioClip bal_screech;

	public AudioClip[] bal_numbers = new AudioClip[10];

	public AudioClip[] bal_praises = new AudioClip[5];

	public AudioClip[] bal_problems = new AudioClip[3];

	private float endDelay;

	private int problem;

	private int audioInQueue;

	private float num1;

	private float num2;

	private float num3;

	private int sign;

	private float solution;

	private string[] hintText = new string[2]
	{
		"I GET ANGRIER FOR EVERY PROBLEM YOU GET WRONG",
		"I HEAR EVERY DOOR YOU OPEN"
	};

	private string[] endlessHintText = new string[2]
	{
		"That's more like it...",
		"Keep up the good work or see me after class..."
	};

	private bool questionInProgress;

	private bool impossibleMode;

	private int problemsWrong;

	private AudioClip[] audioQueue = new AudioClip[20];

	public AudioSource baldiAudio;

	private void Start()
	{
		gc.ActivateLearningGame();
		if (gc.notebooks == 1)
		{
			QueueAudio(bal_intro);
			QueueAudio(bal_howto);
		}
		NewProblem();
		if (gc.spoopMode)
		{
			baldiFeedTransform.position = new Vector3(-1000f, -1000f, 0f);
		}
	}

	private void Update()
	{
		if (!baldiAudio.isPlaying)
		{
			if (audioInQueue > 0 & !gc.spoopMode)
			{
				PlayQueue();
			}
			baldiFeed.SetBool("talking", false);
		}
		else
		{
			baldiFeed.SetBool("talking", true);
		}
		if ((Input.GetKeyDown("return") || Input.GetKeyDown("enter")) & questionInProgress)
		{
			questionInProgress = false;
			CheckAnswer();
		}
		if (problem > 3)
		{
			endDelay -= 1f * Time.unscaledDeltaTime;
			if (endDelay <= 0f)
			{
				ExitGame();
			}
		}
	}

	private void NewProblem()
	{
		playerAnswer.text = string.Empty;
		problem++;
		if (problem <= 3)
		{
			QueueAudio(bal_problems[problem - 1]);
			if ((gc.mode == "story" & (problem <= 3 || gc.notebooks <= 7)) || (gc.mode == "endless" & (problem <= 2 || gc.notebooks != 2)))////problem 2, notebooks 1
            {
				num1 = (float)Mathf.RoundToInt(Random.Range(0f, 9f));
				this.num2 = (float)Mathf.RoundToInt(Random.Range(0f, 9f));
				sign = Mathf.RoundToInt(Random.Range(0f, 1f));
				QueueAudio(bal_numbers[Mathf.RoundToInt(num1)]);
				if (sign == 0)
				{
					solution = num1 + this.num2;
					questionText.text = "SOLVE MATH Q" + problem + ": \n \n" + num1 + "+" + this.num2 + "=";
					QueueAudio(bal_plus);
				}
				else if (sign == 1)
				{
					solution = num1 - this.num2;
					questionText.text = "SOLVE MATH Q" + problem + ": \n \n" + num1 + "-" + this.num2 + "=";
					QueueAudio(bal_minus);
				}
				QueueAudio(bal_numbers[Mathf.RoundToInt(this.num2)]);
				QueueAudio(bal_equals);
			}
			else
			{
				impossibleMode = true;
				num1 = Random.Range(1f, 9999f);
				this.num2 = Random.Range(1f, 9999f);
				num3 = Random.Range(1f, 9999f);
				sign = Mathf.RoundToInt((float)Random.Range(0, 1));
				QueueAudio(bal_screech);
				if (sign == 0)
				{
					questionText.text = "SOLVE MATH Q" + problem + ": \n" + num1 + "+(" + this.num2 + "X" + num3 + "=";
					QueueAudio(bal_plus);
					QueueAudio(bal_screech);
					QueueAudio(bal_times);
					QueueAudio(bal_screech);
				}
				else if (sign == 1)
				{
					questionText.text = "SOLVE MATH Q" + problem + ": \n (" + num1 + "/" + this.num2 + ")+" + num3 + "=";
					QueueAudio(bal_divided);
					QueueAudio(bal_screech);
					QueueAudio(bal_plus);
					QueueAudio(bal_screech);
				}
				num1 = Random.Range(1f, 9999f);
				this.num2 = Random.Range(1f, 9999f);
				num3 = Random.Range(1f, 9999f);
				sign = Mathf.RoundToInt((float)Random.Range(0, 1));
				if (sign == 0)
				{
					questionText2.text = "SOLVE MATH Q" + problem + ": \n" + num1 + "+(" + this.num2 + "X" + num3 + "=";
				}
				else if (sign == 1)
				{
					questionText2.text = "SOLVE MATH Q" + problem + ": \n (" + num1 + "/" + this.num2 + ")+" + num3 + "=";
				}
				num1 = Random.Range(1f, 9999f);
				this.num2 = Random.Range(1f, 9999f);
				num3 = Random.Range(1f, 9999f);
				sign = Mathf.RoundToInt((float)Random.Range(0, 1));
				if (sign == 0)
				{
					questionText3.text = "SOLVE MATH Q" + problem + ": \n" + num1 + "+(" + this.num2 + "X" + num3 + "=";
				}
				else if (sign == 1)
				{
					questionText3.text = "SOLVE MATH Q" + problem + ": \n (" + num1 + "/" + this.num2 + ")+" + num3 + "=";
				}
				QueueAudio(bal_equals);
			}
			playerAnswer.ActivateInputField();
			questionInProgress = true;
		}
		else
		{
			endDelay = 5f;
			if (!gc.spoopMode)
			{
				questionText.text = "WOW! YOU EXIST!";
			}
			else if (gc.mode == "endless" & problemsWrong <= 0)
			{
				int num = Mathf.RoundToInt(Random.Range(0f, 1f));
				questionText.text = endlessHintText[num];
			}
			else if (gc.mode == "story" & problemsWrong >= 3)
			{
				questionText.text = "I HEAR MATH THAT BAD";
				questionText2.text = string.Empty;
				questionText3.text = string.Empty;
				baldiScript.Hear(playerPosition, 10f);
				gc.failedNotebooks++;
			}
			else
			{
				int num2 = Mathf.RoundToInt(Random.Range(0f, 1f));
				questionText.text = hintText[num2];
				questionText2.text = string.Empty;
				questionText3.text = string.Empty;
			}
		}
	}

	public void CheckAnswer()
	{
		if (playerAnswer.text == solution.ToString() & !impossibleMode)
		{
			results[problem - 1].texture = correct;
			baldiAudio.Stop();
			ClearAudioQueue();
			int num = Mathf.RoundToInt(Random.Range(0f, 4f));
			QueueAudio(bal_praises[num]);
			NewProblem();
		}
		else
		{
            SceneManager.LoadScene("Secret");
            problemsWrong++;
			results[problem - 1].texture = incorrect;
			if (!gc.spoopMode)
			{
				baldiFeed.SetTrigger("angry");
				gc.ActivateSpoopMode();
			}
			if (gc.mode == "story")
			{
				if (problem == 3)
				{
					baldiScript.GetAngry(1f);
				}
				else
				{
					baldiScript.GetTempAngry(0.25f);
				}
			}
			else
			{
				baldiScript.GetAngry(1f);
			}
			ClearAudioQueue();
			baldiAudio.Stop();
			NewProblem();
		}
	}

	private void QueueAudio(AudioClip sound)
	{
		audioQueue[audioInQueue] = sound;
		audioInQueue++;
	}

	private void PlayQueue()
	{
		baldiAudio.PlayOneShot(audioQueue[0]);
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

	private void ClearAudioQueue()
	{
		audioInQueue = 0;
	}

	private void ExitGame()
	{
		if (problemsWrong <= 0 & gc.mode == "endless")
		{
			baldiScript.GetAngry(-1f);
		}
		gc.DeactivateLearningGame(base.gameObject);
	}
}
