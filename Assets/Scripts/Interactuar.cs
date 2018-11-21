using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuar : MonoBehaviour
{
    public Vector3 offset, posinicial;
    public bool interactuando = false;
    public GameObject player, mano;
    public Rigidbody Rllave;
    bool enviar;
    public GameObject text;
    public float posY;

    void Start()
    {
 
        enviar = false;
        text.SetActive(false);
        mano = GameObject.FindGameObjectWithTag("mano");
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
            Rllave.detectCollisions = false;
            transform.position = mano.transform.position;
            //transform.position = player.transform.position + offset;
        }
        else
        {
            Rllave.detectCollisions = true;
            offset = transform.position - mano.transform.position;
            //offset = transform.position - player.transform.position;
        }
        //para enviar un mensaje en el canvas
        if (enviar)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }


    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            //posY = col.transform.position.z +100f;
            //    posY = col.transform.position.y - 0.5f;

            //    offset = transform.position - new Vector3(col.transform.position.x, posY, col.transform.position.z);
            //offset = new Vector3(transform.position.x,transform.position.y, posY);
            interactuando = true;

                enviar = true;
        }
        else
        {
            interactuando = false;
            enviar = false;
        }
        if (col.gameObject.tag == "reiniciar")
        {
            transform.position = posinicial;
        }
    }
}