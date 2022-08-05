using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onda : MonoBehaviour
{

    [SerializeField] private float velocidad;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * velocidad);
    }    

    private void OnTriggerEnter2D()
    {
        
    }

}
