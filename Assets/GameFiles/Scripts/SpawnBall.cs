// SpawnBall
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public static SpawnBall instance;
	public GameObject ballPrefab;
	public KeyCode reset;
	private GameObject lastBall;

    void Awake()
    {
        instance = this;
    }


	private void InstantiateBall()
	{   
        //Spawnea la pelota.
		GameObject lball = lastBall = Object.Instantiate(ballPrefab, base.transform.position, Quaternion.identity);
	}

	public void DestroyBall()
	{
        //Destruye la pelota.
		Object.Destroy(lastBall);

        //Vuelve a spawnear la pelota.
		InstantiateBall();
	}

	private void Update()
	{
        //Si pulsas el boton reset se destruye la pelota.
		if (Input.GetKeyDown(reset))
		{
			DestroyBall();
		}
	}
}
