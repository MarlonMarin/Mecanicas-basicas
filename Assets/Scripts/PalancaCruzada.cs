using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaCruzada : MonoBehaviour {

    public GameObject[] obj; 
    public GameObject[] activar;
    Transform objetivo;             //Personaje principal  
    public float speedRot;          //Velocidad de rotacion
    Vector3 Direccion;              //Direccion de movimiento
    Vector3 DireccionRotacion;      //Mantener frente al enemigo
    bool girando= false;
    Vector3 offset;
    bool cambio = false;


    // Use this for initialization
    void Start() {
            // Encontramos el personaje principal usando Tags
            objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < activar.Length; i++)
        {
            activar[i].active = false;

        }

    }

    // Update is called once per frame
    void LateUpdate()
    {
        cambio = !cambio;
        if (girando && Input.GetKey("i") && cambio)
        {
            Debug.Log("entra if");
            objetivo.transform.position = transform.position + offset * -1;

            //Rotacion
            DireccionRotacion = objetivo.position - transform.position;                     //halla la linea entre la palanca y el personaje
            float MovimientoFluidoRot = speedRot * Time.deltaTime;                          //Da un movimiento fluido
            DireccionRotacion.y = 0;                                                        //no se rota en el eje y
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(DireccionRotacion), MovimientoFluidoRot);           // rota
            Vector3[] negpos = new Vector3[2];
            negpos[0] = new Vector3(0,45,0);
            negpos[1] = new Vector3(0, 90, 0);
            for (int i = 0; i < obj.Length; i++)

            {
                obj[i].transform.rotation = Quaternion.Slerp(obj[i].transform.rotation,
                    Quaternion.LookRotation(DireccionRotacion), MovimientoFluidoRot);   // rota
                Debug.Log((int)obj[i].transform.rotation.eulerAngles.y);

                if ((int)obj[i].transform.rotation.eulerAngles.y >= 30 && (int)obj[i].transform.rotation.eulerAngles.y <= 300)
                {
                    for (int j = 0; j < activar.Length; j++)
                    {
                        activar[j].active = false;

                    }
                }
                else
                {
                    for (int k = 0; k < activar.Length; k++)
                    {
                        activar[k].active = true;

                    }
                }

            }

            
        }
        else
        {
            offset = transform.position - objetivo.transform.position;
        }
        offset = transform.position - objetivo.transform.position;
        
    }
        public void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                girando = true;
                offset = transform.position - new Vector3(col.transform.position.x, col.transform.position.y, col.transform.position.z);
                //Debug.Log("entra");
            }
        }

    void OnCollisionExit(Collision col2)
    {
        if (col2.gameObject.tag == "Player")
        {
            //Debug.Log("sin tocar");
            girando = false;
        }
    }
}
