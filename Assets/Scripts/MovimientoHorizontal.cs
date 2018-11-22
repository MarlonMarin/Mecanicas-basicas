using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primero : MonoBehaviour {

    float LimiteSuperiorX;
    float LimiteInferiorX;
    float Velocidad;

    void Start () {
        this.transform.Translate(new Vector3(0, 0, 0));

        LimiteSuperiorX = 7f;
        LimiteInferiorX = -7f;
        Velocidad = 2f;
    }
	
	void Update () {
        
            this.transform.Translate(new Vector3(Velocidad, 0f, 0f)*Time.deltaTime);

            if (this.transform.position.x > LimiteSuperiorX) { Velocidad = Velocidad * -1; ; }
            if (this.transform.position.x < LimiteInferiorX) { Velocidad = Velocidad * -1; }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {           
                Velocidad = Velocidad * -1;           
        }
    }
}
