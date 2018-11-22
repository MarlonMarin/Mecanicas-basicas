using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirar : MonoBehaviour {
    public Transform Objective;
    public float MovementSpeed = 5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direccion = Objective.position - transform.position;
        Quaternion rotacion = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, MovementSpeed * Time.deltaTime);
    }
}
