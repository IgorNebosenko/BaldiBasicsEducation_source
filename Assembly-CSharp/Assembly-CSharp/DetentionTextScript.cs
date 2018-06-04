// DetentionTextScript
using UnityEngine;
using UnityEngine.UI;

public class DetentionTextScript : MonoBehaviour
{
	public DoorScript door;

	private Text text;

	private void Start()
	{
		text = base.GetComponent<Text>();
	}

	private void Update()
	{
		if (door.lockTime > 0f)
		{
			text.text = "You have detention! \n" + Mathf.CeilToInt(door.lockTime) + " seconds remain!";
		}
		else
		{
			text.text = string.Empty;
		}
	}
}
