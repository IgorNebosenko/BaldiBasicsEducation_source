// PlaytimeScript
using UnityEngine;
using UnityEngine.AI;

public class PlaytimeScript : MonoBehaviour
{
	public bool db;

	public bool playerSeen;

	public bool disappointed;

	public int audVal;

	public Animator animator;

	public Transform player;

	public PlayerScript ps;

	public Transform wanderTarget;

	public AILocationSelectorScript wanderer;

	public float coolDown;

	public float playCool;

	public bool playerSpotted;

	public bool jumpRopeStarted;

	private NavMeshAgent agent;

	public AudioClip[] aud_Numbers = new AudioClip[10];

	public AudioClip[] aud_Random = new AudioClip[2];

	public AudioClip aud_Instrcutions;

	public AudioClip aud_Oops;

	public AudioClip aud_LetsPlay;

	public AudioClip aud_Congrats;

	public AudioClip aud_ReadyGo;

	public AudioClip aud_Sad;

	public AudioSource audioDevice;

	private void Start()
	{
		agent = base.GetComponent<NavMeshAgent>();
		audioDevice = base.GetComponent<AudioSource>();
		Wander();
	}

	private void Update()
	{
		if (coolDown > 0f)
		{
			coolDown -= 1f * Time.deltaTime;
		}
		if (playCool >= 0f)
		{
			playCool -= Time.deltaTime;
		}
		else if (animator.GetBool("disappointed"))
		{
			playCool = 0f;
			animator.SetBool("disappointed", false);
		}
	}

	private void FixedUpdate()
	{
		if (!ps.jumpRope)
		{
			Vector3 direction = player.position - base.transform.position;
			RaycastHit raycastHit;
			if (Physics.Raycast(base.transform.position, direction, out raycastHit, float.PositiveInfinity, 3, QueryTriggerInteraction.Ignore) & raycastHit.transform.tag == "Player" & (base.transform.position - player.position).magnitude <= 80f & playCool <= 0f)
			{
				playerSeen = true;
				TargetPlayer();
			}
			else if (playerSeen & coolDown <= 0f)
			{
				playerSeen = false;
				Wander();
			}
			else if (agent.velocity.magnitude <= 1f & coolDown <= 0f)
			{
				Wander();
			}
			jumpRopeStarted = false;
		}
		else
		{
			if (!jumpRopeStarted)
			{
				agent.Warp(base.transform.position - base.transform.forward * 10f);
			}
			jumpRopeStarted = true;
			agent.speed = 0f;
			playCool = 15f;
		}
	}

	private void Wander()
	{
		wanderer.GetNewTargetHallway();
		agent.SetDestination(wanderTarget.position);
		agent.speed = 15f;
		playerSpotted = false;
		audVal = Mathf.RoundToInt(Random.Range(0f, 1f));
		if (!audioDevice.isPlaying)
		{
			audioDevice.PlayOneShot(aud_Random[audVal]);
		}
		coolDown = 1f;
	}

	private void TargetPlayer()
	{
		animator.SetBool("disappointed", false);
		agent.SetDestination(player.position);
		agent.speed = 20f;
		coolDown = 0.2f;
		if (!playerSpotted)
		{
			playerSpotted = true;
			audioDevice.PlayOneShot(aud_LetsPlay);
		}
	}

	public void Disappoint()
	{
		animator.SetBool("disappointed", true);
		audioDevice.Stop();
		audioDevice.PlayOneShot(aud_Sad);
	}
}
