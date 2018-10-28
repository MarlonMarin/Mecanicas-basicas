using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour {
    public Vector3 offset;
    public bool interactuando = false;
    public GameObject player;

    void LateUpdate()
    {
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
            posY = col.transform.position.y - 8 * Time.deltaTime;

            offset = transform.position - new Vector3(col.transform.position.x, posY , col.transform.position.z);
            interactuando = true;
        }
        else
        {
            interactuando = false;
        }

    }
}
