using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    //Inicializacion de botones del menu de pausa
    [SerializeField] private GameObject imagenFondoPausa;
    [SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject panelPausa;
    [SerializeField] private GameObject botonCambioControles;
    [SerializeField] private GameObject imagenFondoPlay;
    [SerializeField] private GameObject botonPlay;
    [SerializeField] private GameObject imagenFondoSalir;
    [SerializeField] private GameObject botonSalir;

    //Variables
    private bool juegoPausado = false;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(juegoPausado)
                Play();
            else 
                Pausa();
    }

    public void Pausa() 
    { 
        Time.timeScale = 0f; //Esta linea pausa el juego
        juegoPausado = true;

        //Esconde y/o muestra los elementos del menu de pausa
        imagenFondoPausa.SetActive(false);
        botonPausa.SetActive(false);

        panelPausa.SetActive(true);
        botonCambioControles.SetActive(true);
        imagenFondoPlay.SetActive(true);
        botonPlay.SetActive(true);
        imagenFondoSalir.SetActive(true);
        botonSalir.SetActive(true);
    }

    public void Play()
    { 
        Time.timeScale = 1f; //Esta linea reaunda el juego
        juegoPausado = false;

        //Esconde y/o muestra los elementos del menu de pausa
        imagenFondoPausa.SetActive(true);
        botonPausa.SetActive(true);

        panelPausa.SetActive(false);
        botonCambioControles.SetActive(false);
        imagenFondoPlay.SetActive(false);
        botonPlay.SetActive(false);
        imagenFondoSalir.SetActive(false);
        botonSalir.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        juegoPausado = false;

        //Trabaja con la libreria SceneManagement, permite reiniciar la escena
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void cambiarModoControl()
    {
        Debug.Log("Funcion en proceso de creacion!");
    }

    public void Cerrar()
    {
        Debug.Log("Saliendo al menu de inicio");
        SceneManager.LoadScene(0);
    }

}
//Codigo tomado de: https://www.youtube.com/watch?v=WQiUbygVLmg
