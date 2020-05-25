using UnityEngine;

public class Ball : MonoBehaviour
{
	public int maxSpeed;

	public int speed;
	public bool player1;

	public bool player2;
    public GameObject player1GameObject;

	public GameObject player2GameObject;

	private new Rigidbody2D rigidbody2D;

	private void Awake()
	{
        //Accede al rigidbody2d.
		rigidbody2D = GetComponent<Rigidbody2D>();

        //Ejecuta StartMatch para comenzar el partido.
		StartMatch();
	}

	private void StartMatch()
	{
        //Decide aleatoriamente hacia que dirrecion se va a disparar la pelota.
		if(Random.Range(0, 2) == 0)
		{
			Debug.Log("Left");
			rigidbody2D.velocity = base.transform.right * -speed;
		}
		else
		{
			Debug.Log("Right");
			rigidbody2D.velocity = base.transform.right * speed;
		}
	}

	private void FixedUpdate()
	{
        //Controla que la pelota no supere una velocidad maxima.
		rigidbody2D.velocity = Vector2.ClampMagnitude(rigidbody2D.velocity, maxSpeed);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
        //Almacena el ultimo jugador que toco la pelota.
		if (other.gameObject.tag == "Player 1")
		{
			player1 = true;
			player2 = false;
			player1GameObject = other.gameObject;
		}
		if (other.gameObject.tag == "Player 2")
		{
			player2 = true;
			player1 = false;
			player2GameObject = other.gameObject;
		}
	}
}
