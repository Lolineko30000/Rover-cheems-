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

    public double[,] grid;
    public double[,] nodes;

    /*
    Las funciones Start() y Update() funcionan muy parecido a SetUp() y loop() de Arduino
    solo que aqui Update() se ejecuta una vez por frame
    */

    void Start() 
    {
        RoverDowneyJr = GetComponent<Rigidbody2D>();
        velocidadMovimiento = 5;

        /*

        int posicion_x = 
        int posicion_y =
        int n =         //Alto
        int m =         //Ancho

        grid = new double[n*m,n*m];
        nodes = new double[n*m,2];

        for(int i = 0, i < n; i++)
            for(int j = 0, j < m; j++)
                nodes[i+j] = {posicion_x + j , posicion_y + i};  
        
        for(int i = 0, i < n; i++)
        { 
            for(int j = 1, j < m; j++)
            { 
                if(i == j)
                { 
                    grid[i,j] = 0;
                }else
                {
                    grid[j-1+n*i,j+n*i] = 1;
                    grid[j+n*i,j-1+n*i] = 1;
                    
                    if(n < n-1)
                    {
                        grid[j+n*i, j+n+n*i] = 1;
                        grid[j+n+n*i,j+n*i] = 1;
                    }
                }
            }
        }*/

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
