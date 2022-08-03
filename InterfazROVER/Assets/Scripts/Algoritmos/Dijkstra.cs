using System.Collections.Generic;

public class Dijkstra
{

   /*
    Funcion para reconstruir el camino
    camino: representan los padres de cada nodo en funcion a dijkstra
    nodo: el nodo al que queremos llegar
    */

    private static List<int> construir_camino(int[] camino, int nodo)
    {
        int aux = nodo;
        List<int> camino_completo = new List<int>();
        while(camino[nodo] != -1)
        {
            camino_completo.Add(camino[nodo]);
            nodo = camino[nodo];
        }

        camino_completo.Add(aux);

        return camino_completo;
    }


    /*
    Funcion auxiliar para encontrar el minimo de un arreglo desordenado O(n)

        Distancias: El arreglo de distancias encontradoas por dijkstra

        Numero de nodos: Cantidad de nodos del grafo

        Disttancia maxima: Distancia maima entre dos nodos
    */
    private static int indice_distancia_minima(double[] distancias, bool[] visitados, int numero_nodos)
    {
        int indice_minimo = 0;
        double distancia_minima = 100000000;

        for(int i = 0 ; i< numero_nodos ; i++)
        {
            if(visitados[i] == false && distancias[i] <= distancia_minima)
            {
                distancia_minima = distancias[i];
                indice_minimo = i;
            }
        }


        return indice_minimo;
    }



    /*
    Algoritmo Dijkstra
    Lista de adjasencia:
        Array bidimencional con formato
        array[i][j] = distancia => distancia del nodo i a j . en caso de no estar conectados = 0

        Numero de nodos: Cantidad de nodos del grafo

        Disttancia maxima: Distancia maima entre dos nodos

        nodo inicial: Nodo desde donde se calcularan el resto de distancias

        nodo m,eta: nodo al que se desea construir el camino

    */
    public static List<int> dijkstra(double[,] lista_de_adyacencia, int numero_nodos, int nodo_inicial, int nodo_meta)
    {

        double[] distancias = new double[numero_nodos];       //Lista de distancias de un nodo a otro
        bool[] visitados = new bool[numero_nodos];
        int[] camino = new int[numero_nodos];           //Lista que indica el camino

        for(int i = 0; i < numero_nodos; i++){            // Inicializacion de los arreglos con valores convenientes
            distancias[i] = 100000000;
            visitados[i] = false;
            camino[i] = -1;
        }


        distancias[nodo_inicial] = 0;               //Visitando el nodo inicial

        for(int i = 0; i < numero_nodos-1; i++)
        {
            int indice_minimo = indice_distancia_minima(distancias, visitados, numero_nodos);
            visitados[indice_minimo] = true;            //Visitando los nodos correspondientes (El que tenga la distancia minima ya guardada)

            for(int j = 0; j < numero_nodos; j++)
            {
                if(visitados[j] == false &&                                                          // En caso de que no haya sido visitado , este conectado al nodo actua                             // y que se mejore la distancia se agrega a nuestro arreglo
                    (distancias[indice_minimo] + lista_de_adyacencia[indice_minimo,j]) < distancias[j] &&
                    lista_de_adyacencia[indice_minimo,j] != 0 &&
                    distancias[indice_minimo] < 100000000
                )
                {
                    distancias[j] = distancias[indice_minimo] + lista_de_adyacencia[indice_minimo,j];
                    camino[j] = indice_minimo;                          //Se indica el padre del nodo que acabamos de encontrar para la reconstruccion del camino

                }

            }
        }

        return construir_camino(camino, nodo_meta);
    }

}
