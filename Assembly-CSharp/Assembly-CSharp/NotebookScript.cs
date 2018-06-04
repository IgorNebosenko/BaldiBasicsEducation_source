// NotebookScript
using UnityEngine;

public class NotebookScript : MonoBehaviour
{
	public float openingDistance;

	public GameControllerScript gc;

	public BaldiScript bsc;

	public float respawnTime;

	public bool up;

	public Transform player;

	public GameObject learningGame;

	public AudioSource audioDevice;

	private void Start()
	{
		up = true;
	}

	private void Update()
	{
		if (gc.mode == "endless")
		{
			if (respawnTime > 0f)
			{
				if ((base.transform.position - player.position).magnitude > 60f)
				{
					respawnTime -= Time.deltaTime;
				}
			}
			else if (!up)
			{
				Transform transform = base.transform;
				Vector3 position = base.transform.position;
				float x = position.x;
				Vector3 position2 = base.transform.position;
				transform.position = new Vector3(x, 4f, position2.z);
				up = true;
				audioDevice.Play();
			}
		}
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(ray, out raycastHit) && (raycastHit.transform.tag == "Notebook" & Vector3.Distance(player.position, base.transform.position) < openingDistance))
			{
				Transform transform2 = base.transform;
				Vector3 position3 = base.transform.position;
				float x2 = position3.x;
				Vector3 position4 = base.transform.position;
				transform2.position = new Vector3(x2, -20f, position4.z);
				up = false;
				respawnTime = 120f;
				gc.CollectNotebook();
				GameObject gameObject = Object.Instantiate(learningGame);
				gameObject.GetComponent<MathGameScript>().gc = gc;
				gameObject.GetComponent<MathGameScript>().baldiScript = bsc;
				gameObject.GetComponent<MathGameScript>().playerPosition = player.position;
			}
		}
	}
}
