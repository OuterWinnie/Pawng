// SpawnBall
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
	public GameObject ball;

	public KeyCode reset;

	private GameObject lastBall;

	private void InstantiateBall()
	{
		GameObject lball = lastBall = Object.Instantiate(ball, base.transform.position, Quaternion.identity);
	}

	private void DestroyBall()
	{
		Object.Destroy(lastBall);
		InstantiateBall();
	}

	private void Update()
	{
		if (Input.GetKeyDown(reset))
		{
			DestroyBall();
		}
	}
}
