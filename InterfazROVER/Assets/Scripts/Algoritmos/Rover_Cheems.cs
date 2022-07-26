using System.Collections.Generic;
using System;
using UnityEngine;

public class Rober_Cheems
{

    private int[] capas;  // Representacion del numero de neuronas por capa
    private float[][] neuronas;  //Matriz done se uardaran os calculospara lafuncion Feed fordwar
    private float[][] cesgos;  //Biases
    private float[][][] pesos; //Weights

    public float fit; //Taza de aprenizaje para el aloritmo d desenso por gradiente


    /*
        Constructor
        Argumentos:
            capas: arreglo de enteros, con el numero de neuronas correspondientes a cada capa
            fit: taza de aprendizaje oara el algoritmo de entrenamiento

    */
    public Rober_Cheems(int[] capas, float fit)
    {
        this.capas = new int[capas.Length];
        
        for(int i = 0 ; i < capas.Length ; i++)
            this.capas[i] = capas[i];

        init_neuronas();    //Funciones auxilliares para la inicializacion del los arreglos
        init_cesgos();
        init_pesos();

        this.fit = fit;
    }


    //Funcion RELU 
    private float funcion_activacion(float x)
    {
        if(x <= 0 ) return 0;
        return x;
    }

    //Funcion de salida de la red
    /*
    Argumentos:
        entrada: Arreglo de flotantes con la misma dimension a la primera capa de la red
    */

    public float[] feed_fordward(float [] entrada)
    {
        for(int i = 0 ; i < entrada.Length ; i++ ) neuronas[0][i] = entrada[i];
        
        for(int i = 1 ; i < capas.Length ; i++)
        {
            for(int j = 0 ; j < neuronas[j].Length ; j++)
            {
                float suma = 0f;
                for(int k = 0; k < neuronas[i-1].Length; k++)
                {
                    suma += pesos[i-1][j][k] * neuronas[i-1][k]; // Producto punto
                }
                neuronas[i][j] = funcion_activacion(suma + cesgos[i][j]); // Funcion e activacion para cada capa
            }

        }

        neuronas[neuronas.Length-1] = soft_max(neuronas[neuronas.Length-1]);//Solo a la ultima capa se le aplica la funcion softmax

        return neuronas[neuronas.Length-1];  //Salida correspondiente a la dimension de la ultima capa de la red.
    }

    //Funcion para representar la salida en forma de probabilidades
    /*
    Argumentos:
        salida: Arreglo en la ultima caoa de la red
    */
    public float[] soft_max(float[] salida)
    {
        float[] probabilidades = new float[salida.Length];
        float suma = 0f;
        for(int i = 0; i < salida.Length ; i++) //Suma de cada entrada
            suma += (float)Math.Exp(salida[i]);
    
        for(int i = 0 ; i < salida.Length; i++)
            probabilidades[i] = (float)Math.Exp(salida[i])/suma;

        return probabilidades;
    }

    //Funcion de entrenamiento
    /*
        Argumentos:
        probablilidades: Salida de la red contra un caso especifico
        entradas: Entradas dadas para ese ejemplo especifico
        salida_correcta: Arreglo en forma de one_hot vector de la misma dimension de la salida
                ejemplo -> [0,0,1] si la dimension de la salida fuera de 3 y la salida correcta fuera 2 (iniciuando el indice desde 0)
    */
    public void decenso_xgradiente(float[] probabilidades, float[] entradas, float[] salida_correcta)
    {

        /*
            Para la ultima capa se realiza primero la resta de y_hat y y 
            para calcular la derivada y asi realizar la retropropagacion
        */
        float[][] derivada_z = new float[1][];
        derivada_z[0] = new float[probabilidades.Length];
        for(int i = 0; i < probabilidades.Length; i++)
            derivada_z[0][i] = probabilidades[i] - salida_correcta[i];

        int dimension_a = neuronas[neuronas.Length-1].Length;
        float[][] vector_transpuesto_a = new float[dimension_a][];
        for(int i = 0; i < dimension_a; i++)
        {
            vector_transpuesto_a[i] = new float[1];
            vector_transpuesto_a[i][0] = neuronas[neuronas.Length-1][i];
        }
        
        
        float[][] derivada_w = multiplicacion_matrices(vector_transpuesto_a, derivada_z);
        
        //Actualizacion de los pesos y de los cesgos de la ultima capa
        actualizar_pesos(derivada_w, pesos.Length-1);
        actualizar_cesgos(derivada_z, cesgos.Length-1);
        


        /*
            Inicio de la retropropagacion 
            ya calculada las derivadas, se raliza un proceso iteratvo para todas las capas,
            esto para poder calcular las derivadas y con ello el gradiente.
        */
        for(int i = pesos.Length-1; i >= 1  ; i-- )
        {
            Console.WriteLine(i);
            
            float[][] derivada_a = multiplicacion_matrices(pesos[i], transpuesta(derivada_z));
            derivada_z = transpuesta(derivada_a);
            
            
            //Retropropagacion para la funcion RELU
            for(int j = 0; j < derivada_a[0].Length; j++)
            {
                if(derivada_a[0][j] >= 0) 
                {
                    derivada_z[0][j] = derivada_a[0][j];
                }
                else
                {
                    derivada_z[0][j] = 0;
                }
            }

            float[][] neuronas_temporales = new float[1][];
            neuronas_temporales[0] = neuronas[i-1];

            derivada_w = multiplicacion_matrices(transpuesta(derivada_z), neuronas_temporales);
            
            //Actualizacion de las capas desde la ultima a la primera.
            actualizar_pesos(derivada_w, i);
            actualizar_cesgos(derivada_z, i);
        }

    }



