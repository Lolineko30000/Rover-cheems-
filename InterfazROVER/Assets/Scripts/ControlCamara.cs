using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    //Script tomado de asset "Cainos" de Asset Store de Unity
    public Transform robot;
    public float velocidadMovimiento = 1.2f;

    private Vector3 offset; 
    private Vector3 posicionRobot;

    private void Start()
    {
        if(robot == null) 
            return;
        offset = transform.position - robot.position;
    }

    private void Update()
    {
        if(robot == null) 
            return;
        posicionRobot = robot.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicionRobot, velocidadMovimiento * Time.deltaTime);
    }
}
