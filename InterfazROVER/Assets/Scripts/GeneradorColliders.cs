using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorColliders : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  
    [SerializeField] private Tile tileBarrera;
    public int anchoMapa;
    public int largoMapa;

    private int[,] matrizColliders;

    void Start()
    {
        this.GenerarMatrizColliders();
        this.GenerarColliders();
    }

    void GenerarMatrizColliders() //Genera Matriz para las barreras
    {
        this.matrizColliders = new int[this.anchoMapa, this.largoMapa];

        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                if((i == 0) && (j > this.largoMapa/2 - 1  &&  j < this.largoMapa/2 + 3))
                    this.matrizColliders[i,j] = 0;
                    //Entrada
                else if((i == this.anchoMapa - 1) && (j > this.largoMapa/2 - 1  &&  j < this.largoMapa/2 + 3))
                    this.matrizColliders[i,j] = 0;
                    //Salida
                else if(i == 0 || i == this.anchoMapa - 1)
                    this.matrizColliders[i,j] = 1;    
                else if(j == 0 || j == this.largoMapa - 1)
                    this.matrizColliders[i,j] = 1;

        GenerarLaberinto();
    }   
    
    //Grid de tamanio 
    // anchomapa = 31
    // largomapa = 23

    //Genera laberinto para algoritmo Dijkestra (Tomado del reto de los electricos)
    void GenerarLaberinto()
    {

        for(int j = 0; j < this.largoMapa; j++)
        {
            if( (j >= 8 && j <= 10) || (j >= 14 && j <= 16) )
                this.matrizColliders[3,j] = 1;
            if( (j >= 4 && j <= 7) || (j >= 17 && j <= 20) )
                this.matrizColliders[6,j] = 1;
            if( (j >= 3 && j <= 7) || (j >= 18 && j <= 21) )
                this.matrizColliders[6,j] = 1;
            if( (j >= 0 && j <= 7) || (j >= 14 && j <= 17) )
                this.matrizColliders[9,j] = 1;
            if( (j >= 0 && j <= 13))
                this.matrizColliders[12,j] = 1;
            if( (j >= 22 && j <= 24))
                this.matrizColliders[16,j] = 1;
            if( (j >= 1 && j <= 4) || (j >= 8 && j <= 11) )
            { 
                this.matrizColliders[17,j] = 1;
                this.matrizColliders[21,j] = 1;
            }
            if( (j >= 4 && j <= 9) || (j >= 14 && j <= 21) )
                this.matrizColliders[27,j] = 1;
            
            if( (j >= 18 && j <= 21) )
                this.matrizColliders[14,j] = 1;
            if( (j >= 15 && j <= 18) )
                this.matrizColliders[17,j] = 1;
            if( (j >= 8 && j <= 14) )
                this.matrizColliders[24,j] = 1;
        }

        for(int i = 0; i < this.anchoMapa; i++)
        {
            if( (i >= 0 && i <= 3)){
                this.matrizColliders[i,14] = 1;
                this.matrizColliders[i,10] = 1;
            }
            if( (i >= 3 && i <= 6)){
                this.matrizColliders[i,17] = 1;
                this.matrizColliders[i,7] = 1;
            }
            if( (i >= 0 && i <= 6))
                this.matrizColliders[i,3] = 1;

            if( (i >= 6 && i <= 11))
            { 
                this.matrizColliders[i,10] = 1;
                this.matrizColliders[i,13] = 1;
            }
            
            if(i == 13 || i == 14)
                this.matrizColliders[i,13] = 1;

            if( (i >= 12 && i <= 16))
            {
                this.matrizColliders[i,4] = 1;
                this.matrizColliders[i,8] = 1;
            }
            
            if( (i >= 17 && i <= 24))
                this.matrizColliders[i,15] = 1;
            if( (i >= 15 && i <= 24))
                this.matrizColliders[i,18] = 1;

            if( (i >= 21 && i <= 24))
                this.matrizColliders[i,8] = 1;
            if( (i >= 21 && i <= 26))
                this.matrizColliders[i,4] = 1;
            
            if( (i >= 27 && i <= 29))
            {
                this.matrizColliders[i,10] = 1;
                this.matrizColliders[i,14] = 1;
            }

            if( (i == 9 || i == 10 || i == 11))
            {
                this.matrizColliders[i,17] = 1;
                this.matrizColliders[i,18] = 1;
            }            
        }

    }

    void GenerarColliders() //Barreras
    {
        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                if(this.matrizColliders[i,j] == 1)
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tileBarrera);
    }               
}

/*
Créditos a: 
https://www.youtube.com/watch?v=kTbEGIfFeyI
https://www.youtube.com/watch?v=eDOxDJEtE14 
*/