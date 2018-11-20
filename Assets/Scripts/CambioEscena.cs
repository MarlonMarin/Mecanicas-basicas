using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CambioEscena : MonoBehaviour {

    //public GameObject llave;
    public bool abierto;
    public string NombreDEscena;
    private AssetBundle myLoadedAssetBundle;

    // Use this for initialization
    void Start () {
        abierto = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(abierto)
        {
            SceneManager.LoadScene(NombreDEscena);
        }
	}

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "candado")
        {
            abierto = true;
        }
    }
}
