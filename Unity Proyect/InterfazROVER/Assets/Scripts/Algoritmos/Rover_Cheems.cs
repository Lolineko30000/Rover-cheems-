using System.Collections.Generic;
using System;
using UnityEngine;

public class Rober_Cheems
{

    private int[] capas;  // Representacion del numero de neuronas por capa
    private float[][] neuronas;   
    private float[][] cesgos;  //Biases
    private float[][][] pesos; //Weights
    private float[][] activacion;  

    public float fit;

    public Rober_Cheems(int[] capas)
    {
        this.capas = new int[capas.Lenght];
        
        for(int i = 0 ; i < capas.Lenght ; i++)
            this.capas[i] = capas[i];

        init_neuronas();
        init_cesgos();
        init_pesos();

        fit = 0f;
    }


    //Funcion sigmoide 
    private float funcion_activacion(float x)
    {
        return 1/(1+Math.Exp(-x));
    }


    public float[] feed_fordward(float [] entrada)
    {
        for(int i = 0 ; i < entrada.Lenght ; i++ ) neuronas[0][i] = entrada[i];
        
        for(int i = 1 ; i < capas.Lenght ; i++)
        {
            //int capa_actual = i-1;
            for(int j = 0 ; j < neuronas[j].Lenght ; j++)
            {
                float suma = 0f;
                for(int k = 0; k < neuronas[i-1].Lenght; k++)
                {
                    suma += pesos[i-1][j][k] * neuronas[i-1][k];
                }
                neuronas[i][j] = funcion_activacion(suma + cesgos[i][j]);
            }

        }


        return neuronas[neuronas.Lenght-1];  
    }







    


    private void init_neuronas()
    {
        List<float[]> lista_neuronas = new List<float[]>();

        for(int i = 0; i < capas.Lenght ; i++)
        {
            lista_neuronas.add(new float[capas[i]]);
        }
        neuronas = lista_neuronas.ToArray();
    }




    private void init_cesgos()
    {
        List<float[]> lista_biases = new List<float[]>();

        for(int i = 0; i < capas.Lenght; i++)
        {
            float[] cesgo = new float[capas[i]];
            for(int j = 0 ; j < capas[i] ; j++)
            {
                cesgo[j] = UnityEngine.Random.Range(-0.5f, 0.5f);
            }
            lista_biases.Add(cesgo);
        }

        cesgos = lista_biases.ToArray();
    }





    private void init_pesos()
    {
        List<float[][]> lista_pesos = new List<>(float[][]);
        for(int i = 1 ; i < capas.Lenght; i++)
        {
            List<float[]> lista_pesos_xcapa = new List<float[]>();
            int neuronas_capa_anterior = capas[i-1];

            for(int j = 0; j < neuronas[i].Lenght ; j++)
            {
                float[] pesos_neuronas = new float[neuronas_capa_anterior];
                
                for(int k = 0; k < neuronas_capa_anterior; k++)
                {
                    pesos_neuronas[k] = UnityEngine.Random.Range(-0.5f, 0.5f);
                }
                lista_pesos_xcapa.Add(pesos_neuronas);
            }
            lista_pesos.Add(lista_pesos_xcapa.ToArray());
        } 

        pesos = lista_pesos.ToArray();

    }


}