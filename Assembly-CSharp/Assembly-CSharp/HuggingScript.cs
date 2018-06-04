// HuggingScript
using UnityEngine;
using UnityEngine.AI;

public class HuggingScript : MonoBehaviour
{
	private Rigidbody rb;

	private Vector3 otherVelocity;

	public bool inBsoda;

	private float failSave;

	private void Start()
	{
		rb = base.GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (failSave > 0f)
		{
			failSave -= Time.deltaTime;
		}
		else
		{
			inBsoda = false;
		}
	}

	private void FixedUpdate()
	{
		if (inBsoda)
		{
			rb.velocity = otherVelocity;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.name == "1st Prize")
		{
			inBsoda = true;
			otherVelocity = rb.velocity * 0.1f + ((Component)other).GetComponent<NavMeshAgent>().velocity;
			failSave = 1f;
		}
	}

	private void OnTriggerExit()
	{
		inBsoda = false;
	}
}
