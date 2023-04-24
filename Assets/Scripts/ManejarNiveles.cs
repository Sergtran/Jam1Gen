using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejarNiveles : MonoBehaviour
{
    public List<GameObject> listaNiveles;
    public GameManager gameManager;
    private int puntaje;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        puntaje = gameManager.score;
        switch (puntaje)
        {
            case 50:
                listaNiveles[0].gameObject.SetActive(true);
                break;
            case 100:
                listaNiveles[1].gameObject.SetActive(true);
                break;
            case 150:
                listaNiveles[2].gameObject.SetActive(true);
                break;
        }
    }
}
