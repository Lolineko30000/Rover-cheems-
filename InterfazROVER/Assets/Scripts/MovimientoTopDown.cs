using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento; 
    [SerializeField] private float velocidadRotacion;
 
    private float inputHorizontal, inputVertical;
    private Rigidbody2D RoverDowneyJr;

    void Start() 
    {
        RoverDowneyJr = GetComponent<Rigidbody2D>();
    }

    private void InputEntrada()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    private void MoverRobot()
    {
        if(inputVertical == 0)
            RoverDowneyJr.velocity = Vector2.zero;
        else if(inputVertical == 1)
            RoverDowneyJr.velocity = transform.up * velocidadMovimiento;
        else if(inputVertical == -1)
            RoverDowneyJr.velocity = -transform.up * velocidadMovimiento;
    }

    private void RotarRobot()
    {
        //if(inputVertical == 0)
        //    return;

        float rotacion = -inputHorizontal * velocidadRotacion;
            transform.Rotate(Vector3.forward * rotacion);
    }

    void Update()
    {
        InputEntrada();
    }

    void FixedUpdate()
    {
        MoverRobot();
        RotarRobot();
    }























    
    
    
    /*
    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");
        //Esta linea indica posicion, direccionMovimiento = vector(x,y) ; 0 < x < 1 & 0 < y < 1
        direccionMovimiento = new Vector2(inputHorizontal, inputVertical);
        float magnitudEntrada = Mathf.Clamp01(direccionMovimiento.magnitude);
        direccionMovimiento.Normalize();

        transform.Translate(direccionMovimiento * velocidadMovimiento * magnitudEntrada * Time.deltaTime, Space.World);

        /*
        if(direccionMovimiento != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, direccionMovimiento);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotacion * Time.deltaTime);
        }
        //
    }

    /*
    private void FixedUpdate() //Esta función se ejecuta 50 veces por segundo
    {
        //Esta parte del codigo es la que permite que el robot se mueva
        RoverDowneyJr.MovePosition(RoverDowneyJr.position + direccionMovimiento * velocidadMovimiento * Time.fixedDeltaTime);
    }
    //*/
}