    //Funcion logaritmica recomendada para el aprendizaje de la red
    private float funcion_perdida(float probabilidad)
    {
        return -((float)Math.Log(probabilidad));
    }

    //Funcion auxiliar para el algoritmo de entrenamiento
    private void actualizar_pesos(float[][] dw , int capa)
    {
        pesos[capa] = resta_matrices(pesos[capa], multiplicacion_escalar_matriz(dw,fit));
    }

    //Funcion auxiliar para el algoritmo de entrenamiento
    private void actualizar_cesgos(float[][] db , int capa)
    {
        
        float[] dbxalpha = new float[db[0].Length];
        for(int i = 0; i < db.Length ; i++)
            dbxalpha[i] = db[i][0];
        
        dbxalpha = multiplicacion_escalar_vector(dbxalpha, fit);
        
        for(int i = 0; i < db.Length ; i++)
        {
            cesgos[capa][i] -= dbxalpha[i];
        }
    }

    //Funcion que retorna la transpuesta de una matriz o vector, necesaria para el algoritmo de entrenamiento
    private float[][] transpuesta(float[][] matriz)
    {
        int c1 = matriz.Length;
        int f1 = matriz[0].Length;
        float[][] resultado = new float[f1][];
        for(int i =0 ; i < f1 ; i++)
        {
            resultado[i] = new float[c1];
        }

        for(int i =0 ; i < f1 ; i++)
            for(int j =0 ; j < c1 ; j++)
                resultado[i][j] = matriz[j][i];

        return resultado;
    }

    //Multiplicacion escalar estandard 
    private float[][] multiplicacion_escalar_matriz(float[][] a, float alpha)
    {
        int f1 = a.Length;
        int c1 = a[0].Length;
        float[][] resultado = new float[f1][];
        for(int i =0 ; i < f1 ; i++)
        {
            resultado[i] = new float[c1];
        }

        for(int i =0 ; i < f1 ; i++)
            for(int j =0 ; j < c1 ; j++)
                resultado[i][j] = alpha*a[i][j];

        return resultado;
    }

    //Multiplicacion escalar estandard 
    private float[] multiplicacion_escalar_vector(float[] a, float alpha)
    {
        float[] resultado = new float[a.Length];
        for(int i =0 ; i < a.Length ; i++)
            resultado[i] = alpha*a[i];
        return resultado;
    }

    //Resta de matrices estandard
    //Ambas matrices deben tener el mismo tamanio. 
    private float[][] resta_matrices(float[][] a, float[][] b)
    {
        int f1 = a.Length;
        int c1 = a[0].Length;
        float[][] resultado = new float[f1][];
        for(int i =0 ; i < f1 ; i++)
        {
            resultado[i] = new float[c1];
        }

        for(int i =0 ; i < f1 ; i++)
            for(int j =0 ; j < c1 ; j++)
                resultado[i][j] = a[i][j] - b[i][j];

        return resultado;
    }

    //Multiplicacion de matrices estandar, necesario para el aloritmo de entrenamiento
    private float[][] multiplicacion_matrices(float[][] a, float[][] b)
    {
        int f1 = a.Length;
        int c1 = a[0].Length;
        int f2 = b.Length;
        int c2 = b[0].Length;
        float suma_temporal = 0;
        
            

        float[][] resultado = new float[f1][];
        for(int i =0 ; i < f1 ; i++)
        {
            resultado[i] = new float[c2];
        }

        for(int i =0 ; i < f1 ; i++)
        {
            for(int j =0 ; j < c2 ; j++)
            {
                suma_temporal = 0;
                for(int k =0 ; k < c1 ; k++)
                {
                    suma_temporal += a[i][k] * b[k][j];
                }
                resultado[i][j] = suma_temporal;
            }
        }

        return resultado;
    }


    //Funcion de costo, implementada paraobservar el prograso de la red
    private float funcion_costo(float[] probabilidades, int  numero_muestras)
    {
        float denominador = 0;
        float perdida = 0;
        int m = numero_muestras;

        for(int i = 0; i < m ; i++)
            denominador += (float)Math.Exp(probabilidades[i]);

        for(int i = 0; i < m ; i++)
            perdida += funcion_perdida(probabilidades[i]/denominador);
   
        return (1/m)*perdida;
    }



    /*
    private float abs(float x)
    {
        if(x < 0) return -x;
        return x;
    }
    */

    //Funciones auxiliares para la instancia de la red
    //===================================================

    //Funcin para iniciar la matriz de neuronas
    private void init_neuronas()
    {
        List<float[]> lista_neuronas = new List<float[]>();

        for(int i = 0; i < capas.Length ; i++)
        {
            lista_neuronas.Add(new float[capas[i]]);
        }
        neuronas = lista_neuronas.ToArray();
    }



    //Funcion para iniciar la matriz de cesgos 
    //Se inicial aleatoreamente con ayuda de funciones del Unity
    private void init_cesgos()
    {
        List<float[]> lista_biases = new List<float[]>();

        for(int i = 0; i < capas.Length; i++)
        {
            float[] cesgo = new float[capas[i]];
            for(int j = 0 ; j < capas[i] ; j++)
            {
                cesgo[j] = UnityEngine.Random.Range(-0.5f, 0.5f);
                //cesgo[j] = 0.5f;
            }
            lista_biases.Add(cesgo);
        }

        cesgos = lista_biases.ToArray();
    }


    //Funcion oara iniciar la matriz de pesos
    //Se inicial aleatoreamente con ayuda de funciones del Unity
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
                    //pesos_neuronas[k] = 0.5f;
                }
                lista_pesos_xcapa.Add(pesos_neuronas);
            }
            lista_pesos.Add(lista_pesos_xcapa.ToArray());
        } 

        pesos = lista_pesos.ToArray();

    }


}