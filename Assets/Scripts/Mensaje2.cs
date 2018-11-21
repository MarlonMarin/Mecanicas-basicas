using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mensaje2 : MonoBehaviour
{
    bool enviar;
    public GameObject text;

    // Use this for initialization
    void Start()
    {
        enviar = false;
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enviar)
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enviar = true;
        }
    }
}
