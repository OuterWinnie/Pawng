using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
	public int maxSpeed;

	public int speed;
    public float avoidYStuckForce;
    public float avoidXStuckForce;
	public bool player1;

	public bool player2;
    public GameObject player1GameObject;

	public GameObject player2GameObject;

	private new Rigidbody2D rigidbody2D;
    private bool avoidStuckY;
    private bool avoidStuckX;

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

        StartCoroutine(checkSpeedNextFrame());

        if(avoidStuckY == true)
        {
            if(player1 == true)
            rigidbody2D.AddForce(new Vector2(0,avoidYStuckForce));
            else if(player2 == true)
            rigidbody2D.AddForce(new Vector2(0, -avoidYStuckForce));
        }
        else if(avoidStuckX == true)
        {
            if(player1 == true)
            rigidbody2D.AddForce(new Vector2(avoidXStuckForce,0));
            else if(player2 == true)
            rigidbody2D.AddForce(new Vector2(-avoidXStuckForce,0));
        }
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

    private IEnumerator checkSpeedNextFrame()
    {
        float lastY = rigidbody2D.position.y;
        float lastX = rigidbody2D.position.x;

        yield return (0);

        //Check last y position to avoid stuck.
        if(lastY == rigidbody2D.position.y)
        {
            avoidStuckY = true;
            Debug.Log("Stuck");
        }
        else
        {
            avoidStuckY = false;
            Debug.Log("Not Stuck");
        }

        //Check last x position to avoid stuck.
        if(lastX == rigidbody2D.position.x)
        {
            avoidStuckX = true;
            Debug.Log("Stuck");
        }
        else
        {
            avoidStuckX = false;
            Debug.Log("Not Stuck");
        }
    }
}
