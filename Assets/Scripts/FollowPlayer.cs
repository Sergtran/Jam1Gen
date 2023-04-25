using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public GameObject player;
    //public Vector3 offset = new Vector3(0, 10, -15);

    public Transform target;
    public float smoothSpeed = 0.125f; // velocidad de seguimiento de la c�mara
    public Vector3 offset; // distancia entre la c�mara y el personaje


    void Start()
    {

    }


    void LateUpdate()
    {
        // camera position
        // transform.position = player.transform.position + offset;

        Vector3 desiredPosition = target.position + offset; // posici�n deseada de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // posici�n suavizada de la c�mara
        transform.position = smoothedPosition; // actualiza la posici�n de la c�mara

        transform.LookAt(target);
    }
}
