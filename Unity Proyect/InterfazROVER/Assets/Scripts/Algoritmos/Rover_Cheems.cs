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

    public Rober_Cheems(int[] capas, float fit)
    {
        this.capas = new int[capas.Length];
        
        for(int i = 0 ; i < capas.Length ; i++)
            this.capas[i] = capas[i];

        init_neuronas();
        init_cesgos();
        init_pesos();

        this.fit = fit;
    }


    //Funcion sigmoide 
    private float funcion_activacion(float x)
    {
        return (float)(1/(1+Math.Exp(-x)));
    }

    //Funcion de salida de la red
    public float[] feed_fordward(float [] entrada)
    {
        for(int i = 0 ; i < entrada.Length ; i++ ) neuronas[0][i] = entrada[i];
        
        for(int i = 1 ; i < capas.Length ; i++)
        {
            //int capa_actual = i-1;
            for(int j = 0 ; j < neuronas[j].Length ; j++)
            {
                float suma = 0f;
                for(int k = 0; k < neuronas[i-1].Length; k++)
                {
                    suma += pesos[i-1][j][k] * neuronas[i-1][k];
                }
                neuronas[i][j] = funcion_activacion(suma + cesgos[i][j]);
            }

        }


        return soft_max(neuronas[neuronas.Length-1]);  
    }

    //Funcion para representar la salida en forma de probabilidades
    public float[] soft_max(float[] salida)
    {
        float[] probabilidades = new float[salida.Length];
        float suma = 0f;
        for(int i = 0; i < salida.Length ; i++)
            suma += (float)Math.Exp(salida[i]);
    
        for(int i = 0 ; i < salida.Length; i++)
            probabilidades[i] = (float)Math.Exp(salida[i])/suma;

        return probabilidades;
    }

    //Funcion de aprendizaje 
    public void decenso_xgradiente(float[] entrada,float[] salida_deseada, int iteraciones,float convergencia)
    {

        float costo_previo = 0;
        float costo_actual = 0;
        float derivada_pesos = 0;
        float derivada_cesgos = 0;

        for(int i = 0; i < iteraciones ; i++)
        {
            float[] salida_dada = feed_fordward(entrada);
            costo_actual = funcion_costo(salida_deseada, salida_dada);

            if(costo_previo > 0 && abs(costo_previo- costo_actual) <= convergencia)
            {
                break;
            }

            costo_actual = costo_previo;
            derivada_pesos = calcular_derivada_pesos(entradas.Length, entrada, salida_dada, salida_deseada);
            derivada_cesgos = calcular_derivada_cesgos(entradas.Length, salida_dada, salida_deseada);

            actualizar_pesos(derivada_pesos);
            actualizar_cesgos(derivada_cesgos);

        }
    }

    private float calcular_derivada_pesos(int n, float[] entradas, float[] salida_dada, float[] salida_deseada)
    {
        float suma = 0;
        for(int i = 0 ; i < salida_dada.Length; i++)
        {

        }   

        return (-2/n)*suma;
    }

    private float calcular_derivada_cesgos(int n, float[] salida_dada, float[] salida_deseada)
    {
        float suma = 0;
        for(int i = 0 ; i < salida_dada.Length; i++)
        {
            suma += salida_deseada[i] - salida_dada[i];
        }

        return (-2/n)*suma;
    }


    private void actualizar_pesos(float derivada)
    {
        for(int i = 0 ; i < pesos.Length ; i++)
            for(int j = 0 ; j < pesos[i].Length ; j++)
                for(int k = 0 ; k < pesos[i][j].Length ; k++)
                    pesos[i][j][k] -= fit*derivada; 
    }

    private void actualizar_cesgos(float derivada)
    {
        for(int i = 0 ; i < cesgos.Length ; i++)
            for(int j = 0 ; j < cesgos[i].Length ; j++)
                cesgos[i][j] -= fit*derivada; 
    }       

    private float funcion_perdida(float probabilidad)
    {
        return -((float)Math.Log(probabilidad));
    }

    private float funcion_costo(float[] probabilidades)
    {
        float denominador = 0;
        float perdida = 0;
        int m = probabilidades.Length;

        for(int i = 0; i < m ; i++)
            denominador += Math.Exp(probabilidades[i]);

        for(int i = 0; i < m ; i++)
            perdida += funcion_perdida(probabilidades[i]/denominador);
   
        return (1/m)*perdida;
    }

    /*
    private float funcion_costo(float[] salida, float[] salida_deseada)
    {
        float suma = 0;
        
        for(int i = 0; i < salida.Length; i++)
        {
            suma += (salida[i]-salida_deseada[i])*(salida[i]-salida_deseada[i]);
        }

        return ((float)Math.Sqrt(suma))/salida.Length;
    }
    */

    private float abs(float x)
    {
        if(x < 0) return -x;
        return x;
    }

    //Funciones auxiliares para la instancia de la red
    //===================================================

    private void init_neuronas()
    {
        List<float[]> lista_neuronas = new List<float[]>();

        for(int i = 0; i < capas.Length ; i++)
        {
            lista_neuronas.Add(new float[capas[i]]);
        }
        neuronas = lista_neuronas.ToArray();
    }




    private void init_cesgos()
    {
        List<float[]> lista_biases = new List<float[]>();

        for(int i = 0; i < capas.Length; i++)
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
        List<float[][]> lista_pesos = new List<float[][]>();
        for(int i = 1 ; i < capas.Length; i++)
        {
            List<float[]> lista_pesos_xcapa = new List<float[]>();
            int neuronas_capa_anterior = capas[i-1];

            for(int j = 0; j < neuronas[i].Length ; j++)
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