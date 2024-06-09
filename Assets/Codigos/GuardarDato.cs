using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GuardarDato : MonoBehaviour
{
    //Variable estatica de la cantidad de jugadores
    public static int jugadores = 0;

    /*
    metodo que impide que el gameObject se destruya
    */
    void Awake(){
        DontDestroyOnLoad(gameObject);
    }

    /*
    metodo que cambia de escena
    */
    public void CambiarEscena(int cantidadJugador){
        jugadores = cantidadJugador;
        SceneManager.LoadScene("EscenaAR");
    }
    
    /*
    metodo que comparte la cantidad de jugadores
    */
    public int GetJugadores(){
        return jugadores;
    }
}
