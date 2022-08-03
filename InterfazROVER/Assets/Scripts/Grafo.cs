using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo : MonoBehaviour
{
    public Color lineColor;
    private List<Transform> nodos;

    public void OnDrawGizmos()
    {
        double[,] adjasencia = crear_adj();

        Gizmos.color = lineColor;
        Transform[] Transforms_camino = GetComponentsInChildren<Transform>();
        nodos = new List<Transform>();

        for(int i = 0; i < Transforms_camino.Length ; i++)
        {
            if(Transforms_camino[i] != transform) 
            {
                nodos.Add(Transforms_camino[i]);
            }
        }

         for(int i = 0; i < 30 ; i++)
         { 
            for(int j = 0; j < 30 ; j++)        
            {
                if(adjasencia[i,j] != 0)
                {
                    Vector3 nodo_1 = nodos[i].position;
                    Vector3 nodo_2 = nodos[j].position;

                    //Debug.DrawWireSphere(nodo_1, 0.5f);
                    Debug.DrawLine(nodo_1, nodo_2);
                    
                    //Debug.Log(i);
                    //Debug.Log(nodo_1);
                }

            }
        }

    }


    private double[,] crear_adj()
    {
        double[,] adjasencia = new double[30,30];
        
        for(int i = 0; i < 30 ; i++)for(int j = 0; j < 30 ; j++)adjasencia[i,j] = 0;


        if(nodos != null){
            //Debug.Log(nodos.Count);
            adjasencia[0,1] = adjasencia[1,0] = Vector3.Distance(nodos[0].position, nodos[1].position);
            adjasencia[1,2] = adjasencia[2,1] = Vector3.Distance(nodos[2].position, nodos[1].position);
            adjasencia[3,1] = adjasencia[1,3] = Vector3.Distance(nodos[3].position, nodos[1].position);
            adjasencia[4,3] = adjasencia[3,4] = Vector3.Distance(nodos[4].position, nodos[3].position);
            adjasencia[4,5] = adjasencia[5,4] = Vector3.Distance(nodos[5].position, nodos[4].position);
            adjasencia[6,5] = adjasencia[5,6] = Vector3.Distance(nodos[5].position, nodos[6].position);
            adjasencia[7,4] = adjasencia[4,7] = Vector3.Distance(nodos[4].position, nodos[7].position);
            adjasencia[8,7] = adjasencia[7,8] = Vector3.Distance(nodos[7].position, nodos[8].position);
            adjasencia[1,9] = adjasencia[9,1] = Vector3.Distance(nodos[9].position, nodos[1].position);
            adjasencia[9,10] = adjasencia[10,9] = Vector3.Distance(nodos[10].position, nodos[9].position);
            adjasencia[10,11] = adjasencia[11,10] = Vector3.Distance(nodos[11].position, nodos[10].position);
            adjasencia[11,12] = adjasencia[12,11] = Vector3.Distance(nodos[12].position, nodos[11].position);
            adjasencia[12,13] = adjasencia[13,12] = Vector3.Distance(nodos[13].position, nodos[12].position);
            adjasencia[13,14] = adjasencia[14,13] = Vector3.Distance(nodos[13].position, nodos[14].position);
            adjasencia[14,15] = adjasencia[15,14] = Vector3.Distance(nodos[15].position, nodos[14].position);
            adjasencia[15,16] = adjasencia[16,15] = Vector3.Distance(nodos[16].position, nodos[15].position);
            adjasencia[15,17] = adjasencia[17,15] = Vector3.Distance(nodos[17].position, nodos[15].position);
            adjasencia[16,18] = adjasencia[18,16] = Vector3.Distance(nodos[18].position, nodos[16].position);
            adjasencia[18,19] = adjasencia[19,18] = Vector3.Distance(nodos[19].position, nodos[18].position);
            adjasencia[16,20] = adjasencia[20,16] = Vector3.Distance(nodos[20].position, nodos[16].position);
            adjasencia[20,21] = adjasencia[21,20] = Vector3.Distance(nodos[21].position, nodos[20].position);
            adjasencia[20,22] = adjasencia[22,20] = Vector3.Distance(nodos[22].position, nodos[20].position);
            adjasencia[20,23] = adjasencia[23,20] = Vector3.Distance(nodos[23].position, nodos[20].position);
            adjasencia[23,24] = adjasencia[24,23] = Vector3.Distance(nodos[24].position, nodos[23].position);
            adjasencia[24,25] = adjasencia[25,24] = Vector3.Distance(nodos[25].position, nodos[24].position);
            adjasencia[24,26] = adjasencia[26,24] = Vector3.Distance(nodos[24].position, nodos[26].position);
            adjasencia[26,29] = adjasencia[29,26] = Vector3.Distance(nodos[29].position, nodos[26].position);
            adjasencia[26,27] = adjasencia[27,26] = Vector3.Distance(nodos[27].position, nodos[26].position);
            adjasencia[28,27] = adjasencia[27,28] = Vector3.Distance(nodos[27].position, nodos[28].position);
        }
        return adjasencia;
    }
    
}
