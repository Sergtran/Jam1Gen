using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 10, -15);


    void Start()
    {

    }


    void LateUpdate()
    {
        // camera position
        transform.position = player.transform.position + offset;
    }
}
