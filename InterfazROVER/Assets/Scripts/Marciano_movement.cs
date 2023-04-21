using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Marciano_movement : MonoBehaviour
{
    public float velocidad_movimiento = 5.0f;
    public float velocidadmultiplicador = 1.0f;
    public Vector2 direccioninicial;
    public LayerMask obstaculos;

    public new Rigidbody2D rigidbody {get; private set;}
    public Vector2 direccion {get; private set;}
    public Vector2 siguienteDirecion {get; private set;}
    public Vector3 posicionInicial {get; private set;}

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.posicionInicial = this.transform.position;
    }

    private void Start()
    {
        RestartState();
    }

    private void RestartState()
    {
        this.velocidadmultiplicador = 1.0f;
        this.direccion = this.direccioninicial;
        this.siguienteDirecion = Vector2.zero;
        this.transform.position = this.posicionInicial;
        this.rigidbody.isKinematic = false;
        this.enabled = true;

    }

    private void Update()
    {
        if(this.siguienteDirecion != Vector2.zero)
        {
            setDirection(this.siguienteDirecion);
        }
    }

    private void FixedUpdate()
    {
        Vector2 posicion = this.rigidbody.position;
        Vector2 translacion = this.direccion * this.velocidad_movimiento * this.velocidadmultiplicador * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(posicion + translacion);
    }


    public void setDirection(Vector2 direccion,bool forced = false)
    {
        if(!ocupado(direccion) || forced)
        {
            this.direccion = direccion;
            this.siguienteDirecion = Vector2.zero;
        }else
        {
            this.siguienteDirecion = direccion;
        }

    }

    public bool ocupado(Vector2 direccion)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direccion, 1.5f, this.obstaculos);
        return hit.collider != null;
    }
}
