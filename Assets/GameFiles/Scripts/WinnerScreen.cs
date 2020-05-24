using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class WinnerScreen : MonoBehaviour
{
    public int whoWin;
    public string usernameWinner;

    void Awake()
    {
        Load();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/winnerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/winnerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Carga los nombres de usuario y el ganador.
            whoWin = int.Parse(data.winner);

            Debug.Log("Loaded");
        }
        
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat") && whoWin != 0)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Carga los nombres de usuario y el ganador.
            if(whoWin == 1)
            GetComponent<TMP_Text>().text = data.username1.ToUpper() + " IS THE WINNER!";

            if(whoWin == 2)
            GetComponent<TMP_Text>().text = data.username2.ToUpper() + " IS THE WINNER!";

            Debug.Log("Loaded");
        }

    }
}
