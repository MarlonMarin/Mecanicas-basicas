using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public bool EnPiso;
    public float g;
    public float velSalto = 3f;
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
        }else if(EnPiso == false)
        {
            rb.velocity = new Vector3(0, -g , 0);
        }
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime); 
    }

    //Con este metodo verifico que està en el suelo
    public void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "plataforma" )
        {
            EnPiso = true;
        } 
    }
}
