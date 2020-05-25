using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Goal : MonoBehaviour
{
	public bool right;
	public bool left;
    
    private bool autoStart;
	private int player1;
	private int player2;

    void Awake()
    {
        Load();
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
        //Suma un punto al marcador.
		if(left && autoStart == false)
		{
			player1++;
			Score.instance.TranslateScorePlayer1(player1);
		}
        
		else if(right && autoStart == false)
		{
			player2++;
			Score.instance.TranslateScorePlayer2(player2);
		}

        //Suma un punto al marcador.
		if(left && autoStart)
		{
			player1++;
			Score.instance.TranslateScorePlayer1(player1);
            SpawnBall.instance.DestroyBall();   
		}
        
		else if(right && autoStart)
		{
			player2++;
			Score.instance.TranslateScorePlayer2(player2);
            SpawnBall.instance.DestroyBall();
		}
	}


    void Load()
    {
        //Si existe el archivo.
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            //Carga el archvio de guardado.
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Carga los nombres de usuario.
            autoStart = data.autoStart;

            Debug.Log("Loaded");
        }
    }


}
