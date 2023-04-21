using UnityEngine;

[RequireComponent(typeof(Marciano))]

public class MarcianoComportamiento : MonoBehaviour
{

    public Marciano marciano {get; private set;}
    public float duracion;
    
    private void Awake()
    {
        this.marciano = GetComponent<Marciano>();
        this.enabled = false;
    }

    public void Enable(){Enable(this.duracion);}
    public void Enable(float duracion)
    {
        this.enabled = true;
        CancelInvoke();
        Invoke(nameof(Disable), duracion);
    }
    public void Disable()
    {
        this.enabled = false;
        CancelInvoke();
    }

}
