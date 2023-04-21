using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Laberinto;

public class MovimientoTopDown : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento; 
    [SerializeField] private float velocidadRotacion;
    private float inputHorizontal, inputVertical;
    private Rigidbody2D RoverDowneyJr;
    

    public bool control;
    public int index;
    //Orden de los nodos ue ebe ir recorriendo
    public List<int> camino;
    //Cordenadas de los nodos
    public List<Transform> nodos;

    //Arreglo donde se guarda el resultado de la colision de los sensores.
    public float[] sensores;
    

    void Start() 
    {
        RoverDowneyJr = GetComponent<Rigidbody2D>();
        sensores = new float[3] {0f,0f,0f};

        //Lineas especiales para obtener el camino del script del grafo.
        if(!control)
        {
            //Importamos los datos de otro script de grafo 
            GameObject aux = GameObject.Find("Grafo");
            Grafo grafo = aux.GetComponent <Grafo> ();
            camino = grafo.camino;
            nodos = grafo.nodos;
            //control = true;
            index = 0;
        }

        
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
        if(control)

            InputEntrada();
        else
        {
            if(index == 0)
            {
                transform.Rotate(Vector3.forward * -4f);
            }
            if(index != camino.Count)
            {
                Distancia();
                transform.position = Vector3.MoveTowards(transform.position, nodos[camino[index]].position, Time.deltaTime * 4f);
                
                Vector3 NodoSiguiente = nodos[camino[index]].position - transform.position;
                float angulo =  Mathf.Atan2(NodoSiguiente.y,NodoSiguiente.x)*Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angulo-90f, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 2.5f);
            }
        }

        Debug.Log(sensores[0] + " " + sensores[1] + " " + sensores[2] );

    }

    void FixedUpdate()
    {
        
        if(control)
        {   //Solamente si e desea mover el rover manualmente
            MoverRobot();
            RotarRobot();
        }
        
        
        
    }

    void Distancia()
    {
        //Debug.Log(nodos[camino[index]].position);
        if(!control && Vector3.Distance(transform.position, nodos[camino[index]].position) < 0.5 && index != camino.Count-1)
        {
            index++;
        }
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
