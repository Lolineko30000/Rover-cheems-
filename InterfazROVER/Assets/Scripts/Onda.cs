/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensor
{
    
    public class Onda : MonoBehaviour
    {
        //Velocidad a la que se movera la onda.
        [SerializeField] private float velocidad;

        private void Update()
        {
            //Funcion para el movimiento de la onda
            transform.Translate(Vector2.right * Time.deltaTime * velocidad);
            //Las ondas unicamente deben durar un segundo.
            Destroy(this.gameObject,1);
            
        }    



        private void OnTriggerEnter2D()
        {
            GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[0] = 1;
            Debug.Log(GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[0]);
            Debug.Log(GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[1]);
            Debug.Log(GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[1]);
            Destroy(this.gameObject);
        }

    }

}
*/