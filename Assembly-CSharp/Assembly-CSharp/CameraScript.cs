// CameraScript
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public GameObject player;

	public PlayerScript ps;

	public Transform baldi;

	public float initVelocity;

	public float velocity;

	public float gravity;

	private int lookBehind;

	private Vector3 offset;

	public float jumpHeight;

	private Vector3 jumpHeightV3;

	private void Start()
	{
		offset = base.transform.position - player.transform.position;
	}

	private void Update()
	{
		if (ps.jumpRope)
		{
			velocity -= gravity * Time.deltaTime;
			jumpHeight += velocity * Time.deltaTime;
			if (jumpHeight <= 0f)
			{
				jumpHeight = 0f;
				if (Input.GetKeyDown(KeyCode.Space))
				{
					velocity = initVelocity;
				}
			}
			jumpHeightV3 = new Vector3(0f, jumpHeight, 0f);
		}
		else if (Input.GetButton("Look Behind"))
		{
			lookBehind = 180;
		}
		else
		{
			lookBehind = 0;
		}
	}

	private void LateUpdate()
	{
		base.transform.position = player.transform.position + offset;
		if (!ps.gameOver & !ps.jumpRope)
		{
			base.transform.position = player.transform.position + offset;
			base.transform.rotation = player.transform.rotation * Quaternion.Euler(0f, (float)lookBehind, 0f);
		}
		else if (ps.gameOver)
		{
			base.transform.position = baldi.transform.position + baldi.transform.forward * 2f + new Vector3(0f, 5f, 0f);
			Transform transform = base.transform;
			Vector3 position = baldi.position;
			float x = position.x;
			Vector3 position2 = baldi.position;
			float y = position2.y + 5f;
			Vector3 position3 = baldi.position;
			transform.LookAt(new Vector3(x, y, position3.z));
		}
		else if (ps.jumpRope)
		{
			base.transform.position = player.transform.position + offset + jumpHeightV3;
			base.transform.rotation = player.transform.rotation;
		}
	}
}
