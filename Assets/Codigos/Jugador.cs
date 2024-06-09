using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    //Nombre del jugador
    [SerializeField]string nombreJugador;

    //Turnos que lleva el jugador
    int turnosJugados;

    //Posicion actual del jugador
    int posicionActual = 0;

    //Constructor de la clase
    public Jugador(string nuevoNombre){
        this.nombreJugador = nuevoNombre;
        this.turnosJugados = 0;
    }

    /*
    metodo que incrementa los turnos jugados
    */
    public void IncrementarTurnosJugados(){
        this.turnosJugados++;
    }

    /*
    Funcion que comparte los turnos jugados
    */
    public int GetTurnosJugados(){
        return this.turnosJugados;
    }

    /*
    Funcion que comparte la posicion actual del jugador
    */
    public int GetPosicionActual(){
        return this.posicionActual;
    }

    /*
    Metodo que cambia la posicion del jugador
    */
    public void SetPosicionActual(int nuevaPosicion){
        this.posicionActual = nuevaPosicion;
    }

    /*
    Funcion que comparte el nombre del jugador 
    */
    public string GetNombre(){
        return this.nombreJugador;
    }
}
