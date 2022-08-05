using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndasRover : MonoBehaviour
{
    [SerializeField] private Transform controlOndaDerecha;
    [SerializeField] private Transform controlOndaIzquierda;
    [SerializeField] private Transform controlOndaDerecho;
    [SerializeField] private GameObject onda;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            LanzarOnda();
        }
    }

    private void LanzarOnda()
    {
        Instantiate(onda, controlOndaDerecho.position, controlOndaDerecho.rotation );
        Instantiate(onda, controlOndaIzquierda.position,controlOndaIzquierda.rotation );
        Instantiate(onda, controlOndaDerecha.position,controlOndaDerecha.rotation );
    }
}
