using UnityEngine;

public class Marciano : MonoBehaviour
{
    public Marciano_movement movement {get; private set;}
    public MarcianoComportamiento marcianoC {get; private set;}

    public Transform rover_target;


    private void Awake()
    {
        this.movement.GetComponent<Marciano_movement>();
        this.marcianoC.GetComponent<MarcianoComportamiento>();
    }

    /*
    private void OnCollisionEnter2D(Collision2D colicion)
    {
        #Hacer que el jugador pierda
    }*/





    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.marcianoC.Enable();

        if(this.marcianoC != null){
            this.marcianoC.Enable();
        }

    }

}
