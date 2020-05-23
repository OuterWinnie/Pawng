// PlayerController
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int speed;

	public KeyCode up;

	public KeyCode down;

	public KeyCode left;

	public KeyCode right;

	private new Rigidbody2D rigidbody2D;

	public bool moveUp;

	public bool moveDown;

	public bool moveLeft;

	public bool moveRight;

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (Input.GetKey(up))
		{
			Debug.Log("UP");
			moveUp = true;
		}
		else if (Input.GetKeyUp(up))
		{
			moveUp = false;
		}
		if (Input.GetKey(down))
		{
			Debug.Log("Down");
			moveDown = true;
		}
		else if (Input.GetKeyUp(down))
		{
			moveDown = false;
		}
		if (Input.GetKey(left))
		{
			Debug.Log("Left");
			moveLeft = true;
		}
		else if (Input.GetKeyUp(left))
		{
			moveLeft = false;
		}
		if (Input.GetKey(right))
		{
			Debug.Log("Right");
			moveRight = true;
		}
		else if (Input.GetKeyUp(right))
		{
			moveRight = false;
		}
	}

	private void FixedUpdate()
	{
		if (moveUp)
		{
			rigidbody2D.velocity = base.transform.up * speed;
		}
		if (moveDown)
		{
			rigidbody2D.velocity = base.transform.up * -speed;
		}
		if (!moveUp && !moveDown)
		{
			rigidbody2D.velocity = Vector3.zero;
		}
		if (moveLeft)
		{
			rigidbody2D.velocity = base.transform.right * -speed;
		}
		if (moveRight)
		{
			rigidbody2D.velocity = base.transform.right * speed;
		}
	}
}
