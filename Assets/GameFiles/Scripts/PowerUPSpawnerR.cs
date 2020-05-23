// PowerUPSpawnerR
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUPSpawnerR : MonoBehaviour
{
	public ScriptablePowerUP[] storedPowerUPs;

	public PowerUPDisplayUI PowerUPDisplayer1;

	public PowerUPDisplayUI PowerUPDisplayer2;

	public int counterToRespawn;

	private bool takenPowerUp;

	public Image question;

	private Image boxSprite;

	private BoxCollider2D boxCollider;

	private void Awake()
	{
		question = base.gameObject.transform.GetChild(0).GetComponent<Image>();
		boxSprite = GetComponent<Image>();
		boxCollider = GetComponent<BoxCollider2D>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		int addPowerUp = Random.Range(0, storedPowerUPs.Length);
		Ball ball = other.gameObject.GetComponent<Ball>();
		if (ball.player1)
		{
			ball.player1GameObject.GetComponent<PowerUPInventoryR>().hasSpeed = storedPowerUPs[addPowerUp].hasSpeed;
			ball.player1GameObject.GetComponent<PowerUPInventoryR>().hasDeflect = storedPowerUPs[addPowerUp].hasDeflect;
			PowerUPDisplayer1.ActivatePowerUP(storedPowerUPs[addPowerUp].icon);
		}
		if (ball.player2)
		{
			ball.player2GameObject.GetComponent<PowerUPInventoryR>().hasSpeed = storedPowerUPs[addPowerUp].hasSpeed;
			ball.player2GameObject.GetComponent<PowerUPInventoryR>().hasDeflect = storedPowerUPs[addPowerUp].hasDeflect;
			PowerUPDisplayer2.ActivatePowerUP(storedPowerUPs[addPowerUp].icon);
		}
		StartCoroutine(RespawnPowerUP());
	}

	private IEnumerator RespawnPowerUP()
	{
		question.enabled = false;
		boxSprite.enabled = false;
		boxCollider.enabled = false;
		Debug.Log("Respawn Timer Started");
		yield return new WaitForSeconds(counterToRespawn);
		boxSprite.enabled = true;
		question.enabled = true;
		boxCollider.enabled = true;
		Debug.Log("Respawn Timer Ended");
	}
}
