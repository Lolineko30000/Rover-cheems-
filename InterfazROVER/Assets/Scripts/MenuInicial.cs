using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    //Inicializacion
    [SerializeField] private GameObject botonInicio;
    [SerializeField] private GameObject botonCreditos;
    [SerializeField] private GameObject botonSalir;

    [SerializeField] private GameObject textoPregunta;
    [SerializeField] private GameObject panelSeleccion;
    [SerializeField] private GameObject botonTierra;
    [SerializeField] private GameObject botonMarte;
    [SerializeField] private GameObject botonLuna;

    bool enSelector = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            if(enSelector)
                SelectorEntorno(false);
    }
    
    //Activa o desactiva la vista de los botones del menu
    public void SelectorEntorno(bool interruptor)
    {
        botonInicio.SetActive(!interruptor);
        botonCreditos.SetActive(!interruptor);
        botonSalir.SetActive(!interruptor);

        textoPregunta.SetActive(interruptor);
        panelSeleccion.SetActive(interruptor);
        botonTierra.SetActive(interruptor);
        botonMarte.SetActive(interruptor);
        botonLuna.SetActive(interruptor);
        
        enSelector = true;
    }

    //Cambia la escena por la tierra
    public void EscenaTerrestre()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Cambia la escena a marte
    public void EscenaMarciana()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Cambia la escena a la luna
    public void EscenaLunar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    //Se supone mostraba los creditos
    public void Creditos()
    {
        Debug.Log("En proceso de construccion!");
    }

    //No va a funcionar a menos que el programa este creado
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
