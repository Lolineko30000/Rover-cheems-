using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorObstaculos : MonoBehaviour
{
    public Tile tile;
    public Tilemap tilemap; //Aquí va a ir el tilemap de los obstaculos (Pixel art)
    
    //Definir tamaño del mapa
    public int anchoMapa;
    public int largoMapa;

    //Esta línea es el mapa de datos (Matriz de dos dimensiones)
    private int[,] matrizMapa;
    //Estos datos son una matriz de unos y ceros (0 no hay tile y 1 sí hay tile

    void Start()
    {
        //Configura todo el mapa con tiles
        this.matrizMapa = new int[this.anchoMapa, this.largoMapa];
        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++) 
                this.matrizMapa[i,j] = 1; 
                //Sería interesante generarlo de forma aleatoria con algún algorítmo de probabilidad o algo así
        this.generarBarreras();
        //this.generarObstaculo();
    }

    void generarBarreras()
    {
        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tile);

    }




    void generarObstaculo()
    {
        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                if(this.matrizMapa[i,j] == 1)
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tile);
    }               
}
/*
Créditos a: 
https://www.youtube.com/watch?v=kTbEGIfFeyI
https://www.youtube.com/watch?v=eDOxDJEtE14 */