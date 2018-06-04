// PickupScript
using UnityEngine;

public class PickupScript : MonoBehaviour
{
	public GameControllerScript gc;

	public Transform player;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.transform.name == "Pickup_EnergyFlavoredZestyBar" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(1);
				}
				else if (raycastHit.transform.name == "Pickup_YellowDoorLock" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(2);
				}
				else if (raycastHit.transform.name == "Pickup_Key" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(3);
				}
				else if (raycastHit.transform.name == "Pickup_BSODA" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(4);
				}
				else if (raycastHit.transform.name == "Pickup_Quarter" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(5);
				}
				else if (raycastHit.transform.name == "Pickup_Tape" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(6);
				}
				else if (raycastHit.transform.name == "Pickup_AlarmClock" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(7);
				}
				else if (raycastHit.transform.name == "Pickup_WD-3D" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(8);
				}
				else if (raycastHit.transform.name == "Pickup_SafetyScissors" & Vector3.Distance(player.position, base.transform.position) < 10f)
				{
					raycastHit.transform.gameObject.SetActive(false);
					gc.CollectItem(9);
				}
			}
		}
	}
}
