using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int score;
    public static GameManager inst;
    public GameObject panelUI;
    public GameObject panelPausa;
    public bool isPaused = false;
    public GameObject PanelGameOver;
   

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] PlayerMovement playerMovement;

    public void IncrementScore ()
    {
        score++;
        scoreText.text = "Score: " + score;
        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

   private void Awake ()

    {
        inst = this;

    } 

  public void Retry()
    {
        PanelGameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;

    }
 public void Over()
    {
        PanelGameOver.SetActive(true);
        Time.timeScale = 0f;


    }
}
