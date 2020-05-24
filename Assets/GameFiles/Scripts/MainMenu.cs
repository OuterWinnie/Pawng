// MainMenu
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class MainMenu : MonoBehaviour
{
	
    public GameObject mainButtons;
    public GameObject optionButtons;
    public GameObject InputScreen1;
    public GameObject InputScreen2;
    public GameObject InputScore;
    public GameObject changeControlsButton;
    
    //Main Menu Buttons.
    public void InputUsername1()
    {
        InputScreen1.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void InputUsername2()
    {
        InputScreen1.SetActive(false);
        InputScreen2.SetActive(true);
    }

    public void InputScoreScreen()
    {
        mainButtons.SetActive(false);
        InputScreen2.SetActive(false);
        InputScore.SetActive(true);
    }

    public void StartGame()
	{
        Save();
        InputScore.SetActive(false);
		SceneManager.LoadScene(1);
	}

    void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

	public void Options()
	{
        mainButtons.SetActive(false);
        optionButtons.SetActive(true);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
    

    //Option Menu Buttons.
    public void ChangeControls()
    {
        optionButtons.SetActive(false);
        changeControlsButton.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainButtons.SetActive(true);
        optionButtons.SetActive(false);
    }

    public void BackToOptionsMenu()
    {
        changeControlsButton.SetActive(false);
        optionButtons.SetActive(true);
    }

    public void Save()
    {
        //Nuevo archivo de guardado.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        //Guarda el nombre de usurario.
        PlayerData data = new PlayerData();
        data.username1 = InputScreen1.GetComponent<TMP_InputField>().text;
        data.username2 = InputScreen2.GetComponent<TMP_InputField>().text;
        data.score = InputScore.GetComponent<TMP_InputField>().text;

        //Guarda los datos.
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            //Carga los nombres de usuario.
            InputScreen1.GetComponent<TMP_InputField>().text = data.username1;
            InputScreen2.GetComponent<TMP_InputField>().text = data.username2;

            Debug.Log("Loaded");

            InputScoreScreen();
        }

        else
        {
            InputUsername1();
        }
    }
}

[Serializable]
class PlayerData
{
    public string username1;
    public  string username2;
    public string score;
    public string winner;
}
