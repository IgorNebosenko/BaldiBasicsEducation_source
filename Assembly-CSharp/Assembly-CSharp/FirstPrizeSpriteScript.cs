// FirstPrizeSpriteScript
using UnityEngine;

public class FirstPrizeSpriteScript : MonoBehaviour
{
	public float debug;

	public int angle;

	public float angleF;

	private SpriteRenderer sprite;

	public Transform cam;

	public Transform body;

	public Sprite[] sprites = new Sprite[16];

	private void Start()
	{
		sprite = base.GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		Vector3 position = cam.position;
		float z = position.z;
		Vector3 position2 = body.position;
		float y = z - position2.z;
		Vector3 position3 = cam.position;
		float x = position3.x;
		Vector3 position4 = body.position;
		angleF = Mathf.Atan2(y, x - position4.x) * 57.29578f;
		if (angleF < 0f)
		{
			angleF += 360f;
		}
		Vector3 eulerAngles = body.eulerAngles;
		debug = eulerAngles.y;
		float num = angleF;
		Vector3 eulerAngles2 = body.eulerAngles;
		angleF = num + eulerAngles2.y;
		angle = Mathf.RoundToInt(angleF / 22.5f);
		while (true)
		{
			if (angle >= 0 && angle < 16)
			{
				break;
			}
			angle += (int)(-16f * Mathf.Sign((float)angle));
		}
		sprite.sprite = sprites[angle];
	}
}
