// PowerUPInventoryR
using System.Collections;
using UnityEngine;

public class PowerUPInventoryR : MonoBehaviour
{
	public bool speedActive;

	public bool stopBall;

	public bool hasSpeed;

	public bool hasDeflect;

	public bool deflectActive;

	public GameObject player1Wall;

	public GameObject player2Wall;

	public int wallSeconds;

	public bool player1;

	public bool player2;

	public KeyCode PowerUpKey;

	public PowerUPDisplayUI PowerUPDisplayer1;

	public PowerUPDisplayUI PowerUPDisplayer2;

	private Ball ball;

	private int newSpeed = 20;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (speedActive)
		{
			if (other.gameObject.tag == "Ball")
			{
				ball = other.gameObject.GetComponent<Ball>();
			}
			ball.gameObject.transform.parent = base.transform;
			ball.GetComponent<Rigidbody2D>().isKinematic = true;
			stopBall = true;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(PowerUpKey) && hasSpeed)
		{
			speedActive = true;
		}
		if (Input.GetKeyDown(PowerUpKey) && hasDeflect)
		{
			StartCoroutine(RiseWall());
		}
		if (Input.GetKeyDown(PowerUpKey) && stopBall)
		{
			if (player1)
			{
				ball.transform.parent = null;
				ball.GetComponent<Rigidbody2D>().isKinematic = false;
				ball.gameObject.GetComponent<Rigidbody2D>().velocity = base.transform.right * newSpeed;
				ball.maxSpeed = newSpeed;
				stopBall = false;
				speedActive = false;
				hasSpeed = false;
				PowerUPDisplayer1.DeactivatedPowerUP();
			}
			if (player2)
			{
				ball.gameObject.transform.parent = null;
				ball.GetComponent<Rigidbody2D>().isKinematic = false;
				ball.gameObject.GetComponent<Rigidbody2D>().velocity = base.transform.right * -newSpeed;
				ball.maxSpeed = newSpeed;
				stopBall = false;
				speedActive = false;
				hasSpeed = false;
				PowerUPDisplayer2.DeactivatedPowerUP();
			}
		}
	}

	private void FixedUpdate()
	{
		if (stopBall)
		{
			ball.speed = 0;
			ball.maxSpeed = 0;
		}
	}

	private IEnumerator RiseWall()
	{
		if (player1)
		{
			player1Wall.SetActive(true);
			hasDeflect = false;
			PowerUPDisplayer1.DeactivatedPowerUP();
		}
		if (player2)
		{
			player2Wall.SetActive(true);
			hasDeflect = false;
			PowerUPDisplayer2.DeactivatedPowerUP();
		}
		yield return new WaitForSeconds(wallSeconds);
		if (player1)
		{
			player1Wall.SetActive(false);
		}
		if (player2)
		{
			player2Wall.SetActive(false);
		}
	}
}
