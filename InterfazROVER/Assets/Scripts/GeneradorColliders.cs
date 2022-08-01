using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorColliders : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  
    [SerializeField] private Tile tileBarrera;
    //[SerializeField] private Tile tileObstaculo;   
    public int anchoMapa;
    public int largoMapa;

    private int[,] matrizColliders;

    void Start()
    {
        this.GenerarMatrizColliders();
        this.GenerarColliders();
    }

    void GenerarMatrizColliders() //Barreras
    {
        this.matrizColliders = new int[this.anchoMapa, this.largoMapa];

        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                if(i == 0 || i == this.anchoMapa - 1)
                    this.matrizColliders[i,j] = 1;    
                else if(j == 0 || j == this.largoMapa - 1)
                    this.matrizColliders[i,j] = 1;
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