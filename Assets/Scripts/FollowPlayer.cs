using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(7, 3, -5);


    void Start()
    {
        
    }


    void LateUpdate()
    {
        // camera position
        transform.position = player.transform.position + offset;
    }
}
