using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bengala : MonoBehaviour {
    public float vel = 5;
    public float gravedad = 2;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        // Add velocity to the bullet
        //this.gameObject.GetComponent<Rigidbody>().velocity = this.transform.forward * 10;
        this.transform.Translate(vel *Time.deltaTime,0, 0);

        // Destroy the bullet after 2 seconds
        Destroy(this.gameObject, 2.0f);
    }
}
