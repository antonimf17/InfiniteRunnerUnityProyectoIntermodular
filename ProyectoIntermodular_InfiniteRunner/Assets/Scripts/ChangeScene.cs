using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ChangeScene : MonoBehaviour
{
 public void LoadScene(string Game)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Game);
    }

    public void ExitGame()
    {
        Application.Quit(); //Salir de la aplicación, cierra el juego completamente
    }

}
