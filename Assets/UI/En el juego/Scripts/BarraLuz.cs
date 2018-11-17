using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarraLuz : MonoBehaviour
{

    public Scrollbar barra;
    public float luz = 100f;
    public bool estado = true;
    public float valorGana=10f;
    public float valorPierde = 3f;

    void Update()
    {
        if (estado)
        {
            if (luz >= 100f)
            {
                luz = 100f;
            }
            else
            {
                luz += valorGana * Time.deltaTime;
            }
            barra.value = luz / 100f;
        }
        else
        {
            if (luz <= 0)
            {
                luz = 0;
            }
            else
            {
                luz -= valorPierde * Time.deltaTime;
            }
            barra.value = luz / 100f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="enLuz")
        {
            estado = true;
        }
        else if(other.tag == "enSombra")
        {
            estado = false;
        }
    }
}