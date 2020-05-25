using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int speed;

	public KeyCode up;

	public KeyCode down;

	public KeyCode left;

	public KeyCode right;

	private bool moveUp;

	private bool moveDown;

	private bool moveLeft;

	private bool moveRight;
    private new Rigidbody2D rigidbody2D;

	private void Awake()
	{
        //Accede al rigidbody2D.
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
        //Controla el movimiento del jugador.
		if(Input.GetKey(up))
		{
			moveUp = true;
		}
		else if(Input.GetKeyUp(up))
		{
			moveUp = false;
		}
		if(Input.GetKey(down))
		{
			moveDown = true;
		}
		else if(Input.GetKeyUp(down))
		{
			moveDown = false;
		}
		if(Input.GetKey(left))
		{
			moveLeft = true;
		}
		else if(Input.GetKeyUp(left))
		{
			moveLeft = false;
		}
		if (Input.GetKey(right))
		{
			moveRight = true;
		}
		else if(Input.GetKeyUp(right))
		{
			moveRight = false;
		}
	}

	private void FixedUpdate()
	{
        //Ejecuta el movimiento del jugador.
		if(moveUp)
		{
			rigidbody2D.velocity = base.transform.up * speed;
		}
		if(moveDown)
		{
			rigidbody2D.velocity = base.transform.up * -speed;
		}
		if(!moveUp && !moveDown)
		{
			rigidbody2D.velocity = Vector3.zero;
		}
		if(moveLeft)
		{
			rigidbody2D.velocity = base.transform.right * -speed;
		}
		if(moveRight)
		{
			rigidbody2D.velocity = base.transform.right * speed;
		}
	}
}
