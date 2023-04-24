using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{


    public void EscenaJuego()
    {
        SceneManager.LoadScene("Mapp");
    }
    public void CerrarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
