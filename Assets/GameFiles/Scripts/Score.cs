// Score
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
	public static Score instance;

	public TMP_Text scoreText;

	public KeyCode hideScore;

	private string player1Score = "0";

	private string player2Score = "0";

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Debug.Log("Busy");
		}
		scoreText = GetComponent<TMP_Text>();
	}

	public void TranslateScorePlayer1(int player1)
	{
		player1Score = player1.ToString();
		UpdateScore();
	}

	public void TranslateScorePlayer2(int player2)
	{
		player2Score = player2.ToString();
		UpdateScore();
	}

	private void UpdateScore()
	{
		scoreText.gameObject.SetActive(value: true);
		scoreText.text = player1Score + "                                                              " + player2Score;
	}

	private void Update()
	{
		if (Input.GetKeyDown(hideScore))
		{
			scoreText.gameObject.SetActive(value: false);
		}
	}
}
