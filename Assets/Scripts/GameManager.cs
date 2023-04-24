using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public AudioSource musifaFondo;
    public AudioSource sonidoMar;
    public int sumarTiempo = 10;
    public float timer = 5;
    public TextMeshProUGUI timerProText;
    public bool isGameActive;
    public int score;

    public AudioSource sonidoGameOver;
    //private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        musifaFondo.Stop();
        sonidoMar.Stop();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        timerProText.text = "" + timer.ToString("TIME : 0");

        Debug.Log(timer);

        if (timer < 0)
        {
             
            GameOver();
        }
    }

    public void SumarTiempo()
    {
        timer += sumarTiempo;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
       
        Invoke("EjecutarGameOver", .1f);
          Invoke("EscenaInicio", 2f);
    }

    public void RestartGame()
    {
        // con este llama por el numerp, y tambien podria con un string por el nombre
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene("Prototype 5");
    }

    public void StartGame()
    {
        musifaFondo.Play();
        sonidoMar.Play();
        isGameActive = true;
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
        Time.timeScale = 1;

    }

    private void EjecutarGameOver()
    {
         sonidoGameOver.Play();
        musifaFondo.Stop();
        sonidoMar.Stop();
        //restartButton.gameObject.SetActive(true);
        // Funciona como un booleano
        //gameOverText.gameObject.SetActive(true);
        isGameActive = false;
       // Time.timeScale = 0;
        
    }

     public void EscenaInicio()
    {
        SceneManager.LoadScene("MenuInical");
    }
}
