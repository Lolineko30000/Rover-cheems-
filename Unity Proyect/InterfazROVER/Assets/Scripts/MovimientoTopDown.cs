using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No pongo acentos en el texto a proposito 
public class MovimientoTopDown : MonoBehaviour
{
    //Estos valores pueden ser cambiados en Unity a consideración
    [SerializeField] private float velocidadMovimiento; 
    [SerializeField] private Vector2 direccion;

    private Rigidbody2D RoverDowneyJr; //Declaración de objeto (ROVER)

    /*
    Las funciones Start() y Update() funcionan muy parecido a SetUp() y loop() de Arduino
    solo que aqui Update() se ejecuta una vez por frame
    */

    void Start() 
    {
        RoverDowneyJr = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 5;
    }

    
    void Update()
    {
        //direccion = vector(x,y)
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; 
    }

    private void FixedUpdate() //Ni idea de que hace FixedUpdate, seguire investigando despues
    {
        //Esta parte del codigo es la que permite que el robot se mueva
        RoverDowneyJr.MovePosition(RoverDowneyJr.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
    

}
