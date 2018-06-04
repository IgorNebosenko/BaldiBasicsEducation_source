// DoorScript
using UnityEngine;

public class DoorScript : MonoBehaviour
{
	public float openingDistance;

	public Transform player;

	public BaldiScript baldi;

	public MeshCollider barrier;

	public MeshCollider trigger;

	public MeshCollider invisibleBarrier;

	public MeshRenderer inside;

	public MeshRenderer outside;

	public AudioClip doorOpen;

	public AudioClip doorClose;

	public Material closed;

	public Material open;

	private bool bDoorOpen;

	private bool bDoorLocked;

	public int silentOpens;

	private float openTime;

	public float lockTime;

	private AudioSource myAudio;

	private void Start()
	{
		myAudio = base.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (lockTime > 0f)
		{
			lockTime -= 1f * Time.deltaTime;
		}
		else if (bDoorLocked)
		{
			UnlockDoor();
		}
		if (openTime > 0f)
		{
			openTime -= 1f * Time.deltaTime;
		}
		if (openTime <= 0f & bDoorOpen)
		{
			barrier.enabled = true;
			invisibleBarrier.enabled = true;
			bDoorOpen = false;
			inside.sharedMaterial = closed;
			outside.sharedMaterial = closed;
			if (silentOpens <= 0)
			{
				myAudio.PlayOneShot(doorClose, 1f);
			}
		}
		if (Input.GetMouseButtonDown(0) & Time.timeScale != 0f)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && ((Object)raycastHit.collider == (Object)trigger & Vector3.Distance(player.position, base.transform.position) < openingDistance & !bDoorLocked))
			{
				if (baldi.isActiveAndEnabled & silentOpens <= 0)
				{
					baldi.Hear(base.transform.position, 1f);
				}
				OpenDoor();
				if (silentOpens > 0)
				{
					silentOpens--;
				}
			}
		}
	}

	public void OpenDoor()
	{
		if (silentOpens <= 0 && !bDoorOpen)
		{
			myAudio.PlayOneShot(doorOpen, 1f);
		}
		barrier.enabled = false;
		invisibleBarrier.enabled = false;
		bDoorOpen = true;
		inside.sharedMaterial = open;
		outside.sharedMaterial = open;
		openTime = 3f;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!bDoorLocked & other.CompareTag("NPC"))
		{
			OpenDoor();
		}
	}

	public void LockDoor(float time)
	{
		bDoorLocked = true;
		lockTime = time;
	}

	public void UnlockDoor()
	{
		bDoorLocked = false;
	}

	public void SilenceDoor()
	{
		silentOpens = 4;
	}
}
