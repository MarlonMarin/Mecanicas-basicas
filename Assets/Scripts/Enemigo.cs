using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour {


    Transform Objetivo;     //Personaje principal  
    public float DistanciaDetec;     //Distancia de deteccion
    public float DistanciaNear = 1;     //Distancia maxima del acercamiento del personaje
    public float speedMov;         //Velocidad de movimiento
    public float speedRot;         //Velocidad de rotacion
    Vector3 Direccion;          //Direccion de movimiento
    public float invertDireccion;
    Vector3 DireccionRotacion;  //Mantener frente al enemigo
    private Rigidbody rb;
    public string escena;       //para cambiar de escena

    public bool llave1=false;
    //static Animator anim;

    void Start () {

        //Encontramos el personaje principal usando Tags
        Objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();

    }


    void Update()
    {
        if (llave1) {
            transform.position = Objetivo.transform.position - new Vector3(DistanciaDetec, 0, DistanciaDetec);
            llave1 = false;
        }


        if (Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaDetec && Vector3.Distance(Objetivo.transform.position, transform.position) >= DistanciaNear)
        {
            //Rotacion
            DireccionRotacion = Objetivo.position - transform.position; //halla la linea entre el enemigo y el personaje
            float MovimientoFluidoRot = speedRot * Time.deltaTime;        //Da un movimiento fluido
            DireccionRotacion.y = 0; //no se rota en el eje y
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DireccionRotacion * -invertDireccion), MovimientoFluidoRot); // rota

            //Desplazamiento
            Direccion = new Vector3(Objetivo.transform.position.x, Objetivo.transform.position.y , Objetivo.transform.position.z);        //Guarda la posicion del personaje principal
            float MovimientoFluido = speedMov * Time.deltaTime;        //Da un movimiento fluido
            transform.position = Vector3.MoveTowards(transform.position, Direccion, MovimientoFluido);      //El enemigo persigue
            //rb.velocity = Vector3.MoveTowards(transform.position, Direccion, MovimientoFluido);      //El enemigo persigue
            //anim.SetBool("Detectado", true);
        }

        else if (Vector3.Distance(Objetivo.transform.position, transform.position) < DistanciaNear)
        {

            //Rotacion
            DireccionRotacion = Objetivo.position - transform.position; //halla la linea entre el enemigo y el personaje
            float MovimientoFluidoRot = speedRot * Time.deltaTime;        //Da un movimiento fluido
            DireccionRotacion.y = 0; //no se rota en el eje y
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DireccionRotacion), MovimientoFluidoRot); // rota

            //anim.SetBool("Detectado", true);
        }

        else
        {
            //anim.SetBool("Detectado", false);
        }
        rb.velocity = new Vector3(0, -10 * Time.deltaTime, 0);

    }
    public void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player" )
        {
            //Debug.Log("Game over");
            SceneManager.LoadScene(escena);
        }

    }
}
