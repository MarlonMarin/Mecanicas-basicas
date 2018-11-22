using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour {
    float LimiteSuperiorZ;
    float LimiteInferiorZ;
    public float Velocidad;
    public int random;

    // Use this for initialization
    void Start () {
        //this.transform.Translate(new Vector3(0, 0, 0));

        LimiteSuperiorZ = 41f;
        LimiteInferiorZ = -150f;
        //Velocidad = 60f;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(new Vector3(0f, 0f, Velocidad) * Time.deltaTime);

        if (this.transform.position.z > LimiteSuperiorZ) { Velocidad = Velocidad * -1; ; }
        if (this.transform.position.z < LimiteInferiorZ) { Velocidad = Velocidad * -1; }


        random = Mathf.RoundToInt(Random.Range(1f, 100f));

        if (random==15f)
        {
            Velocidad = Velocidad * -1;
        }
    }
}
