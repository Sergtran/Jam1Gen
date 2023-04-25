using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public GameObject player;
    //public Vector3 offset = new Vector3(0, 10, -15);

    public Transform target;
    public float smoothSpeed = 0.125f; // velocidad de seguimiento de la cámara
    public Vector3 offset; // distancia entre la cámara y el personaje


    void Start()
    {

    }


    void LateUpdate()
    {
        // camera position
        // transform.position = player.transform.position + offset;

        Vector3 desiredPosition = target.position + offset; // posición deseada de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // posición suavizada de la cámara
        transform.position = smoothedPosition; // actualiza la posición de la cámara

        transform.LookAt(target);
    }
}
