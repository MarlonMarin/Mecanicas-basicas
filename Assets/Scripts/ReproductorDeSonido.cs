using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorDeSonido : MonoBehaviour {
    Vector3 offset;
    Transform objetivo;
    AudioSource aSource;
    bool rep = false;
    public AudioClip audio1, audio2, audio3;  //audios que atormentarán al niño

    // Use this for initialization
    void Start () {
        //player
        objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        //audio
        aSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        offset = objetivo.transform.position - transform.position;
        Debug.Log(offset);

        if (offset.x <= 20)
        {
            if (!rep) {
                string s = "audio";
                s = "audio" + Random.Range(1, 3);
                if (s == "audio1") { aSource.clip = audio1; }
                else if (s == "audio2") { aSource.clip = audio2; }
                else if (s == "audio3") { aSource.clip = audio3; }
            }
            

            if (!rep)
            {
                
                aSource.Play();
                rep = true;
            }
            
        }
    }
}
