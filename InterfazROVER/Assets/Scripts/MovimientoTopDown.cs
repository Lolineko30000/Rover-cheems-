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
    
    private float anguloGiro;

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

    //Recibe la entrada del teclado
    private void InputEntrada()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
    }

    //Permite el movimiento del robot a partir de la entrada del teclado
    private void MoverRobot()
    {
        if(inputVertical == 0)
            RoverDowneyJr.velocity = Vector2.zero;
        else if(inputVertical == 1)
            RoverDowneyJr.velocity = transform.up * velocidadMovimiento;
        else if(inputVertical == -1)
            RoverDowneyJr.velocity = -transform.up * velocidadMovimiento;
    }

    //Rota al robot dependiendo de la entrada recibida y devuelve un float que describe el angulo de giro del robot
    private float RotarRobot()
    {
        /*
        if(inputVertical == 0)
            return;*/

        if(inputHorizontal == 0)
            return -1f;

        float rotacion = -inputHorizontal * velocidadRotacion;
        transform.Rotate(Vector3.forward * rotacion);

        anguloGiro -= rotacion;
        if(anguloGiro > 360)
            anguloGiro -= 360;
        else if(anguloGiro < 0)
            anguloGiro = 360 - rotacion;

        return anguloGiro;
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


    void Sensores()
    {
        
    }
    
}
