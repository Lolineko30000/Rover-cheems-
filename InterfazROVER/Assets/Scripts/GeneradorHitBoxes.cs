using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorHitBoxes : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;  
    [SerializeField] private Tile tileBarrera;
    [SerializeField] private int numeroObstaculos;  
    [SerializeField] private int anchoMapa; 
    [SerializeField] private int largoMapa;

    private int[,] matrizColliders;

    void Start()
    {
        this.matrizColliders = new int[this.anchoMapa, this.largoMapa]; 

        this.GenerarMatrizColliders();
        this.GenerarObstaculos();
    }

    //Genera las barreras limite del mapa
    void GenerarMatrizColliders() 
    {
        for(int i = 0; i < this.anchoMapa; i++)
            for(int j = 0; j < this.largoMapa; j++)
                if(i == 0 || i == this.anchoMapa - 1)
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tileBarrera);  
                else if(j == 0 || j == this.largoMapa - 1)
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tileBarrera);
    }

    //Genera obstaculos aleatoriamente
    void GenerarObstaculos()
    {
        for(int i = 0; i < numeroObstaculos; i++)
        {
            int x = UnityEngine.Random.Range(1, anchoMapa - 1);    
            int y = UnityEngine.Random.Range(1, largoMapa - 1);

            this.tilemap.SetTile(new Vector3Int(x, y, 0), this.tileBarrera);
        }
    }            
}

/*
Creditos a: 
https://www.youtube.com/watch?v=kTbEGIfFeyI
https://www.youtube.com/watch?v=eDOxDJEtE14 
*/