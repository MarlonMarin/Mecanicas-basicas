using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public bool EnPiso;
    public float g;
    public float velSalto = 3f;
    private Rigidbody rb;
    public Animator animController;
    float rotateSpeed = 3;
    GameObject bb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bb = GameObject.FindGameObjectWithTag("PlayerAnimator");
    }

    void Update()
    {
        Debug.Log(transform.rotation.y);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool salto = Input.GetKeyDown("space");


        if (moveVertical != 0)
        {
            animController.SetBool("correr", true);
            animController.SetBool("idle", false);
        }
        else
        {
            animController.SetBool("correr", false);
            animController.SetBool("idle", true);
        }

        if (salto && EnPiso == true)
        {
            rb.velocity = new Vector3(0, velSalto, 0);
            EnPiso = false;
        }
        else if (EnPiso == false)
        {
            rb.velocity = new Vector3(0, -g, 0);
        }

        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        transform.Rotate(0, rotateSpeed * Input.GetAxis("Horizontal"), 0);
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
