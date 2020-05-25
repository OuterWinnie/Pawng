using System.Collections;
using UnityEngine;

public class PowerUPInventoryR : MonoBehaviour
{

    [Header("If has PowerUP")]
	public bool hasSpeed;
	public bool hasDeflect;
    public bool hasBig;
    public bool hasPlayerSpeed;

    [Header("PowerUPs tweaks")]
	public int wallSeconds;
    public int biggerSeconds;
    public int playerSpeedSeconds;
    public int newPlayerSpeed;

    [Header("General access")]
    public PlayerController player1Controller;
    public PlayerController player2Controller;
    public GameObject player1Wall;
	public GameObject player2Wall;
	public KeyCode PowerUpKey;
	public PowerUPDisplayUI PowerUPDisplayer1;
	public PowerUPDisplayUI PowerUPDisplayer2;

    private bool player1;
	private bool player2;
	private Ball ball;
	private int newSpeed = 20;

    //"Si esta activa" variables.
    private bool deflectActive;
    private bool speedActive;
    private bool stopBall;

    
    private void Awake()
    {
        //Comprueba que numero de jugador eres.
        if(tag == "Player 1")
        {
            player1 = true;
        }

        //Comprueba que numero de jugador eres.
        if(tag == "Player 2")
        {
            player2 = true;
        }
    }

	private void Update()
	{
        //Activa el PowerUP de velocidad.
		if(Input.GetKeyDown(PowerUpKey) && hasSpeed)
		{
			speedActive = true;
		}

        //Activa el PowerUP de PlayerSpeed.
        if(Input.GetKeyDown(PowerUpKey) && hasPlayerSpeed)
        {   
            hasPlayerSpeed = false;
            StartCoroutine(ChangeSpeed());
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
        //Frena la pelota para la habilidad de Speed Ball.
		if(stopBall == true)
		{
			ball.speed = 0;
			ball.maxSpeed = 0;
		}
	}

    private void OnCollisionEnter2D(Collision2D other)
	{
        //Conituacion del Speed Ball.
		if(speedActive)
		{
			if (other.gameObject.tag == "Ball")
			{
				ball = other.gameObject.GetComponent<Ball>();
                ball.gameObject.transform.parent = base.transform;
                ball.GetComponent<Rigidbody2D>().isKinematic = true;
			    stopBall = true;
			}
		}
	}

    private IEnumerator ChangeSpeed()
    {
        var stockSpeed = player1Controller.speed;

        if(player1)
        {
            player1Controller.speed = newPlayerSpeed;
        }

        if(player2)
        {
            player2Controller.speed = newPlayerSpeed;
        }

        yield return new WaitForSeconds(playerSpeedSeconds);

        if(player1)
        {
            player1Controller.speed = stockSpeed;
            PowerUPDisplayer1.DeactivatedPowerUP();
        }

        if(player2)
        {
            player2Controller.speed = stockSpeed;
            PowerUPDisplayer2.DeactivatedPowerUP();
        }
    }


    //Aplica el efecto Wall.
	private IEnumerator RiseWall()
	{
		if(player1 == true)
		{
			player1Wall.SetActive(true);
			hasDeflect = false;
		}

		if(player2 == true)
		{
			player2Wall.SetActive(true);
			hasDeflect = false;
		}

		yield return new WaitForSeconds(wallSeconds);

		if(player1 == true)
		{
			player1Wall.SetActive(false);
            PowerUPDisplayer1.DeactivatedPowerUP();
		}

		if(player2 == true)
		{
			player2Wall.SetActive(false);
            PowerUPDisplayer2.DeactivatedPowerUP();
		}
	}

    //Activa el PowerUP MakeBigger.
    private IEnumerator MakeBigger()
    {
        if(player1 == true)
        {
            transform.localScale += new Vector3(0,25,0);
            hasBig = false;
        }

        if(player2 == true)
        {
            transform.localScale += new Vector3(0,25,0);
            hasBig = false;
        }

        yield return new WaitForSeconds(biggerSeconds);

        if(player1 == true)
        {
            transform.localScale -= new Vector3(0,25,0);
            PowerUPDisplayer1.DeactivatedPowerUP();
        }

        if(player2 == true)
        {
            transform.localScale -= new Vector3(0,25,0);
            PowerUPDisplayer2.DeactivatedPowerUP();
        }
    }
}
