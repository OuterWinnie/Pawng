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
    public GameObject GameSettings;
    public GameObject autoStartSettings;
    public GameObject InputPlayer1;
    public GameObject InputPlayer2;
    public GameObject InputScore;
    public GameObject changeControlsButton;
    
    public bool autoStart = false;


    void Awake()
    {
        if(File.Exists(Application.persistentDataPath + "/options.dat"))
        LoadOptions();
    }
    
    //Main Menu Buttons.
    public void InputUsername1()
    {   
        //Activa la ventana de introduccion de texto para el jugador 1.
        InputPlayer1.SetActive(true);
        mainButtons.SetActive(false);
    }

    public void InputUsername2()
    {
        //Activa la ventana de introduccion de texto para el jugador 2.
        InputPlayer1.SetActive(false);
        InputPlayer2.SetActive(true);
    }

    public void InputScoreScreen()
    {
        //Activa la ventana de introduccion de texto para la cantidad de goles.
        mainButtons.SetActive(false);
        InputPlayer2.SetActive(false);
        InputScore.SetActive(true);
    }

    public void StartGame()
	{
        //Guarda los nombres de usuario y la cantidad de goles.
        Save();

        //Empieza el partido.
        InputScore.SetActive(false);
		SceneManager.LoadScene(1);
	}

    void LoadGame()
    {
        //Carga la siguiente escena.
        SceneManager.LoadScene(1);
    }

	public void Options()
	{
        //Abre el menu de opciones.
        mainButtons.SetActive(false);
        optionButtons.SetActive(true);
	}

    public void MatchSettings()
	{
        //Abre el menu de opciones.
        optionButtons.SetActive(false);
        GameSettings.SetActive(true);

        if(autoStart == false)
        autoStartSettings.GetComponent<TMP_Text>().text = "AutoStart - Deactivated";

        if(autoStart == true)
        autoStartSettings.GetComponent<TMP_Text>().text = "AutoStart - Activate";
	}

    public void ChangeStart()
    {
        autoStart = !autoStart;

        if(autoStart == false)
        autoStartSettings.GetComponent<TMP_Text>().text = "AutoStart - Deactivated";

        if(autoStart == true)
        autoStartSettings.GetComponent<TMP_Text>().text = "AutoStart - Activate";
    }

	public void ExitGame()
	{
        //Sale del juego.
		Application.Quit();
	}

    //Menu de Opciones.
    public void ChangeControls()
    {
        //Abre el menu de cambiar los controles.
        optionButtons.SetActive(false);
        changeControlsButton.SetActive(true);
    }

    public void BackToMainMenu()
    {
        //Vuelves al menu principal.
        mainButtons.SetActive(true);
        optionButtons.SetActive(false);
        SaveOptions();
    }

    public void BackToOptionsMenu()
    {
        //Vuelves al menu de opciones.
        changeControlsButton.SetActive(false);
        GameSettings.SetActive(false);
        optionButtons.SetActive(true);
    }

    public void Save()
    {
        //Nuevo archivo de guardado.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        //Guarda el nombre de usurario.
        PlayerData data = new PlayerData();
        data.username1 = InputPlayer1.GetComponent<TMP_InputField>().text;
        data.username2 = InputPlayer2.GetComponent<TMP_InputField>().text;
        data.score = InputScore.GetComponent<TMP_InputField>().text;
        
        SaveOptions();

        //Guarda los datos.
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
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
            InputPlayer1.GetComponent<TMP_InputField>().text = data.username1;
            InputPlayer2.GetComponent<TMP_InputField>().text = data.username2;
            
            LoadOptions();

            Debug.Log("Loaded");

            //Continua a la introduccion de los goles.
            InputScoreScreen();
        }

        else
        {   
            //Si no existe el archivo de guardado, te lleva a la introduccion de tu nombre de usuario.
            InputUsername1();
        }
    }

    public void LoadOptions()
    {
        //Carga el archvio de guardado.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/options.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);
        file.Close();

        //Carga los nombres de usuario.
        if(data.autoStart == 0)
        autoStart = false;
        else if(data.autoStart == 1)
        autoStart = true;
    }

    public void SaveOptions()
    {
        //Nuevo archivo de guardado.
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/options.dat");
        PlayerData data = new PlayerData();

        if(autoStart == true)
        data.autoStart = 1;
        else if(autoStart == false)
        data.autoStart = 0;

        //Guarda los datos.
        bf.Serialize(file, data);
        file.Close();

    }
}

[Serializable]
class PlayerData
{
    public string username1;
    public  string username2;
    public string score;
    public string winner;
    public int autoStart;
}
