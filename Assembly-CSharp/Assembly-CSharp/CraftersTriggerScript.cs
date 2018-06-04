// CraftersTriggerScript
using UnityEngine;

public class CraftersTriggerScript : MonoBehaviour
{
	public Transform goTarget;

	public Transform fleeTarget;

	public CraftersScript crafters;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			crafters.GiveLocation(goTarget.position, false);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			crafters.GiveLocation(fleeTarget.position, true);
		}
	}
}
