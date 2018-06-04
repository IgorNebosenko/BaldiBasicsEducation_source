// JumpRopeScript
using UnityEngine;
using UnityEngine.UI;

public class JumpRopeScript : MonoBehaviour
{
	public Text jumpCount;

	public Animator rope;

	public CameraScript cs;

	public PlayerScript ps;

	public PlaytimeScript playtime;

	public int jumps;

	public float jumpDelay;

	public float ropePosition;

	public bool ropeHit;

	public bool jumpStarted;

	private void OnEnable()
	{
		jumpDelay = 1f;
		ropeHit = true;
		jumpStarted = false;
		jumps = 0;
		jumpCount.text = 0 + "/5";
		playtime.audioDevice.PlayOneShot(playtime.aud_ReadyGo);
	}

	private void Update()
	{
		if (jumpDelay > 0f)
		{
			jumpDelay -= Time.deltaTime;
		}
		else if (!jumpStarted)
		{
			jumpStarted = true;
			ropePosition = 1f;
			rope.SetTrigger("ActivateJumpRope");
			ropeHit = false;
		}
		if (ropePosition > 0f)
		{
			ropePosition -= Time.deltaTime;
		}
		else if (!ropeHit)
		{
			RopeHit();
		}
	}

	private void RopeHit()
	{
		ropeHit = true;
		if (cs.jumpHeight <= 0.2f)
		{
			Fail();
		}
		else
		{
			Success();
		}
		jumpStarted = false;
	}

	private void Success()
	{
		playtime.audioDevice.Stop();
		playtime.audioDevice.PlayOneShot(playtime.aud_Numbers[jumps]);
		jumps++;
		jumpCount.text = jumps + "/5";
		jumpDelay = 0.5f;
		if (jumps >= 5)
		{
			playtime.audioDevice.Stop();
			playtime.audioDevice.PlayOneShot(playtime.aud_Congrats);
			ps.DeactivateJumpRope();
		}
	}

	private void Fail()
	{
		jumps = 0;
		jumpCount.text = jumps + "/5";
		jumpDelay = 2f;
		playtime.audioDevice.PlayOneShot(playtime.aud_Oops);
	}
}
