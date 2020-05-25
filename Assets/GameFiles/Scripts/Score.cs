using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Score : MonoBehaviour
{
	public static Score instance;
	public TMP_Text scoreText;
	public KeyCode hideScore;
    
    private int whosWinner;
    private int winnerGoals;
	private int player1Score = 0;
	private int player2Score = 0;

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

        Load();
	}

	public void TranslateScorePlayer1(int player1)
	{
		player1Score = player1;
		UpdateScore();
	}

	public void TranslateScorePlayer2(int player2)
	{
		player2Score = player2;
		UpdateScore();
	}

	private void UpdateScore()
	{
		scoreText.gameObject.SetActive(true);
		scoreText.text = player1Score.ToString() + "                                                              " + player2Score.ToString();

        //Carga la pantalla de ganador.
        if(player1Score == winnerGoals)
        {
            whosWinner = 1;
            Save();
        }
        if(player2Score == winnerGoals)
        {
            whosWinner = 2;
            Save();
        }
	}

    private void Update()
	{
		if (Input.GetKeyDown(hideScore))
		{
			scoreText.gameObject.SetActive(false);
		}
	}

    public void Save()
    {
        //Nuevo archivo de guardado.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/winnerInfo.dat");

        //Guarda el nombre de usurario.
        PlayerData data = new PlayerData();
        data.winner = whosWinner.ToString();

        //Guarda los datos.
        bf.Serialize(file, data);
        file.Close();

        //Cambia a la pantalla de ganador.
        SceneManager.LoadScene(2);
    }


    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Carga los nombres de usuario.
            winnerGoals = int.Parse(data.score);

            Debug.Log("Loaded");
        }
    }
}
