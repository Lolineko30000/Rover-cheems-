using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sensor;

public class OndasRover : MonoBehaviour
{

    [SerializeField] private Transform controlOndaDerecha;
    [SerializeField] private Transform controlOndaIzquierda;
    [SerializeField] private Transform controlOndaDerecho;
    //Las tres ondas correspondientes a cada sensor

    [SerializeField] private GameObject ondaDerecha;
    [SerializeField] private GameObject ondaDerecho;
    [SerializeField] private GameObject ondaIzquierda;
    //Objeto del prefab con las caracteristicas de la onda

    private void Update()
    {
        //temporal
        if(Input.GetButtonDown("Fire1"))
        {
            LanzarOnda();       
        }
    }

    private void LanzarOnda()
    {
        Instantiate(ondaDerecho, controlOndaDerecho.position, controlOndaDerecho.rotation );
        Instantiate(ondaIzquierda, controlOndaIzquierda.position,controlOndaIzquierda.rotation );
        Instantiate(ondaDerecha, controlOndaDerecha.position,controlOndaDerecha.rotation );
    }
}
