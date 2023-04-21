using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sensor
{
    
    public class OndaRecto : MonoBehaviour
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



        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag != "ROVER" && collision.gameObject.tag != "ONDA")
            {
                GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().sensores[1] = Vector3.Distance(GameObject.Find("ROVER").GetComponent<MovimientoTopDown>().transform.position, transform.position);
                Destroy(this.gameObject);
            }
        }

    }

}