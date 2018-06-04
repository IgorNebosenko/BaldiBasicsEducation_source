// CursorControllerScript
using UnityEngine;

public class CursorControllerScript : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	public void UnlockCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
}
