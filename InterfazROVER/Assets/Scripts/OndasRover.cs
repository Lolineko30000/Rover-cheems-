using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensor;

public class OndasRover : MonoBehaviour
{
    //Las tres ondas correspondientes a cada sensor
    [SerializeField] private Transform controlOndaDerecha;
    [SerializeField] private Transform controlOndaIzquierda;
    [SerializeField] private Transform controlOndaDerecho;
    
    //Objeto del prefab con las caracteristicas de la onda
    [SerializeField] private GameObject ondaDerecha;
    [SerializeField] private GameObject ondaDerecho;
    [SerializeField] private GameObject ondaIzquierda;

    private void Update()
    {
        //Temporal
        if(Input.GetButtonDown("Fire1"))
        {
            LanzarOnda();       
        }
    }

    private void LanzarOnda()
    {
        Instantiate(ondaDerecho, controlOndaDerecho.position, controlOndaDerecho.rotation);
        Instantiate(ondaIzquierda, controlOndaIzquierda.position,controlOndaIzquierda.rotation);
        Instantiate(ondaDerecha, controlOndaDerecha.position,controlOndaDerecha.rotation);
    }
}
