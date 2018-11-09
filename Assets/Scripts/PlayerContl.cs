using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContl : MonoBehaviour
{// Use this for initialization
    public Animator animController;
    public float speed;
    public bool EnPiso;
    public float g;
    public float velSalto = 3f;
    private Rigidbody rb;
    GameObject bb;
    public Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bb = GameObject.FindGameObjectWithTag("PlayerAnimator");
        animController = bb.GetComponent<Animator>();
        movement = new Vector3(0, 0, 0);

    }

    void Update()
    {
        //variables para traslación
        bool adelante = Input.GetKey("w");
        bool atras = Input.GetKey("s");
        bool derecha = Input.GetKey("d");
        bool izquierda = Input.GetKey("a");
        bool salto = Input.GetKey("space");
        //variables para la rotación
        bool RotAdelante = Input.GetKeyDown("w");
        bool RotAtras = Input.GetKeyDown("s");
        bool RotDerecha = Input.GetKeyDown("d");
        bool RotIzquierda = Input.GetKeyDown("a");
        bool recta = adelante || atras || derecha || izquierda;
        bool diagonal = adelante && derecha || atras && derecha ||
            adelante && izquierda || atras && izquierda;

        //rectas------------------------------------------------------------------------------
        if (adelante)
        {
            //Animaciones
            animController.SetBool("saltar", false);
            animController.SetBool("idle", false);
            animController.SetBool("correr", true);
            //rotación
            if (RotAdelante)
            {
                transform.rotation = Quaternion.Euler(0.0f, 270F, 0.0f);
            }

            //movimiento
            movement = new Vector3(0.0f, 0.0f, 1f);
        }
        if (atras)
        {
            //Animaciones
            animController.SetBool("saltar", false);
            animController.SetBool("idle", false);
            animController.SetBool("correr", true);
            //rotacion
            if (RotAtras)
            {
                transform.rotation = Quaternion.Euler(0.0f, 90F, 0.0f);
            }

            //movimiento
            movement = new Vector3(0.0f, 0.0f, 1f);
        }
        if (derecha)
        {
            //Animaciones
            animController.SetBool("saltar", false);
            animController.SetBool("idle", false);
            animController.SetBool("correr", true);
            //rotacion
            if (RotDerecha)
            {
                transform.rotation = Quaternion.Euler(0.0f, 0.0F, 0.0f);
            }
            //movimiento
            movement = new Vector3(0.0f, 0.0f, 1f);

        }
        if (izquierda)
        {
            //Animaciones
            animController.SetBool("saltar", false);
            animController.SetBool("idle", false);
            animController.SetBool("correr", true);
            //rotacion
            if (RotIzquierda)
            {
                transform.rotation = Quaternion.Euler(0.0f, 180F, 0.0f);
            }
            //movimiento
            movement = new Vector3(0.0f, 0.0f, 1f);
        }
        if (recta || diagonal)
        {
            transform.Translate(movement * speed * Time.deltaTime);
        }

        if (salto && EnPiso == true)
        {
            rb.velocity = new Vector3(0, velSalto -g, 0);
            EnPiso = false;
        }else if (rb.velocity.y <=1)
        {
            rb.velocity = new Vector3(0, -g, 0);
        }

    }

    //Con este metodo verifico que està en el suelo
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "plataforma")
        {
            EnPiso = true;
        }
    }
}