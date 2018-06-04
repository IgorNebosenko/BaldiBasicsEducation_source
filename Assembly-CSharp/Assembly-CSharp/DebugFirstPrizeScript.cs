// DebugFirstPrizeScript
using UnityEngine;

public class DebugFirstPrizeScript : MonoBehaviour
{
	public Transform player;

	public Transform first;

	private void Start()
	{
	}

	private void Update()
	{
		Transform transform = base.transform;
		Vector3 position = first.position;
		Vector3 forward = first.forward;
		float x = (float)Mathf.RoundToInt(forward.x);
		Vector3 forward2 = first.forward;
		transform.position = position + new Vector3(x, 0f, (float)Mathf.RoundToInt(forward2.z)) * 3f;
	}
}
