using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    protected Transform player;


    protected Vector3 offset;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.transform.position;

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;

        
    }
}
