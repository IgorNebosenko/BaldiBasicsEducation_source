// SwingingDoorScript
using UnityEngine;

public class SwingingDoorScript : MonoBehaviour
{
	public GameControllerScript gc;

	public BaldiScript baldi;

	public MeshCollider barrier;

	public GameObject obstacle;

	public MeshCollider trigger;

	public MeshRenderer inside;

	public MeshRenderer outside;

	public Material closed;

	public Material open;

	public Material locked;

	public AudioClip doorOpen;

	public AudioClip baldiDoor;

	private float openTime;

	private float lockTime;

	private bool bDoorOpen;

	private bool bDoorLocked;

	private bool requirementMet;

	private AudioSource myAudio;

	private void Start()
	{
		myAudio = base.GetComponent<AudioSource>();
		bDoorLocked = true;
	}

	private void Update()
	{
		if (!requirementMet & gc.notebooks >= 2)
		{
			requirementMet = true;
			UnlockDoor();
		}
		if (openTime > 0f)
		{
			openTime -= 1f * Time.deltaTime;
		}
		if (lockTime > 0f)
		{
			lockTime -= Time.deltaTime;
		}
		else if (bDoorLocked & requirementMet)
		{
			UnlockDoor();
		}
		if (openTime <= 0f & bDoorOpen & !bDoorLocked)
		{
			bDoorOpen = false;
			inside.sharedMaterial = closed;
			outside.sharedMaterial = closed;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!bDoorLocked)
		{
			bDoorOpen = true;
			inside.sharedMaterial = open;
			outside.sharedMaterial = open;
			openTime = 2f;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (gc.notebooks < 2 & other.tag == "Player")
		{
			myAudio.PlayOneShot(baldiDoor, 1f);
		}
		else if (!bDoorLocked)
		{
			myAudio.PlayOneShot(doorOpen, 1f);
			if (other.tag == "Player" && baldi.isActiveAndEnabled)
			{
				baldi.Hear(base.transform.position, 1f);
			}
		}
	}

	public void LockDoor(float time)
	{
		barrier.enabled = true;
		obstacle.SetActive(true);
		bDoorLocked = true;
		lockTime = time;
		inside.sharedMaterial = locked;
		outside.sharedMaterial = locked;
	}

	private void UnlockDoor()
	{
		barrier.enabled = false;
		obstacle.SetActive(false);
		bDoorLocked = false;
		inside.sharedMaterial = closed;
		outside.sharedMaterial = closed;
	}
}
