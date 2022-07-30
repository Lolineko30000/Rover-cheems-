using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No pongo acentos en el texto a proposito 
public class MovimientoTopDown : MonoBehaviour
{
    //Estos valores pueden ser cambiados en Unity a consideración
    [SerializeField] private float velocidadMovimiento; 
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private Vector2 direccion;

    private Rigidbody2D RoverDowneyJr; //Declaración de objeto (ROVER)

    /*
    Las funciones Start() y Update() funcionan muy parecido a SetUp() y loop() de Arduino
    solo que aqui Update() se ejecuta una vez por frame
    */

    void Start() 
    {
        RoverDowneyJr = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Esta linea indica posicion, direccion = vector(x,y) ; 0 < x < 1 & 0 < y < 1
        //Justo esto es lo que necesitamos para cambiar los sprites
        float valX = Input.GetAxisRaw("Horizontal");
        float valY = Input.GetAxisRaw("Vertical");

        direccion = new Vector2(valX, valY); 
        float magnitudEntrada = Mathf.Clamp01(direccion.magnitude);
        direccion.Normalize();

        OrientacionRover(valX, valY);
    }

    private void FixedUpdate() //Esta función se ejecuta 50 veces por segundo
    {
        //Esta parte del codigo es la que permite que el robot se mueva
        RoverDowneyJr.MovePosition(RoverDowneyJr.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }

    /*
    private bool viendoArriba = true;
    private bool viendoIzquierda;
    private bool viendoDerecha;
    private bool viendoAbajo;
    //Debug.Log("a");
    */

    void OrientacionRover(float x, float y)
    {
        /*
        if(x > 0) //Va a la derecha

        else if(x < 0) //Va a la izquierda
        */

        //Declaracion de no se k
        if(direccion != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direccion);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);
        }
        

    }
    

}
