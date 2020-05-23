// PlayerSpawner
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
	public GameObject player1Prefab;

	public GameObject player2Prefab;

	private GameObject spawnPlayer1;

	private GameObject spawnPlayer2;

	private GameObject player1Active;

	private void Awake()
	{
		spawnPlayer1 = GameObject.FindGameObjectWithTag("Spawn Player 1");
		spawnPlayer2 = GameObject.FindGameObjectWithTag("Spawn Player 2");
		player1Active = GameObject.FindGameObjectWithTag("Player 1");
		if (player1Active == null)
		{
			Object.Instantiate(player1Prefab, spawnPlayer1.transform.position, Quaternion.identity);
		}
		if (player1Active != null)
		{
			Object.Instantiate(player2Prefab, spawnPlayer2.transform.position, Quaternion.identity);
		}
	}
}
