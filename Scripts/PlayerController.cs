using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public bool EnPiso;
    public float velSalto = 3f;
    public bool interactuando = false;
    Vector3 offset;
    public GameObject objeto;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool salto = Input.GetKeyDown("space");

        if (salto && EnPiso == true)
        {
            rb.velocity = new Vector3(0, velSalto, 0);
            EnPiso = false;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

        interactuar(objeto);

    }


    


    //Con este metodo verifico que està en el suelo
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "plataforma" )
        {
            EnPiso = true;
        }
        
    }
    
    public void interactuar(GameObject g)
    {
       
        //bool interactuando = Input.GetKeyDown("i");
        if (g.gameObject.tag == "objeto" && Input.GetKeyDown("i"))
        {
            Vector3 x = g.transform.position - this.transform.position;
            g.transform.position = this.transform.position + x;
        }
        
    }

    //void Start()
    //{
    //    offset = transform.position - player.transform.position;
    //}

    //void LateUpdate()
    //{
    //    transform.position = player.transform.position + offset;
    //}
}
