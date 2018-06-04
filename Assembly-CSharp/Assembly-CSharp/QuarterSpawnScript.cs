// QuarterSpawnScript
using UnityEngine;

public class QuarterSpawnScript : MonoBehaviour
{
	public AILocationSelectorScript wanderer;

	public Transform location;

	private void Start()
	{
		wanderer.QuarterExclusive();
		base.transform.position = location.position + Vector3.up * 4f;
	}

	private void Update()
	{
	}
}
