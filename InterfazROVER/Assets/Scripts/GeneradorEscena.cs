using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneradorEscena : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tile tileEscenario;
    [SerializeField] private Tile tileDecorativo1;
    [SerializeField] private Tile tileDecorativo2;
    [SerializeField] private int numeroDecoraciones;
    [SerializeField] private int ancho;
    [SerializeField] private int largo;
    //private int offsetScene = 5;

    private int[,] matrizEscenario;

    void GenerarMatrizEscenario()
    {
        this.matrizEscenario = new int[this.ancho, this.largo];

        for(int i = 0; i < this.ancho; i++)
            for(int j = 0; j < this.largo; j++)
                this.matrizEscenario[i, j] = 1;
    }

    void GenerarEscenario()
    {
        for(int i = 0; i < this.ancho; i++)
            for(int j = 0; j < this.largo; j++)
                if(this.matrizEscenario[i,j] == 1)
                    this.tilemap.SetTile(new Vector3Int(i, j, 0), this.tileEscenario);
    }

    void GenerarDecoracion()
    {
        for(int i = 0; i < numeroDecoraciones; i++)
        {
            int x = UnityEngine.Random.Range(1, ancho - 1);    
            int y = UnityEngine.Random.Range(1, largo - 1);
            int z = UnityEngine.Random.Range(1, 10);

            if(z < 5)
                this.tilemap.SetTile(new Vector3Int(x, y, 0), this.tileDecorativo1);
            else
                this.tilemap.SetTile(new Vector3Int(x, y, 0), this.tileDecorativo2);
        }
    }

    void Start()
    {   
        this.GenerarMatrizEscenario();
        this.GenerarEscenario();
        this.GenerarDecoracion();
    }

}
