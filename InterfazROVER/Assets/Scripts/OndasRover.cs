using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndasRover : MonoBehaviour
{

    private GameObject ondaDerecha;
    private GameObject ondaIzquierda;
    private GameObject ondaDerecho;

    [SerializeField] private Transform controlOndaDerecha;
    [SerializeField] private Transform controlOndaIzquierda;
    [SerializeField] private Transform controlOndaDerecho;
    //Las tres ondas correspondientes a cada sensor

    [SerializeField] private GameObject onda;
    //Objeto del prefab con las caracteristicas de la onda

    private void Update()
    {
        //temporal
        //if(Input.GetButtonDown("Fire1"))
        //{
             StartCoroutine(LanzarOnda());
        //}
    }

    private IEnumerator LanzarOnda()
    {
        ondaDerecho = Instantiate(onda, controlOndaDerecho.position, controlOndaDerecho.rotation );
        ondaDerecha = Instantiate(onda, controlOndaIzquierda.position,controlOndaIzquierda.rotation );
        ondaIzquierda =Instantiate(onda, controlOndaDerecha.position,controlOndaDerecha.rotation );

        yield return new WaitForSeconds(3);

        float derecho = Vector3.Distance(ondaDerecho.transform.position, transform.position);
        float derecha = Vector3.Distance(ondaDerecha.transform.position, transform.position);
        float izquierdo = Vector3.Distance(ondaIzquierda.transform.position, transform.position);

        Debug.Log("Derecho= " + derecho);
        Debug.Log("Derecha= " + derecha);
        Debug.Log("Izquierda= " + izquierdo);

    }
}
