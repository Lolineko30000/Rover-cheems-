using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRovertoGoal : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

    int NextPosIndex;
    Transform NextPos;
    // Start is called before the first frame update

    void Start()
    {
       NextPos = Positions[0]; 
       
    }

    // Update is called once per frame
    void Update()
    {
       MoveGameObject(); 
    }

    void MoveGameObject(){
        if (transform.position != NextPos.position){
                transform.position=Vector3.MoveTowards(transform.position, NextPos.position, ObjectSpeed*Time.deltaTime);
            }
        else
            {
                if (NextPosIndex == Positions.Length)
                {
                    Debug.Break();
                }
                else {
                    
                    //Debug.Log(Positions.Length);
                    NextPosIndex++;
                    //Debug.Log(NextPosIndex);
                    NextPos = Positions[NextPosIndex];
                }
            }
    }

}
