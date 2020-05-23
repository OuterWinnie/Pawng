// Goal
using UnityEngine;

public class Goal : MonoBehaviour
{
	public bool left;

	public bool right;

	public int player1;

	public int player2;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (right)
		{
			player1++;
			Score.instance.TranslateScorePlayer1(player1);
			Debug.Log(player1 + " : " + player2);
		}
		else if (left)
		{
			player2++;
			Score.instance.TranslateScorePlayer2(player2);
			Debug.Log(player1 + " : " + player2);
		}
	}
}
