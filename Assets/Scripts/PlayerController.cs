using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    public AudioSource sonidoMordisco;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            sonidoMordisco.Play();
            gameManager.UpdateScore(10);
            gameManager.SumarTiempo();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.name.Equals("Ocean")){
            GameManager manejador = GameObject.Find("GameManager").GetComponent<GameManager>();
            // GameManager manejador = new GameManager();
            manejador.GameOver();
        }
    }
}
