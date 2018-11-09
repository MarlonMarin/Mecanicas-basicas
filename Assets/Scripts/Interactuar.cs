using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public Vector3 offset, posinicial;
    public bool interactuando = false;
    public GameObject player;
    void Start()
    {
        posinicial = transform.position;
    }

    void Update()
    {
        if (transform.position.y < -500|| transform.position.y > 100)
        {
            transform.position = posinicial;
        }
        if (interactuando && Input.GetKey("i"))
        {

            transform.position = player.transform.position + offset;
        }
        else
        {
            offset = transform.position - player.transform.position;
        }
    }


    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            float posY;
            posY = col.transform.position.y - 0.5f;

            offset = transform.position - new Vector3(col.transform.position.x, posY, col.transform.position.z);
            interactuando = true;
        }
        else
        {
            interactuando = false;
        }
        if (col.gameObject.tag == "reiniciar")
        {
            transform.position = posinicial;
        }
    }
}