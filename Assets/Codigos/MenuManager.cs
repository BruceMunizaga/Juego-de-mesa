using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //Instancia de la clase GuardarDato
    [SerializeField]GuardarDato guardarDato;

    /*
    Metodo que Cambiara la escena para jugar con un jugador
    */
    public void CantidadJugador1(){
        guardarDato.CambiarEscena(1);
    }

    /*
    Metodo que Cambiara la escena para jugar con dos jugadores
    */
    public void CantidadJugador2(){
        guardarDato.CambiarEscena(2);
    }

    /*
    Metodo que Cambiara la escena para jugar con tres jugadores
    */
    public void CantidadJugador3(){
        guardarDato.CambiarEscena(3);
    }

    /*
    Metodo que Cambiara la escena para jugar con cuatro jugadores
    */
    public void CantidadJugador4(){
        guardarDato.CambiarEscena(4);
    }
}
