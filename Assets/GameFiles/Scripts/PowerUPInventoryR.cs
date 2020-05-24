// PowerUPInventoryR
using System.Collections;
using UnityEngine;

public class PowerUPInventoryR : MonoBehaviour
{

    //"Si tienes" variables.
	public bool hasSpeed;
	public bool hasDeflect;
    public bool hasBig;

    //"Si esta activa" variables.
    public bool deflectActive;
    public bool speedActive;
    public bool stopBall;

	public GameObject player1Wall;
	public GameObject player2Wall;
	public int wallSeconds;
    public int biggerSeconds;
	public bool player1;
	public bool player2;
	public KeyCode PowerUpKey;
	public PowerUPDisplayUI PowerUPDisplayer1;
	public PowerUPDisplayUI PowerUPDisplayer2;
	private Ball ball;
	private int newSpeed = 20;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(speedActive)
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
        //Activa el PowerUP de velocidad.
		if (Input.GetKeyDown(PowerUpKey) && hasSpeed)
		{
			speedActive = true;
		}

        //Ejecuta el PowerUP de velocidad.
		if(Input.GetKeyDown(PowerUpKey) && stopBall)
		{
			if(player1 == true)
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

			if(player2 == true)
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

        //Ejecuta el PowerUP de la muralla.
        if(Input.GetKeyDown(PowerUpKey) && hasDeflect == true)
		{
			StartCoroutine(RiseWall());
		}

        if(Input.GetKeyDown(PowerUpKey) && hasBig == true)
        {
            StartCoroutine(MakeBigger());
        }

	}

	private void FixedUpdate()
	{
		if(stopBall == true)
		{
			ball.speed = 0;
			ball.maxSpeed = 0;
		}
	}

    //Aplica el efecto Wall.
	private IEnumerator RiseWall()
	{
		if(player1 == true)
		{
			player1Wall.SetActive(true);
			hasDeflect = false;
			PowerUPDisplayer1.DeactivatedPowerUP();
		}

		if(player2 == true)
		{
			player2Wall.SetActive(true);
			hasDeflect = false;
			PowerUPDisplayer2.DeactivatedPowerUP();
		}

		yield return new WaitForSeconds(wallSeconds);

		if(player1 == true)
		{
			player1Wall.SetActive(false);
		}

		if(player2 == true)
		{
			player2Wall.SetActive(false);
		}
	}

    private IEnumerator MakeBigger()
    {
        if(player1 == true)
        {
            transform.localScale += new Vector3(0,25,0);
            hasBig = false;
			PowerUPDisplayer1.DeactivatedPowerUP();
        }

        if(player2 == true)
        {
            transform.localScale += new Vector3(0,25,0);
            hasBig = false;
			PowerUPDisplayer2.DeactivatedPowerUP();
        }

        yield return new WaitForSeconds(biggerSeconds);

        if(player1 == true)
        {
            transform.localScale -= new Vector3(0,25,0);
        }

        if(player2 == true)
        {
            transform.localScale -= new Vector3(0,25,0);
        }
    }
}
