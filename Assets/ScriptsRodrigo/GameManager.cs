using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource musica;
    // Start is called before the first frame update
    void Start()
    {
        musica = gameObject.GetComponent<AudioSource>();
         musica.Play();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
