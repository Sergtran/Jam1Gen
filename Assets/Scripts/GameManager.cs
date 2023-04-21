using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> food;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public int sumarTiempo = 10;
    public float timer = 5;
    public TextMeshProUGUI timerProText;
    public bool isGameActive;
    private int score;
    //private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        timerProText.text = "" + timer.ToString("0");

        Debug.Log(timer);

        if(timer < 0)
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
        restartButton.gameObject.SetActive(true);
        // Funciona como un booleano
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;

        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Este podria recibir un string con le nombre de la escena o cargar la escena actual como lo hacemos
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // con este llama por el numerp, y tambien podria con un string por el nombre
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene(1);
        //SceneManager.LoadScene("Prototype 5");
    }

    public void StartGame(/*int difficulty*/)
    {
        isGameActive = true;
        score = 0;
        //spawnRate /= difficulty;

        //StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

        Time.timeScale = 1;
    }
}
