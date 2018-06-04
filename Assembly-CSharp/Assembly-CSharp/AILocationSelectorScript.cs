// AILocationSelectorScript
using UnityEngine;

public class AILocationSelectorScript : MonoBehaviour
{
	public Transform[] newLocation = new Transform[29];

	public AmbienceScript ambience;

	private int id;

	public void GetNewTarget()
	{
		id = Mathf.RoundToInt(Random.Range(0f, 28f));
		base.transform.position = newLocation[id].position;
		ambience.PlayAudio();
	}

	public void GetNewTargetHallway()
	{
		id = Mathf.RoundToInt(Random.Range(0f, 15f));
		base.transform.position = newLocation[id].position;
		ambience.PlayAudio();
	}

	public void QuarterExclusive()
	{
		id = Mathf.RoundToInt(Random.Range(1f, 15f));
		base.transform.position = newLocation[id].position;
	}
}
