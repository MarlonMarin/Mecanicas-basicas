using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton : MonoBehaviour {

    public bool tocPlayer = false;
    public bool tocObj = false;
    public Vector3 posI;
    public Vector3 posF;
    public GameObject g;
	// Use this for initialization
	void Start () {

        posI = transform.position;
        //editar esta pocision si se quiere ir más a fondo con el boton
        posF = new Vector3(posI.x,posI.y - 0.3f,posI.z);
        g.active = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (tocPlayer || tocObj)
        {
            if (transform.position.y <= posF.y)
            {
                g.active = true;
                transform.position = new Vector3(posF.x, posF.y -0.2f, posF.z);
            }
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.9f * Time.deltaTime, transform.position.z);
            
        }
        else
        {
            if(transform.position.y < posI.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.9f * Time.deltaTime, transform.position.z);
            }
            if(transform.position.y >= posI.y - 0.05f)
            {
                g.active = false;
            }
            //Debug.Log(g.active);
            
        }
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "objeto")
        {
            tocObj = true;
        }
        else if(col.gameObject.tag == "Player")
        {
            tocPlayer = true;
        }
        else
        {
            tocObj = false;
            tocPlayer = false;
        }
    }

    void OnCollisionExit(Collision col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            //Debug.Log("sin tocar");
            tocPlayer = false;
        }else if (col2.gameObject.tag == "objeto")
        {
            //Debug.Log("sin tocar");
            tocObj = false;
        }
    }

}
