using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    //Script tomado de asset "Cainos" de Asset Store de Unity
    public Transform robot;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadRotacion;

    private Vector3 offset; 
    private Vector3 posicionRobot;

    private void Start()
    {
        //Si no hay un modelo de robot asociado, la cámara no va a moverse/seguir a nadie
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
