using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensor
{
    
    public class OndaIzquierda : MonoBehaviour
    {
        //Velocidad a la que se movera la onda.
        [SerializeField] private float velocidad = 5f;

        private void Update()
        {
            //Funcion para el movimiento de la onda
            transform.Translate(Vector2.right * Time.deltaTime * velocidad);
            //Las ondas unicamente deben durar un segundo.
            Destroy(this.gameObject,1);
            
        }    



        private void OnTriggerEnter2D()
        {
            GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[0] = Vector3.Distance(GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().transform.position, transform.position);
            Destroy(this.gameObject);
        }

    }

}