using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public int sumar= 20;
    public float timer = 0;
    public TextMeshProUGUI textoTimerPro;
    

private void Start() {
    SumarTiempo();
}
    // Update is called once per frame
    void Update()
    {

     timer -= Time.deltaTime; 
     textoTimerPro.text = "" + timer.ToString("0");

    }

    public void SumarTiempo(){
        timer += sumar; 
    }
}
