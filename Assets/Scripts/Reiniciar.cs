using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour {
    public string escena;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(escena);
        }

    }

}

