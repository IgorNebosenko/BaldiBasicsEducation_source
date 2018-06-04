// PickupAnimationScript
using UnityEngine;

public class PickupAnimationScript : MonoBehaviour
{
	private Transform itemPosition;

	private void Start()
	{
		itemPosition = base.GetComponent<Transform>();
	}

	private void Update()
	{
		itemPosition.localPosition = new Vector3(0f, Mathf.Sin((float)Time.frameCount * 0.0174532924f) / 2f + 1f, 0f);
	}
}
