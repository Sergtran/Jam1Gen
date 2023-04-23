using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarComida : MonoBehaviour
{
    public List<GameObject> listaComida;
    public int posicionComida;
    public float posicionAleatoriaX;
    public float posicionAleatoriaY;
    public float posicionAleatoriaZ;
    public Vector3 posicionAleatoriaGeneral;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CrearComida());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CrearComida()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            posicionComida = Random.Range(0, listaComida.Count);
            Instantiate(listaComida[posicionComida], InstanciarPosicionAleatoria(), listaComida[posicionComida].transform.rotation);
        }
    }

    /*Esta funcion busca el GameObject al que se le haya asociado el codigo y busca dentro de su area una
        posicion aleatoria para instanciar el objeto deseado*/
    Vector3 InstanciarPosicionAleatoria()
    {
        posicionAleatoriaX = Random.Range(transform.position.x - (transform.localScale.x / 2), transform.position.x + (transform.localScale.x / 2));
        posicionAleatoriaZ = Random.Range(transform.position.z - (transform.localScale.z / 2), transform.position.z + (transform.localScale.z / 2));
        posicionAleatoriaY = transform.position.y + (transform.localScale.y / 2);
        posicionAleatoriaGeneral = new Vector3(posicionAleatoriaX, posicionAleatoriaY, posicionAleatoriaZ);
        return posicionAleatoriaGeneral;
    }
}